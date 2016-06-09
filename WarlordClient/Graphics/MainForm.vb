Imports WarlordClient.Common
Imports WarlordClient.GameEngine
Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CharacterMovement
Imports WarlordClient.GameEngine.ClickFilter
Imports WarlordClient.GameEngine.Hand
Imports WarlordClient.Graphics.CardGrid

Namespace Graphics

    Public Class MainForm

#Region "members"

        Private ReadOnly _playStyle As PlayStyle
        Private WithEvents _gameEngineGameEngine As GameEngine.GameEngineGameEngine
        Private WithEvents _cfm As ClickFilterManager
        Private WithEvents _pth As PromptTextHandler
        Private WithEvents _lth As LogTextHandler

        Private _okCallBack As Action
        Private _cancelCallback As Action
        Private _doneCallback As Action
        Private _cardGridDotClickedCallback As Action(Of Object)

#End Region

#Region "ctor"

        Public Sub New()
            Me.New(PlayStyle.Debug)
        End Sub

        Private Sub New(ps As PlayStyle)
            InitializeComponent()
            _playStyle = ps
            _pth = New PromptTextHandler(txtBoxPrompt)
            _lth = New LogTextHandler(rtxtLog)
            ConsoleManager.Write("Initializing MainForm (" & ps.ToString & ")", True)
            Select Case _playStyle
                Case PlayStyle.Debug
                    SetupDebugGame()
                Case PlayStyle.Local
                    SetupLocalGame()
                Case PlayStyle.[Global]
                    SetupOnlineGame()
            End Select
        End Sub

        Public Sub New(player1SetupInfo As Setup.SetupInfo, player2SetupInfo As Setup.SetupInfo)
            Me.New(PlayStyle.Local)
            RegisterAndSetupPlayer(player1SetupInfo)
            RegisterAndSetupPlayer(player2SetupInfo)
            GameEngineGameEngine.CheckAndStartGame()
        End Sub

#End Region

#Region "methods"

        Private Sub SetupDebugGame()
            SetupLocalGame()
        End Sub

        Private Sub SetupLocalGame()
            GameEngineGameEngine = New GameEngine.GameEngineGameEngine(New LocalServer.LocalServer)
        End Sub

        Private Sub SetupOnlineGame()
        End Sub

        Private Sub RegisterAndSetupPlayer(si As Setup.SetupInfo)
            Dim newPlayer As Player = GameEngineGameEngine.AddPlayer(si)
            CreateHandFormForPlayer(newPlayer)
        End Sub

        Private Sub CreateHandFormForPlayer(plr As Player)
            Dim model = New HandModel(plr.Id)
            Dim hand = New HandForm(model, plr.Name)
            GameEngineGameEngine.RegisterHand(model)
            AddHandler hand.SmallCardMouseHover, AddressOf HandleMouseHoverEvent
            AddHandler hand.SmallCardMouseClick, AddressOf ClickFilterManager.HandleCardInHandClicked
            hand.Show()
        End Sub

        Private Sub RegisterPlayerToCardGrid(pl As Player)
            Dim cg As WarlordClient.CardGrid = Nothing
            If pl.Type = Player.PlayerType.Local Then
                If cgBottom.Owner <> Guid.Empty Then
                    cg = cgTop
                Else
                    cg = cgBottom
                End If
            ElseIf pl.Type = Player.PlayerType.Global Then
                cg = cgTop
            End If
            cg.Owner = pl.Id
            cg.SetLabel(String.Format("{0} - {1}", pl.Name, pl.Id))
        End Sub

        Public Sub AppendPlayerInputToLogBox(txt As String, playerName As String)
            If InvokeRequired Then
                Invoke(New Action(Of String, String)(AddressOf AppendPlayerInputToLogBox), txt, playerName)
            Else
                _lth.AppendPlayerInputToLogBox(txt, playerName)
            End If
        End Sub

        Public Sub AppendSystemMessageToLogBox(txt As String)
            If InvokeRequired Then
                Invoke(New Action(Of String)(AddressOf AppendSystemMessageToLogBox), txt)
            Else
                _lth.AppendSystemMessageToLogBox(txt)
            End If
        End Sub

        Private Sub DrawCardCollection(cc As CardCollection)
            GetCardGridById(cc.Owner).DrawCards(cc)
        End Sub

        Private Sub DrawPlacementDots(id As Guid, sc As SmallCard, mcs As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice))
            GetCardGridById(id).DrawPlacementDots(sc, mcs, callback)
        End Sub

        Private Sub ClearPlacementDots(id As Guid)
            GetCardGridById(id).ClearAllDrawnDots()
        End Sub

        Private Sub HandleMouseHoverEvent(sender As Object, e As EventArgs)
            UpdateDisplayCard(DirectCast(sender, SmallCard).Card.Card)
        End Sub

        Private Sub UpdateDisplayCard(c As Card)
            displayCard.UpdateImage(c)
        End Sub

        Private Sub SetActivePlayer(plr As Player, isLocal As Boolean)
            SetFilterDueToActivePlayerChange(plr, isLocal)
            SetDefaultInfoboxData()
        End Sub

        Private Sub SetFilterDueToActivePlayerChange(plr As Player, isLocal As Boolean)
            If isLocal Then
                ClickFilterManager.SetActivePlayerFilter(plr.Id)
            Else
                ClickFilterManager.SetInactiveFilter()
            End If
        End Sub

        Private Sub SetActiveFilter()
            ClickFilterManager.SetActivePlayerFilter(GameEngineGameEngine.LocalPlayer.Id)
        End Sub

        Private Sub SetInactiveFilter()
            ClickFilterManager.SetInactiveFilter()
        End Sub

        Private Sub SetFilter(cf As ClickFilter, cb As ClickFilterManager.Callback)
            ClickFilterManager.SetFilter(cf, cb)
        End Sub

        Private Sub CreateContextMenyForCardInPlay(sc As SmallCard, e As CardGridClickEventArgs)
            Dim cmc As ContextMenuCreator = GameEngineGameEngine.GetContextMenuCreator()
            cmc.CreateContextMenu(sc, e.MouseArgs.X, e.MouseArgs.Y)
        End Sub

        Private Sub SetInfoboxData(data As InfoboxData)
            txtBoxPrompt.Text = data.Text
            btnOK.Enabled = data.ButtonConfiguration.EnableOKButton
            btnCancel.Enabled = data.ButtonConfiguration.EnableCancelButton
            btnDone.Enabled = data.ButtonConfiguration.EnableDoneButton
            _okCallBack = data.ButtonConfiguration.OKCallback
            _cancelCallback = data.ButtonConfiguration.CancelCallback
            _doneCallback = data.ButtonConfiguration.DoneCallback
        End Sub

        Private Sub SetDefaultInfoboxData()
            txtBoxPrompt.Clear()
            btnOK.Enabled = False
            btnCancel.Enabled = False
            btnDone.Enabled = True
            _okCallBack = Nothing
            _cancelCallback = Nothing
            _doneCallback = AddressOf _gameEngineGameEngine.PassTurnByClickingDone
        End Sub

        Private Sub ButtonClicked(callback As Action)
            If callback IsNot Nothing Then
                callback.Invoke()
            End If
        End Sub

        Private Sub PlayCard(sc As SmallCard)
            GameEngineGameEngine.PlayCard(sc)
        End Sub

#End Region

#Region "eventhandlers"

        Private Sub txtSendMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSendMessage.KeyDown
            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                Dim txt As String = txtSendMessage.Text
                If Not String.IsNullOrWhiteSpace(txt) Then
                    AppendPlayerInputToLogBox(txt, _gameEngineGameEngine.PlayerName)
                    txtSendMessage.Clear()
                End If
            End If
        End Sub

        Private Sub _gameEngine_ActivePlayerSet(plr As Player, isLocal As Boolean) Handles _gameEngineGameEngine.ActivePlayerSet
            SetActivePlayer(plr, isLocal)
        End Sub

        Private Sub _gameEngine_CardCollectionChanged(cc As CardCollection) Handles _gameEngineGameEngine.CardCollectionChanged
            DrawCardCollection(cc)
        End Sub

        Private Sub cardGrids_MouseHoverOnCard(sender As Object, e As CardGridEventArgs) Handles cgBottom.MouseHoverOnCard, cgTop.MouseHoverOnCard
            HandleMouseHoverEvent(sender, e)
        End Sub

        Private Sub _gameEngine_ClearPlacementDots(id As Guid) Handles _gameEngineGameEngine.ClearPlacementDots
            ClearPlacementDots(id)
        End Sub

        Private Sub _gameEngine_DrawPlacementDots(id As Guid, card As SmallCard, movementChoices As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice)) Handles _gameEngineGameEngine.DrawPlacementDots
            DrawPlacementDots(id, card, movementChoices, callback)
        End Sub

        Private Sub _gameEngine_RegisterPlayerToCardGrid(pl As Player) Handles _gameEngineGameEngine.RegisterPlayerToCardGrid
            RegisterPlayerToCardGrid(pl)
        End Sub

        Private Sub _gameEngine_SetActiveFilter() Handles _gameEngineGameEngine.SetActiveFilter
            SetActiveFilter()
        End Sub

        Private Sub _gameEngine_SetInactiveFilter() Handles _gameEngineGameEngine.SetInactiveFilter
            SetInactiveFilter()
        End Sub

        Private Sub _gameEngine_SetDefaultInfoboxData() Handles _gameEngineGameEngine.SetDefaultInfoboxData
            SetDefaultInfoboxData()
        End Sub

        Private Sub _gameEngine_SetFilter(cf As ClickFilter, cb As ClickFilterManager.Callback) Handles _gameEngineGameEngine.SetFilter
            SetFilter(cf, cb)
        End Sub

        Private Sub _gameEngine_SetInfoboxData(data As InfoboxData) Handles _gameEngineGameEngine.SetInfoboxData
            SetInfoboxData(data)
        End Sub

        Private Sub _gameEngine_SystemMessage(txt As String) Handles _gameEngineGameEngine.SystemMessage
            AppendSystemMessageToLogBox(txt)
        End Sub

        Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
            AddHandler cgBottom.MouseClickOnCard, AddressOf ClickFilterManager.HandleCardInPlayClicked
            AddHandler cgTop.MouseClickOnCard, AddressOf ClickFilterManager.HandleCardInPlayClicked
        End Sub

        Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
            ButtonClicked(_okCallBack)
        End Sub

        Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
            ButtonClicked(_cancelCallback)
        End Sub

        Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
            ButtonClicked(_doneCallback)
        End Sub

#Region "clickfiltermanager"

        Private Sub _cfm_LeftClickInHand(sender As Object, e As Hand.HandClickEventArgs) Handles _cfm.LeftClickInHand
            PlayCard(DirectCast(sender, SmallCard))
        End Sub

        Private Sub _cfm_LeftClickInPlay(sender As Object, e As CardGridClickEventArgs) Handles _cfm.LeftClickInPlay

        End Sub

        Private Sub _cfm_RightClickInPlay(sender As Object, e As CardGridClickEventArgs) Handles _cfm.RightClickInPlay
            CreateContextMenyForCardInPlay(DirectCast(sender, SmallCard), e)
        End Sub

#End Region

#Region "menustrip"

        Private Sub ConsoleToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsoleToolStripMenuItem.Click
            ConsoleManager.ShowConsole()
        End Sub

#End Region

#Region "util"

        Private Function GetCardGridById(id As Guid) As WarlordClient.CardGrid
            Dim ret As WarlordClient.CardGrid = Nothing
            If cgBottom.Owner = id Then
                ret = cgBottom
            ElseIf cgTop.Owner = id Then
                ret = cgTop
            End If
            Return ret
        End Function

#End Region

#End Region

#Region "properties"

        Private Property GameEngineGameEngine As GameEngine.GameEngineGameEngine
            Get
                Return _gameEngineGameEngine
            End Get
            Set
                _gameEngineGameEngine = Value
            End Set
        End Property

        Private ReadOnly Property ClickFilterManager As ClickFilterManager
            Get
                If _cfm Is Nothing Then
                    _cfm = New ClickFilterManager(GameEngineGameEngine)
                End If
                Return _cfm
            End Get
        End Property

#End Region

#Region "enums"

        Public Enum PlayStyle
            Debug
            Local
            [Global]
        End Enum

#End Region

    End Class
End Namespace