Namespace GameEngine.CardPlayer

    Public Class CardPlayerFactory

        Private _sc As SmallCard = Nothing
        Private _ge As GameEngine = Nothing
        Private _gs As GameState = Nothing

        Public Function CreateCardPlayer(sc As SmallCard, ge As GameEngine, gs As GameState) As ICardPlayer
            _sc = sc
            _ge = ge
            _gs = gs
            Dim ret As ICardPlayer = Nothing
            Select Case sc.Card.Card.CardType
                Case Card.Card.CardTypeEnum.Action

                Case Card.Card.CardTypeEnum.Character

                Case Card.Card.CardTypeEnum.Item

            End Select
            Return ret
        End Function

    End Class

End Namespace