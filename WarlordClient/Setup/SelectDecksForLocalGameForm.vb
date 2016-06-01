Imports WarlordClient.GameEngine
Imports WarlordClient.Graphics

Namespace Setup

    Public Class SelectDecksForLocalGameForm

        Private _player1SetupInfo As SetupInfo
        Private _player2SetupInfo As SetupInfo

        Public Sub New()
            InitializeComponent()
            ConsoleManager.Write("Creating SelectDecksForLocalGameForm", True)
        End Sub

        Public Sub SetPlayer1SetupInfo(playerName As String, deck As Decklist, startingCharacters As CardCollection)
            _player1SetupInfo = New SetupInfo(playerName, deck, startingCharacters)
            SetInfoText(txtPlayer1DeckName, playerName, deck.DeckName)
            CheckOkButtonEnable()
        End Sub

        Public Sub SetPlayer2SetupInfo(playerName As String, deck As Decklist, startingCharacters As CardCollection)
            _player2SetupInfo = New SetupInfo(playerName, deck, startingCharacters)
            SetInfoText(txtPlayer2DeckName, playerName, deck.DeckName)
            CheckOkButtonEnable()
        End Sub

        Private Sub ShowSetupGameForm(callBack As SetupGameForm.DeckSelected)
            Dim sgf As New SetupGameForm(callBack)
            sgf.Show()
        End Sub

        Private Sub SetInfoText(txt As TextBox, playername As String, deckname As String)
            txt.Text = String.Format("{0} - {1}", playername, deckname)
        End Sub

        Private Sub CreateMainForm()
            Dim main As New MainForm(_player1SetupInfo, _player2SetupInfo)
            main.Show()
            Me.Close()
            Me.Dispose()
        End Sub

        Private Sub btnSelectDeckForPlayer1_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectDeckForPlayer1.Click
            ShowSetupGameForm(AddressOf SetPlayer1SetupInfo)
        End Sub

        Private Sub btnSelectDeckForPlayer2_Click(sender As System.Object, e As System.EventArgs) Handles btnSelectDeckForPlayer2.Click
            ShowSetupGameForm(AddressOf SetPlayer2SetupInfo)
        End Sub

        Private Sub CheckOkButtonEnable()
            btnOk.Enabled = _player1SetupInfo IsNot Nothing AndAlso _player2SetupInfo IsNot Nothing
        End Sub

        Private Sub btnOk_Click(sender As Object, e As System.EventArgs) Handles btnOk.Click
            CreateMainForm()
        End Sub

    End Class
End Namespace