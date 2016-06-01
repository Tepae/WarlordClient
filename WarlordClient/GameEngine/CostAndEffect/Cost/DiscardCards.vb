Imports WarlordClient.GameEngine.CostAndEffect

Namespace GameEngine.Cost.CostAndEffect

    Public Class DiscardCards
        Implements ICost

        Private _amount As Integer
        Private _ge As GameEngine
        Private _paid As Boolean = False
        Public Event CostPaid(cost As ICost) Implements ICost.CostPaid

        Public Sub New(amount As Integer, ge As GameEngine)
            _amount = amount
            _ge = ge
        End Sub

        Public Sub Pay() Implements ICost.Pay
            SetFilters()
            SetInfoBox()
        End Sub

        Private Sub SetFilters()
            _ge.SetFilterForPlayer(New ClickFilter.ClickFilter(New ClickFilter.Filter(ClickFilter.Filter.LogicalOperatorEnum.And, _
                                                                                     New ClickFilter.OwnerFilter(_ge.LocalPlayer.Id), _
                                                                                     New ClickFilter.LocationFilter(CardInstance.Location.InHand)), _
                                                                                 True), _
                                                                             AddressOf HandleCardChosenForDiscard)
        End Sub

        Private Sub SetInfoBox()
            _ge.SetInfoBox(New InfoboxData("Choose a card to discard", New ButtonConfiguration(False, True, False, Nothing, AddressOf _ge.CancelAction, Nothing)))
        End Sub

        Private Sub HandleCardChosenForDiscard(sc As SmallCard, owner As Guid, btn As MouseButtons)
            _ge.DiscardCardFromHand(owner, sc)
            NextDiscard()
        End Sub

        Private Sub NextDiscard()
            Static amount As Integer
            amount += 1
            If _amount > amount Then
                Pay()
            Else
                _paid = True
                RaiseEvent CostPaid(Me)
            End If
        End Sub

        Public ReadOnly Property Paid As Boolean Implements ICost.Paid
            Get
                Return _paid
            End Get
        End Property

    End Class

End Namespace