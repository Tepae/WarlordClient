Imports WarlordClient.GameEngine.Order

Namespace GameEngine.CardPlayer

    Public Class CardPlayerFactory

        Private _sc As SmallCard = Nothing
        Private _ge As GameEngine = Nothing
        Private _op As OrderPerformer
        Private _gs As GameState = Nothing

        Public Function CreateCardPlayer(sc As SmallCard, ge As GameEngine, op As OrderPerformer, gs As GameState) As ICardPlayer
            _sc = sc
            _ge = ge
            _op = op
            _gs = gs
            Dim ret As ICardPlayer = Nothing
            Select Case sc.Card.Card.CardType
                Case Card.Card.CardTypeEnum.Action
                    ret = CreateActionPlayer()
                Case Card.Card.CardTypeEnum.Character
                    ret = CreateCharacterPlayer()
                Case Card.Card.CardTypeEnum.Item
                    ret = CreateItemPlayer()
            End Select
            Return ret
        End Function

        Private Function CreateCharacterPlayer() As ICardPlayer
            Return New CharacterPlayer(_sc, _ge, _op, _gs)
        End Function

        Private Function CreateActionPlayer() As ICardPlayer

        End Function

        Private Function CreateItemPlayer() As ICardPlayer

        End Function

    End Class

End Namespace