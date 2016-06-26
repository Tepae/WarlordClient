Namespace GameEngine.CostAndEffect.Cost

    Public Interface ICost
        Function CanPay(sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) As Boolean
        Function Paid() As Boolean
        Sub Pay(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState, cancel As Action)
        Sub Refund(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState)
        Sub Reset()
    End Interface

End Namespace