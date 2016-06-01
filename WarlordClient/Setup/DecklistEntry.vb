Imports WarlordClient.GameEngine.Card

Namespace Setup

    Public Class DeckListEntry

        Private ReadOnly _card As Card
        Private ReadOnly _amount As Integer

        Sub New(ByVal card As Card, ByVal amount As Integer)
            _card = card
            _amount = amount
        End Sub

        Public ReadOnly Property Card As Card
            Get
                Return _card
            End Get
        End Property

        Public ReadOnly Property Amount As Integer
            Get
                Return _amount
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return String.Format("{0} {1}", _amount.ToString(), _card.Name)
        End Function

    End Class

End Namespace
