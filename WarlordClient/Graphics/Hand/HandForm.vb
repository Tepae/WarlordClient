Imports WarlordClient.GameEngine
Imports WarlordClient.Graphics.Hand

Public Class HandForm

    Public Event SmallCardMouseHover(sender As Object, e As EventArgs)
    Public Event SmallCardMouseClick(sender As Object, e As HandClickEventArgs)

    Private WithEvents _hand As GameEngine.Hand.HandModel
    Private _margin As Integer = 10
    Private ReadOnly _drawnCards As List(Of SmallCard)

#Region "eventhandlers"

    Private Sub HandForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub _hand_CardListChanged(doRedraw As Boolean) Handles _hand.CardListChanged
        If doRedraw Then
            DrawCards()
        End If
    End Sub

#End Region

    Public Sub New(hand As Hand.HandModel, ownerName As String)
        InitializeComponent()
        _hand = hand
        _drawnCards = New List(Of SmallCard)
        Text = String.Format("{0}'s hand - {1}", ownerName, _hand.Owner)
    End Sub

    Public Sub DrawCards()
        ClearAllDrawnCards()
        Dim x As Integer = 0 + _margin
        Dim y As Integer = 0 + _margin
        For Each c As CardInstance In _hand.Cards
            Dim p As New Point(x, y)
            Dim sc As New SmallCard(c)
            sc.Location = p
            x += Constants.SmallCardWidth
            Controls.Add(sc)
            _drawnCards.Add(sc)
            AddHandler sc.MouseHover, AddressOf HandleMouseHover
            AddHandler sc.MouseClickOnMe, AddressOf HandleClick
            sc.Show()
        Next
    End Sub

    Private Sub ClearAllDrawnCards()
        For Each sc As SmallCard In _drawnCards
            RemoveHandler sc.MouseHover, AddressOf HandleMouseHover
            RemoveHandler sc.MouseClickOnMe, AddressOf HandleClick
            sc.Hide()
            sc.Dispose()
            sc = Nothing
        Next
    End Sub

    Private Sub HandleMouseHover(sender As Object, e As EventArgs)
        RaiseEvent SmallCardMouseHover(sender, e)
    End Sub

    Private Sub HandleClick(sender As Object, e As MouseEventArgs)
        Dim hcea As New HandClickEventArgs(_hand.Owner, e)
        RaiseEvent SmallCardMouseClick(sender, hcea)
    End Sub

    Public Property Cards() As List(Of CardInstance)
        Get
            Return _hand.Cards
        End Get
        Set(value As List(Of CardInstance))
            _hand.SetCards(value)
            DrawCards()
        End Set
    End Property

End Class