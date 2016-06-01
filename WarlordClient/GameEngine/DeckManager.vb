Namespace GameEngine

    Public Class DeckManager

        Private _decks As Dictionary(Of Guid, DeckInstance)

        Public Sub New()
            _decks = New Dictionary(Of Guid, DeckInstance)
        End Sub

        Public Sub AddDeck(id As Guid, deck As DeckInstance)
            If Not _decks.ContainsKey(id) Then
                deck.ShuffleDeck()
                _decks.Add(id, deck)
            End If
        End Sub

        Public Function Draw(id As Guid) As CardInstance
            Dim ret As CardInstance = Nothing
            If _decks.ContainsKey(id) Then
                ret = _decks(id).DrawCard
            End If
            Return ret
        End Function

        Public Function DrawX(id As Guid, x As Integer) As List(Of CardInstance)
            Dim ret As New List(Of CardInstance)
            For i As Integer = 1 To x
                ret.Add(Draw(id))
            Next
            Return ret
        End Function

    End Class

End Namespace