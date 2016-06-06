﻿Imports WarlordClient.Common
Imports WarlordClient.GameEngine.ClickFilter.ClickFilterManager
Imports WarlordClient.GameEngine.CharacterMovement
Imports WarlordClient.GameEngine.Hand
Imports WarlordClient.GameEngine.CardPlayer

Namespace GameEngine

    Public Class GameEngine
        Implements IUserInterfaceManipulator
        Implements IGameEngineGameFlowController

#Region "members"

        Private WithEvents _serverCommObject As Comm.IServerComm
        Private WithEvents _deckManager As DeckManager
        Private WithEvents _gameState As GameState
        Private _localPlayer As Player
        Private _cardPlayerFactory As CardPlayerFactory
        Private _uim As UserInterfaceManipulator
        Private _gfc As GameFlowController

        Public Event CardCollectionChanged(cc As CardCollection)
        Public Event ActivePlayerSet(plr As Player, isLocal As Boolean)
        Public Event ClearPlacementDots(id As Guid)
        Public Event DrawPlacementDots(id As Guid, sc As SmallCard, movementChoices As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice))
        Public Event SystemMessage(txt As String)
        Public Event SetInfoboxData(data As InfoboxData)
        Public Event SetDefaultInfoboxData()
        Public Event SetActiveFilter()
        Public Event SetInactiveFilter()
        Public Event SetFilter(cf As ClickFilter.ClickFilter, cb As Callback)
        Public Event RegisterPlayerToCardGrid(pl As Player)
        Public Event GameStarting()

#End Region

#Region "ctor"

        Public Sub New(comm As Comm.IServerComm)
            _serverCommObject = comm
            _deckManager = New DeckManager
            _gameState = New GameState
            Players = New PlayerList
            GameEngineObjects.Register(Me)
        End Sub

#End Region

#Region "methods"

#Region "setup"

        Public Function AddPlayer(si As Setup.SetupInfo) As Player
            Dim newPlayer = New Player(si.Playername, si.Id, si.Type)
            Players.AddPlayer(newPlayer)
            RaiseEvent RegisterPlayerToCardGrid(newPlayer)
            si.StartingCharacters.Owner = newPlayer.Id
            RegisterDeckForPlayer(newPlayer.Id, New DeckInstance(si.Deck, si.StartingCharacters, True))
            RegisterStartingCharactersForPlayer(si.StartingCharacters)
            _serverCommObject.RegisterPlayer(newPlayer)
            _gameState.RegisterPlayer(newPlayer.Id)
            Return newPlayer
        End Function

        Public Sub RegisterHand(model As HandModel)
            GameState.RegisterHand(model)
        End Sub

        Private Sub RegisterDeckForPlayer(id As Guid, deck As DeckInstance)
            If IdIsValid(id) Then
                _deckManager.AddDeck(id, deck)
            End If
        End Sub

        Private Sub RegisterStartingCharactersForPlayer(chars As CardCollection)
            If IdIsValid(chars.Owner) Then
                _gameState.SetCollectionForOwner(chars)
            End If
        End Sub

        Public Sub CheckAndStartGame()
            If GameCanBeStarted() Then
                StartGame()
            End If
        End Sub

        Private Function GameCanBeStarted() As Boolean
            Return Players.Players.Count = 2
        End Function

#End Region

#Region "game"

#Region "movement"

        Public Sub MoveCharacter(sc As SmallCard, range As Integer)
            '  MoveCharacterEffect(CharacterPlacementDialogFactory.CreateDialogForStandardMovement(Me, sc, CardCollectionOfCardInstance(sc.Card), range))
        End Sub

        Private Sub MoveCharacter(dialog As CharacterPlacementDialog)

        End Sub

        Public Sub CancelMove()
            ClearMovementSettings()
        End Sub

        Public Sub ClearMovementSettings()
            SetActiveFilterForPlayer()
            SetInfoboxToDefault()
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                ClearPlacementDotsFromCardGrid(plr.Id)
            Next
        End Sub

#End Region

#Region "illegal rank"

        Private Sub PromptPlayerToFixIllegalRank(rank As Integer, plr As Player)
            RaiseSystemMessage(String.Format("Player {0} has an illegal rank: {1}", plr.Name, rank.ToString))
            SetClickFilterForIllegalRank(rank, plr)
            SetInfoBox(New InfoboxData(String.Format("Select a character to fall forward from rank {0}", rank.ToString), New NoUserInputButtonConfiguration))
        End Sub

        Private Sub SetClickFilterForIllegalRank(rank As Integer, plr As Player)
            Dim f As New ClickFilter.Filter
            f.Add(New ClickFilter.OwnerFilter(plr.Id))
            f.Add(New ClickFilter.LocationFilter(CardInstance.Location.InPlay))
            f.Add(New ClickFilter.RankFilter(rank))
            f.LogicalOperator = ClickFilter.Filter.LogicalOperatorEnum.And
            SetFilterForPlayer(New ClickFilter.ClickFilter(f, True), AddressOf CharacterToFallForwardChosen)
        End Sub

        Private Sub CharacterToFallForwardChosen(sc As SmallCard, owner As Guid, btn As MouseButtons)
            '   MoveCharacterEffect(CharacterPlacementDialogFactory.CreateDialogForIllegalRank(Me, sc, CardCollectionOfCardInstance(sc.Card), Guid.NewGuid()))
        End Sub

#End Region

#Region "perform strike"

        Public Sub PerformGenericMeleeStrike(sc As SmallCard)
            Dim sp As New Strike.StrikePerformerCreator()
            sp.PerformGenericMeleeStrike(Me, sc)
        End Sub

        Public Sub PerformGenericRangedStrike(sc As SmallCard)
            Dim sp As New Strike.StrikePerformerCreator
            sp.PerformGenericRangedStrike(Me, sc)
        End Sub

#End Region

#Region "discard"

        Public Sub DiscardCardFromHand(owner As Guid, sc As SmallCard)
            GameState.GetHandModelById(owner).RemoveCard(sc.Card, True)
        End Sub

#End Region

#Region "play card"

        Public Sub PlayCard(sc As SmallCard)

        End Sub

#End Region

        Private Sub StartGame() Implements IGameEngineGameFlowController.StartGame
            RaiseEvent GameStarting()
            NewTurn()
        End Sub

        Private Sub NewRound() Implements IGameEngineGameFlowController.NewRound
            NewTurn()
        End Sub

        Private Sub NewTurn()
            UnspendCharacters()
            EachLocalPlayerDiscardsAndDraws()
            RollInitiative()
        End Sub

        Public Function DrawCardsToHandsize(id As Guid, currentNumberOfCardsInHand As Integer) As List(Of CardInstance)
            Return _deckManager.DrawX(id, Constants.HandSize - currentNumberOfCardsInHand)
        End Function

        Private Sub EachLocalPlayerDiscardsAndDraws()
            For Each pl As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                GameState.GetHandModelById(pl.Id).AddCards(DrawCardsToHandsize(pl.Id, GameState.GetHandModelById(pl.Id).NumberOfCardsInHand()))
            Next
        End Sub

        Public Sub PassTurn() Implements IGameEngineGameFlowController.PassTurn
            Server.PlayerEndsTurn(LocalPlayer.Id, False)
        End Sub

        Public Sub PassTurnByClickingDone()
            Server.PlayerEndsTurn(LocalPlayer.Id, True)
        End Sub

        Public Function StateBasedEffectsAllowForTurnToBePassed() As Boolean Implements IGameEngineGameFlowController.StateBasedEffectsAllowForTurnToBePassed
            Return (CheckDeadCharacters() AndAlso CheckForLoss() AndAlso CheckIllegalRanks())
        End Function

        Private Sub HandleStateBasedEffects(callingId As Guid) Implements IGameEngineGameFlowController.HandleStateBasedEffects

        End Sub

        Private Function CheckDeadCharacters()
            'Dim deadCharacters As List(Of CardInstance) = (New DeadCharacterChecker).GetDeadCharacters(Me, Players)
            'For Each ci As CardInstance In deadCharacters
            '    GameState.PutCardIntoDiscardPile(ci)
            '    RaiseSystemMessage(String.Format("{0} dies", ci.Card.Name))
            'Next
            Return (New DeadCharacterChecker).GetDeadCharacters(Me, Players).Count = 0
        End Function

        Private Function CheckForLoss()
            Return True
        End Function

        Public Function CheckIllegalRanks() As Boolean
            Dim ret = True
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                Dim rank As Integer = GameState.GetFirstIllegalRank(plr.Id)
                If rank > 0 Then
                    ' PromptPlayerToFixIllegalRank(rank, plr)
                    ret = False
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Sub UnspendCharacters()
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                GameState.UnspendAllCharacters(plr.Id)
            Next
        End Sub

        Public Sub CancelAction() Implements IGameEngineGameFlowController.CancelAction
            SetActiveFilterForPlayer()
            SetInfoboxToDefault()
        End Sub

#Region "util"

        Public Function GetOwnerOfSmallCard(sc As SmallCard) As Guid
            Return GameState.ThisCardInstanceBelongsToCardCollection(sc.Card).Owner
        End Function

#End Region

#End Region

        Public Function PlayerName() As String
            Return LocalPlayer.Name
        End Function

        Public Function MyOpponent() As Player
            Return MyOpponent(_localPlayer.Id)
        End Function

        Public Function MyOpponent(id As Guid) As Player
            Return Players.GetOpponent(id)
        End Function

        Public Function GetPlayerById(id As Guid) As Player
            Return Players.GetPlayer(id)
        End Function

        Private Sub RollInitiative()
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                Server.RollInitiative(plr.Id, Die.Roll)
            Next
        End Sub

        Private Sub SetActivePlayer(id As Guid)
            If Players.GetPlayer(id).Type = Player.PlayerType.Local Then
                LocalPlayer = Players.GetPlayer(id)
                SetActiveFilterForPlayer()
            Else
                SetInactiveFilterForPlayer()
            End If
            RaiseEvent ActivePlayerSet(LocalPlayer, LocalPlayer.Type = Player.PlayerType.Local)
            RaiseSystemMessage(String.Format("It is now {0}'s turn", LocalPlayer.Name))
        End Sub

        Private Function IdIsValid(id As Guid) As Boolean
            Return Players.GetPlayer(id) IsNot Nothing
        End Function

        Private Sub OnCardCollectionChanged(cc As CardCollection)
            RaiseEvent CardCollectionChanged(cc)
        End Sub

        Public Sub RaiseSystemMessage(txt As String)
            RaiseEvent SystemMessage(txt)
        End Sub

        Public Function GetContextMenuCreator() As ContextMenuCreator
            Return New ContextMenuCreator(GameState, Me, GameFlowController)
        End Function

        Public Sub CleanContextSensitiveVisuals() Implements IUserInterfaceManipulator.CleanContextSensitiveVisuals
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                ClearPlacementDotsFromCardGrid(plr.Id)
            Next
            SetActiveFilterForPlayer()
            SetInfoboxToDefault()
        End Sub

#End Region

#Region "mainform"

        Public Sub SetActiveFilterForPlayer() Implements IUserInterfaceManipulator.SetActiveFilterForPlayer
            RaiseEvent SetActiveFilter()
        End Sub

        Public Sub SetInactiveFilterForPlayer() Implements IUserInterfaceManipulator.SetInactiveFilterForPlayer
            RaiseEvent SetInactiveFilter()
        End Sub

        Public Sub SetFilterForPlayer(cf As ClickFilter.ClickFilter, cb As ClickFilter.ClickFilterManager.Callback) Implements IUserInterfaceManipulator.SetFilterForPlayer
            RaiseEvent SetFilter(cf, cb)
        End Sub

        Public Sub SetInfoBox(data As InfoboxData) Implements IUserInterfaceManipulator.SetInfoBox
            RaiseEvent SetInfoboxData(data)
        End Sub

        Public Sub SetInfoboxToDefault() Implements IUserInterfaceManipulator.SetInfoboxToDefault
            RaiseEvent SetDefaultInfoboxData()
        End Sub

        Public Sub DrawPlacementDotsToCardGrid(id As Guid, sc As SmallCard, movementChoices As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice)) Implements IUserInterfaceManipulator.DrawPlacementDotsToCardGrid
            RaiseEvent DrawPlacementDots(id, sc, movementChoices, callback)
        End Sub

        Public Sub ClearPlacementDotsFromCardGrid(id As Guid) Implements IUserInterfaceManipulator.ClearPlacementDotsFromCardGrid
            RaiseEvent ClearPlacementDots(id)
        End Sub

#End Region

#Region "properties"

        Private ReadOnly Property Server As Comm.IServerComm
            Get
                Return _serverCommObject
            End Get
        End Property

        Private ReadOnly Property Players As PlayerList

        Public ReadOnly Property GameState As GameState
            Get
                Return _gameState
            End Get
        End Property

        Public Property LocalPlayer As Player
            Get
                Return _localPlayer
            End Get
            Set
                _localPlayer = Value
            End Set
        End Property

        Private ReadOnly Property CardPlayerFactory As CardPlayerFactory
            Get
                If _cardPlayerFactory Is Nothing Then
                    _cardPlayerFactory = New CardPlayerFactory
                End If
                Return _cardPlayerFactory
            End Get
        End Property

        Public ReadOnly Property UserInterfaceManipulator As UserInterfaceManipulator
            Get
                If _uim Is Nothing Then
                    _uim = New UserInterfaceManipulator(Me)
                End If
                Return _uim
            End Get
        End Property

        Public ReadOnly Property GameFlowController As GameFlowController
            Get
                If _gfc Is Nothing Then
                    _gfc = New GameFlowController(Me)
                End If
                Return _gfc
            End Get
        End Property

#End Region

#Region "eventhandlers"

        Private Sub _serverCommObject_NewRound() Handles _serverCommObject.NewRound
            NewRound()
        End Sub

        Private Sub _serverCommObject_PlayersTurn(id As Guid) Handles _serverCommObject.PlayersTurn
            SetActivePlayer(id)
        End Sub

        Private Sub _gameState_CardCollectionChanged(cc As CardCollection) Handles _gameState.CardCollectionChanged
            OnCardCollectionChanged(cc)
        End Sub

#End Region

    End Class

End Namespace