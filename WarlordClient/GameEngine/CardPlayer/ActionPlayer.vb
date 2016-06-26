
Imports WarlordClient.GameEngine.RespondableAction

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
            Dim op As New RespondableActionPerformer(_gs.GetOwnerOfCardInstance(_sc.Card), _gs)
            op.Perform(New PlayAction(Guid.NewGuid(), _sc), True, Nothing)
        End Sub

    End Class


End Namespace