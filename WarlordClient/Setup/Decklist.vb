Imports WarlordClient.GameEngine.Card

Namespace Setup

    Public Class Decklist
        Private ReadOnly _cards As List(Of DeckListEntry)
        Private ReadOnly _name As String

        Sub New(ByVal name As String)
            _name = name
            _cards = New List(Of DeckListEntry)
        End Sub

        Public ReadOnly Property Cards() As List(Of DeckListEntry)
            Get
                Return _cards
            End Get
        End Property

        Public ReadOnly Property DeckName As String
            Get
                Return _name
            End Get
        End Property

        Public Sub AddCard(c As Card, amount As Integer)
            If GetCardAmount(c) = 0 Then
                _cards.Add(New DeckListEntry(c, amount))
            End If
        End Sub

        Public Function GetCardAmount(card As Card) As Integer
            Dim ret As Integer = 0
            For Each dle As DeckListEntry In _cards
                If dle.Card.Name = card.Name Then
                    ret = dle.Amount
                    Exit For
                End If
            Next
            Return ret
        End Function
    End Class

End Namespace
