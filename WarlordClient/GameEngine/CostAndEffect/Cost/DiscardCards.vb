Imports WarlordClient.GameEngine.ClickFilter

Namespace GameEngine.CostAndEffect.Cost

    Public Class DiscardCards
        Implements ICost

        Private _amount As Integer
        Private _gs As GameState
        Private _ownerOfCard As Guid

        Public Sub New(amount As Integer)
            _amount = amount
        End Sub

        Public Sub Pay(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) Implements ICost.Pay
            _ownerOfCard = ownerOfCard
            _gs = gs
            NextDiscard()
        End Sub

        Public Sub Refund(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) Implements ICost.Refund
            'not supported
        End Sub

        Public Function CanPay(sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) As Boolean Implements ICost.CanPay
            Return _amount <= gs.GetHandModelById(ownerOfCard).NumberOfCardsInHand()
        End Function

        Private Function Paid() As Boolean Implements ICost.Paid
            Return _amount <= 0
        End Function

        Private Sub NextDiscard()
            GameEngineObjects.UserInterfaceManipulator.SetFilterForPlayer(GetFilter(_ownerOfCard), AddressOf CardChosen)
        End Sub

        Private Function GetFilter(ownerOfCard As Guid) As ClickFilter.ClickFilter
            Return New ClickFilter.ClickFilter(New Filter(Filter.LogicalOperatorEnum.And, New LocationFilter(CardInstance.Location.InHand), New OwnerFilter(ownerOfCard)), True)
        End Function

        Private Sub CardChosen(sc As SmallCard, ownerOfCard As Guid, btn As MouseButtons)
            _gs.DiscardCardFromHand(sc.Card)
            _amount -= 1
            If _amount > 0 Then
                NextDiscard()
            End If
        End Sub

    End Class

End Namespace