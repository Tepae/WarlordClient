Imports WarlordClient.Common
Imports WarlordClient.GameEngine.ClickFilter.ClickFilterManager
Imports WarlordClient.GameEngine.CharacterMovement
Imports WarlordClient.GameEngine.Hand
Imports WarlordClient.GameEngine.CardPlayer
Imports WarlordClient.GameEngine.CostAndEffect.Effect
Imports WarlordClient.GameEngine.StateBasedEffects

Namespace GameEngine

    Public Class GameEngine
        Implements IGameEngineUserInterfaceManipulator
        Implements IGameEngineGameFlowController
        Implements IGameEngineStateBasedEffectsFixer
        Implements IGameEngineGameStateManipulator
        Implements IGameEngineServerCommunication

#Region "members"

        Private WithEvents _serverCommObject As Comm.IServerComm
        Private WithEvents _deckManager As DeckManager
        Private WithEvents _gameState As GameState
        Private _localPlayer As Player
        Private _cardPlayerFactory As CardPlayerFactory

        Private _uim As UserInterfaceManipulator
        Private _gfc As GameFlowController
        Private _gsm As GameStateManipulator
        Private _sc As ServerCommunication

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

#Region "play card"

        Public Sub PlayCard(sc As SmallCard)
            CardPlayerFactory.CreateCardPlayer(sc, GameState).PlayCard()
        End Sub

#End Region

#Region "draw card"

        Public Sub DrawXCards(plr As Guid, amount As Integer) Implements IGameEngineGameStateManipulator.DrawXCards
            GameState.GetHandModelById(plr).AddCards(_deckManager.DrawX(plr, amount))
        End Sub

#End Region

        Private Sub StartGame() Implements IGameEngineGameFlowController.StartGame
            RaiseEvent GameStarting()
            DrawStartingHand
            NewTurn()
        End Sub

        Private Sub DrawStartingHand()
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                DrawXCards(plr.Id, 5)
            Next
        End Sub

        Private Sub NewRound() Implements IGameEngineGameFlowController.NewRound
            NewTurn()
        End Sub

        Private Sub NewTurn()
            UnspendCharacters()
            RollInitiative()
        End Sub

        Public Sub PassTurn() Implements IGameEngineGameFlowController.PassTurn
            Server.PlayerEndsTurn(LocalPlayer.Id, False)
        End Sub

        Public Sub PassTurnByClickingDone()
            Server.PlayerEndsTurn(LocalPlayer.Id, True)
        End Sub

        Public Function StateBasedEffectsAllowForTurnToBePassed(entryPointWhenFixed As Action) As Boolean Implements IGameEngineGameFlowController.StateBasedEffectsAllowForTurnToBePassed
            Return (New StateBasedEffectsFixer(Me, GameState, entryPointWhenFixed)).StateBasedEffectsAllowForTurnToBePassed()
        End Function

        Private Function CheckForDeadCharacters() As Boolean Implements IGameEngineStateBasedEffectsFixer.CheckForDeadCharacters
            Dim deadCharacters As List(Of CardInstance) = (New DeadCharacterChecker).GetDeadCharacters(Me, Players)
            For Each ci As CardInstance In deadCharacters
                GameState.PutCardIntoDiscardPile(ci)
                RaiseSystemMessage(String.Format("{0} dies", ci.Card.Name))
            Next
            Return True
        End Function

        Private Function CheckForPlayerLoss() As Boolean Implements IGameEngineStateBasedEffectsFixer.CheckForPlayerLoss
            Return True
        End Function

        Public Function CheckIllegalRanks() As Player Implements IGameEngineStateBasedEffectsFixer.CheckIllegalRanks
            Dim ret As Player = Nothing
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                Dim rank As Integer = GameState.GetFirstIllegalRank(plr.Id)
                If rank > 0 Then
                    ret = plr
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

        Private Sub HaveOpponentPlayEffect(plrId As Guid, effectId As Guid, effect As IEffect) Implements IGameEngineServerCommunication.HaveOpponentPlayEffect
            _serverCommObject.PlayEffectForOpponent(plrId, effectId, effect)
        End Sub

        Private Sub PlayEffect(plrId As Guid, effectId As Guid, effect As IEffect)

        End Sub

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

        Public Function GetContextMenuCreator() As ContextMenuCreator
            Return New ContextMenuCreator(GameState, Me, GameFlowController)
        End Function

        Public Sub CleanContextSensitiveVisuals() Implements IGameEngineUserInterfaceManipulator.CleanContextSensitiveVisuals
            For Each plr As Player In Players.GetPlayersByType(Player.PlayerType.Local)
                ClearPlacementDotsFromCardGrid(plr.Id)
            Next
            SetActiveFilterForPlayer()
            SetInfoboxToDefault()
        End Sub

#End Region

#Region "mainform"

        Public Sub SetActiveFilterForPlayer() Implements IGameEngineUserInterfaceManipulator.SetActiveFilterForPlayer
            RaiseEvent SetActiveFilter()
        End Sub

        Public Sub SetInactiveFilterForPlayer() Implements IGameEngineUserInterfaceManipulator.SetInactiveFilterForPlayer
            RaiseEvent SetInactiveFilter()
        End Sub

        Public Sub SetFilterForPlayer(cf As ClickFilter.ClickFilter, cb As ClickFilter.ClickFilterManager.Callback) Implements IGameEngineUserInterfaceManipulator.SetFilterForPlayer
            RaiseEvent SetFilter(cf, cb)
        End Sub

        Public Sub SetInfoBox(data As InfoboxData) Implements IGameEngineUserInterfaceManipulator.SetInfoBox
            RaiseEvent SetInfoboxData(data)
        End Sub

        Public Sub SetInfoboxToDefault() Implements IGameEngineUserInterfaceManipulator.SetInfoboxToDefault
            RaiseEvent SetDefaultInfoboxData()
        End Sub

        Public Sub DrawPlacementDotsToCardGrid(id As Guid, sc As SmallCard, movementChoices As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice)) Implements IGameEngineUserInterfaceManipulator.DrawPlacementDotsToCardGrid
            RaiseEvent DrawPlacementDots(id, sc, movementChoices, callback)
        End Sub

        Public Sub ClearPlacementDotsFromCardGrid(id As Guid) Implements IGameEngineUserInterfaceManipulator.ClearPlacementDotsFromCardGrid
            RaiseEvent ClearPlacementDots(id)
        End Sub

        Public Sub RaiseSystemMessage(txt As String) Implements IGameEngineUserInterfaceManipulator.RaiseSystemMessage
            RaiseEvent SystemMessage(txt)
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

        Public ReadOnly Property GameStateManipulator() As GameStateManipulator
            Get
                If _gsm Is Nothing Then
                    _gsm = New GameStateManipulator(Me)
                End If
                Return _gsm
            End Get
        End Property

        Public ReadOnly Property ServerCommunication() As ServerCommunication
            Get
                If _sc Is Nothing Then
                    _sc = New ServerCommunication(Me)
                End If
                Return _sc
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

        Private Sub _serverCommObject_PlayEffect(plrId As Guid, effectId As Guid, effect As Object) Handles _serverCommObject.PlayEffect
            PlayEffect(plrId, effectId, DirectCast(effect, IEffect))
        End Sub

        Private Sub _gameState_CardCollectionChanged(cc As CardCollection) Handles _gameState.CardCollectionChanged
            OnCardCollectionChanged(cc)
        End Sub

#End Region

    End Class

End Namespace