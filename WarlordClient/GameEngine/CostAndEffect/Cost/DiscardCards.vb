Imports WarlordClient.GameEngine.ClickFilter

Namespace GameEngine.CostAndEffect.Cost

    Public Class DiscardCards
        Implements ICost

        Private ReadOnly _amount As Integer
        Private _remains As Integer
        Private _gs As GameState
        Private _ownerOfCard As Guid
        Private _id As Guid
        Private _cancel As Action

        Public Sub New(amount As Integer)
            _amount = amount
            _remains = _amount
        End Sub

        Public Sub Pay(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState, cancel As Action) Implements ICost.Pay
            _id = id
            _ownerOfCard = ownerOfCard
            _gs = gs
            _cancel = cancel
            NextDiscard()
        End Sub

        Private Sub Reset() Implements ICost.Reset
            _remains = _amount
        End Sub

        Public Sub Refund(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) Implements ICost.Refund
            'not supported
        End Sub

        Public Function CanPay(sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) As Boolean Implements ICost.CanPay
            Return _remains <= gs.GetHandModelById(ownerOfCard).NumberOfCardsInHand()
        End Function

        Private Function Paid() As Boolean Implements ICost.Paid
            Return _remains = 0
        End Function

        Private Sub NextDiscard()
            Dim uim As UserInterfaceManipulator = GameEngineObjects.UserInterfaceManipulator
            uim.SetFilterForPlayer(GetFilter(_ownerOfCard), AddressOf CardChosen)
            uim.SetInfoBox(New InfoboxData("Choose a card to discard", If(_amount = _remains, New StandardUserInputNeededButtonConfiguration(_cancel), New NoUserInputButtonConfiguration)))
        End Sub

        Private Function GetFilter(ownerOfCard As Guid) As ClickFilter.ClickFilter
            Return New ClickFilter.ClickFilter(New Filter(Filter.LogicalOperatorEnum.And, New LocationFilter(CardInstance.Location.InHand), New OwnerFilter(ownerOfCard)), True)
        End Function

        Private Sub CardChosen(sc As SmallCard, ownerOfCard As Guid, btn As MouseButtons)
            _gs.DiscardCardFromHand(sc.Card)
            _remains -= 1
            If _remains > 0 Then
                NextDiscard()
            Else
                EventNotifier.EventNotifier.Notify(_id)
            End If
        End Sub

    End Class

End Namespace