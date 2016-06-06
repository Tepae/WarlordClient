Namespace GameEngine.CostAndEffect.Cost

    Public Class SpendMe
        Implements ICost

        Private _paid As Boolean = False

        Public Sub Pay(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) Implements ICost.Pay
            If CanPay(sourceCard, ownerOfCard, gs) Then
                sourceCard.Card.CardState = CardInstance.State.Spent
                _paid = True
                EventNotifier.EventNotifier.Notify(id)
            End If
        End Sub

        Public Sub Refund(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) Implements ICost.Refund
            If Paid() Then
                sourceCard.Card.CardState = CardInstance.State.Ready
                _paid = False
                EventNotifier.EventNotifier.Notify(id)
            End If
        End Sub

        Public Function CanPay(sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) As Boolean Implements ICost.CanPay
            Return sourceCard.Card.CardState = CardInstance.State.Ready
        End Function

        Public Function Paid() As Boolean Implements ICost.Paid
            Return _paid
        End Function

    End Class

End Namespace