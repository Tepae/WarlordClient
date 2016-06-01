Imports WarlordClient.PrebuiltDeck

Public Class ChoosePreBuiltDeckForm

    Private ReadOnly _dr As DeckRepository
    Private _isLoadingDecks As Boolean = False

    Public Event DeckSelected(dck As PrebuiltDeck.Deck)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dr = New DeckRepository()
    End Sub

    Private Sub RefreshDeckListBox()
        _isLoadingDecks = True
        lbDecks.Items.Clear()
        For Each deckName As String In _dr.DeckNames()
            lbDecks.Items.Add(_dr.GetDeckByName(deckName))
        Next
        lbDecks.SelectedItems.Clear()
        _isLoadingDecks = False
    End Sub

    Private Sub RefreshCardsListBox(deckName As String)
        Me.lbCards.Items.Clear()
        Dim dck As PrebuiltDeck.Deck = _dr.GetDeckByName(deckName)
        If dck IsNot Nothing Then
            For Each card As String In dck.GetCardNames()
                Dim cardNameAndAmount As String = dck.GetAmountOfCard(card).ToString() & " " & card
                lbCards.Items.Add(cardNameAndAmount)
            Next
        End If
    End Sub

    Private Sub ChoosePreBuiltDeckForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        RefreshDeckListBox()
    End Sub

    Private Sub RaiseDeckChosenEventAndClose()
        If lbDecks.SelectedItems.Count > 0 Then
            RaiseEvent DeckSelected(DirectCast(lbDecks.SelectedItem, PrebuiltDeck.Deck))
            Me.Close()
        End If
    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If lbDecks.SelectedItems.Count > 0 Then
            RaiseDeckChosenEventAndClose()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lbDecks_DoubleClick(sender As Object, e As System.EventArgs) Handles lbDecks.DoubleClick
        RaiseDeckChosenEventAndClose()
    End Sub

    Private Sub lbDecks_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lbDecks.SelectedIndexChanged
        If Not _isLoadingDecks AndAlso lbDecks.SelectedItem IsNot Nothing Then
            RefreshCardsListBox(lbDecks.SelectedItem.ToString())
        End If
    End Sub

End Class