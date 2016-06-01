Imports WarlordClient.Setup

Namespace GameEngine

    Public Class DeckInstance

        Private _cardsAsList As List(Of CardInstance)
        Private _cards As Stack(Of CardInstance)
        Private _rng As Random

        Public Sub New(deckList As Decklist, startingCharacters As CardCollection, shuffle As Boolean)
            Dim cic As New CardInstanceCreator
            _cardsAsList = New List(Of CardInstance)
            For Each dle As DeckListEntry In deckList.Cards
                Dim amount As Integer = dle.Amount - startingCharacters.GetAmountOfCharacterInRanks(dle.Card)
                For i As Integer = 1 To amount
                    Dim ci As CardInstance = cic.GetCardInstanceFromClassName(dle.Card.Name)
                    ci.CardLocation = CardInstance.Location.InDeck
                    _cardsAsList.Add(ci)
                Next
            Next
            Setup(shuffle)
        End Sub

        Public Sub New(cards As List(Of CardInstance), shuffle As Boolean)
            _cardsAsList = cards
            For Each c As CardInstance In cards
                c.CardLocation = CardInstance.Location.InDeck
            Next
            Setup(shuffle)
        End Sub

        Private Sub Setup(shuffle As Boolean)
            _cards = New Stack(Of CardInstance)
            _rng = New Random()
            If shuffle Then
                ShuffleDeck()
            End If
        End Sub

        Public Sub ShuffleDeck()
            Dim tmp As List(Of CardInstance) = _cardsAsList.ToList()
            _cards.Clear()
            While tmp.Count > 0
                Dim c As CardInstance = tmp(_rng.Next(0, tmp.Count - 1))
                tmp.Remove(c)
                _cards.Push(c)
            End While
        End Sub

        Public Function DrawCard() As CardInstance
            Dim ret As CardInstance = Nothing
            If _cards.Count > 0 Then
                ret = _cards.Pop
            End If
            Return ret
        End Function

    End Class

End Namespace
