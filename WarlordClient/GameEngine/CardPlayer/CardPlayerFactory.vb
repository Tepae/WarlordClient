Namespace GameEngine.CardPlayer

    Public Class CardPlayerFactory

        Public Function CreateCardPlayer(sc As SmallCard, gs As GameState) As ICardPlayer
            Dim ret As ICardPlayer = Nothing
            Select Case sc.Card.Card.CardType
                Case Cards.Card.Card.CardTypeEnum.Action
                    Return New ActionPlayer(sc, gs)
                Case Cards.Card.Card.CardTypeEnum.Character
                    Return New CharacterPlayer(sc, gs)
                Case Cards.Card.Card.CardTypeEnum.Item

            End Select
            Return ret
        End Function

    End Class

End Namespace