Namespace PrebuiltDeck

    Public Class DeckRepository

        Private _decks As List(Of Deck)

        Public Sub New()
            _decks = New List(Of Deck)
            InitializeRepository()
        End Sub

        Private Sub InitializeRepository()
            _decks.Add(New ElvishRogues)
            _decks.Add(New BryminsWarriors)
        End Sub

        Public Function DeckNames() As List(Of String)
            Dim ret As New List(Of String)
            For Each dck As Deck In _decks
                ret.Add(dck.Name)
            Next
            Return ret
        End Function

        Public Function GetDeckByName(name As String) As Deck
            Dim ret As Deck = Nothing
            For Each dck As Deck In _decks
                If name.Equals(dck.Name) Then
                    ret = dck
                    Exit For
                End If
            Next
            Return ret
        End Function

    End Class


End Namespace