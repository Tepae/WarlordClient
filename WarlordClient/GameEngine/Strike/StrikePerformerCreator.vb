Imports WarlordClient.GameEngine.Card

Namespace GameEngine.Strike

    Public Class StrikePerformerCreator

        Private _ge As GameEngine
        Private _source As SmallCard
        Private _strikes As StrikeSet

        Private Sub PerformGenericStrike(gameEngine As GameEngine, source As SmallCard)
            _ge = gameEngine
            _source = source
            NextStrike(0)
        End Sub

        Public Sub PerformGenericMeleeStrike(gameEngine As GameEngine, source As SmallCard)
            _strikes = DirectCast(source.Card.Card, IMeleeStriker).GetMeleeStrikes
            PerformGenericStrike(gameEngine, source)
        End Sub

        Public Sub PerformGenericRangedStrike(gameEngine As GameEngine, source As SmallCard)
            _strikes = DirectCast(source.Card.Card, IRangedStriker).GetRangedStrikes
            PerformGenericStrike(gameEngine, source)
        End Sub

        Private Sub NextStrike(index As Integer)
            If _strikes.Count > index Then

            End If
        End Sub

    End Class

End Namespace