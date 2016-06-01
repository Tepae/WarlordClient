Imports WarlordClient.Setup

Public Class SelectGameTypeForm

    Private Const DEFAULT_PORT As Integer = 22491

#Region "methods"

    Private Sub EnableConnectionOptions(enable As Boolean)
        For Each ctrl As Control In gBoxConnectionSettings.Controls
            ctrl.Enabled = enable
        Next
    End Sub

    Private Sub SetIfHost(host As Boolean)
        If host Then
            'host code here
        Else
            'connect code here
        End If
    End Sub

    Private Sub Start()
        If rBtnLocal.Checked Then
            StartLocalGame()
        Else
            StartOnlineGame()
        End If
    End Sub

    Private Sub StartLocalGame()
        'lekval för två spelare -> registreing av lekval för två spelare -> visa main
        Dim selectDecksForm As New SelectDecksForLocalGameForm()
        selectDecksForm.Show()
        Me.Hide()
    End Sub

    Private Sub StartOnlineGame()

    End Sub

#End Region

#Region "eventhandlers"

    Private Sub rBtnLocal_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rBtnLocal.CheckedChanged
        EnableConnectionOptions(Not DirectCast(sender, RadioButton).Checked)
    End Sub

    Private Sub rBtnHostGame_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rBtnHostGame.CheckedChanged
        SetIfHost(DirectCast(sender, RadioButton).Checked)
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As System.EventArgs) Handles btnOk.Click
        Start()
    End Sub

    Private Sub SelectGameTypeForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        ConsoleManager.Write("Creating SelecteGameTypeForm", True)
        If Not Variables.Debug Then
            btnConsole.Visible = False
        End If
    End Sub

    Private Sub btnConsole_Click(sender As System.Object, e As System.EventArgs) Handles btnConsole.Click
        ConsoleManager.ShowConsole()
    End Sub

#End Region

End Class
