Namespace PrebuiltDeck

    Public MustInherit Class Deck

        Friend Cards As Dictionary(Of String, Integer)
        Friend PredefinedStartingCharacters As Dictionary(Of String, Dictionary(Of Integer, List(Of String)))
        Friend _name As String = "No name"
        Friend _description As String = "No description"

        Public Sub New()
            Cards = New Dictionary(Of String, Integer)
            PredefinedStartingCharacters = New Dictionary(Of String, Dictionary(Of Integer, List(Of String)))
        End Sub

        Friend MustOverride Sub Initialize()

        Public Overrides Function ToString() As String
            Return Me._name
        End Function

        Public Function GetAmountOfCard(cardName As String) As Integer
            Dim ret As Integer = 0
            If Cards.ContainsKey(cardName) Then
                ret = Cards(cardName)
            End If
            Return ret
        End Function

        Public Function GetCardNames() As List(Of String)
            Return Cards.Keys.ToList()
        End Function

        Public ReadOnly Property Name As String
            Get
                Return _name
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return _description
            End Get
        End Property

    End Class

End Namespace
