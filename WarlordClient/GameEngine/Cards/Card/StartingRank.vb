Imports WarlordClient.GameEngine.Card

Namespace GameEngine.Cards.Card

    Public Class StartingRank
        Public Sub New(rank As Integer, numberOfCharacters As Integer, traits As List(Of StartingRankCharacterDescription))
            Me.Rank = rank
            Me.NumberOfCharacters = numberOfCharacters
            Me.Traits = traits
        End Sub

        Public ReadOnly Property Rank As Integer

        Public ReadOnly Property NumberOfCharacters As Integer

        Public ReadOnly Property Traits As List(Of StartingRankCharacterDescription)

    End Class

End Namespace
