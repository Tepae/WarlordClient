Imports WarlordClient.GameEngine.Cards.Card

Namespace GameEngine.CardPlayer

    Public Class ActionPlayer
        Implements ICardPlayer

        Private ReadOnly _sc As SmallCard
        Private ReadOnly _gs As GameState

        Public Sub New(sc As SmallCard, gs As GameState)
            _sc = sc
            _gs = gs
        End Sub

        Public Sub PlayCard() Implements ICardPlayer.PlayCard
            DirectCast(_sc.Card.Card, WlAction).Perform(_gs.GetOwnerOfCardInstance(_sc.Card), _gs)
        End Sub

    End Class


End Namespace