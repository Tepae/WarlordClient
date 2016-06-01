Namespace GameEngine.Card

    Public Class StartingRank

        Private ReadOnly _rank As Integer
        Private ReadOnly _numberOfCharacters As Integer
        Private ReadOnly _traits As List(Of StartingRankCharacterDescription)

        Public Sub New(rank As Integer, numberOfCharacters As Integer, traits As List(Of StartingRankCharacterDescription))
            _rank = rank
            _numberOfCharacters = numberOfCharacters
            _traits = traits
        End Sub

        Public ReadOnly Property Rank As Integer
            Get
                Return _rank
            End Get
        End Property

        Public ReadOnly Property NumberOfCharacters As Integer
            Get
                Return _numberOfCharacters
            End Get
        End Property

        Public ReadOnly Property Traits As List(Of StartingRankCharacterDescription)
            Get
                Return _traits
            End Get
        End Property

    End Class

End Namespace
