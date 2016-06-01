Namespace GameEngine.CostAndEffect

    Public Interface ICost
        Sub Pay()
        ReadOnly Property Paid As Boolean
        Event CostPaid(cost As ICost)
    End Interface

End Namespace