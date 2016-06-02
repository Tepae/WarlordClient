Namespace GameEngine.CostAndEffect.Cost

    Public Interface ICost
        Function CanPay(sourceCard As SmallCard, ownerOfCard As Guid, gs As GameState) As Boolean
        Function Paid() As Boolean
        Sub Pay(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, uim As IUserInterfaceManipulator, gs As GameState)
        Sub Refund(id As Guid, sourceCard As SmallCard, ownerOfCard As Guid, uim As IUserInterfaceManipulator, gs As GameState)
    End Interface

End Namespace