Namespace GameEngine.CostAndEffect.Cost

    Public Class OncePerTurn
        Implements ICost

        Private ReadOnly _name As String
        Private _paid As Boolean = False

        Public Sub New(name As String)
            _name = name
        End Sub

        Public Sub Pay(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState, cancel As Action) Implements ICost.Pay
            If CanPay(sourceCard, ownerOfCard, gs) Then
                OrderPerTurnCounter.Increment(sourceCard.Card.Id, _name)
                _paid = True
                EventNotifier.EventNotifier.Notify(id)
            End If
        End Sub

        Public Sub Refund(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) Implements ICost.Refund
            OrderPerTurnCounter.Decrement(sourceCard.Card.Id, _name)
            _paid = False
        End Sub

        Public Function CanPay(sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) As Boolean Implements ICost.CanPay
            Return OrderPerTurnCounter.CanPerformOrder(sourceCard.Card.Id, _name, 1)
        End Function

        Public Function Paid() As Boolean Implements ICost.Paid
            Return _paid
        End Function
    End Class

End Namespace