Namespace GameEngine.Order

    Public Interface IOrder
        Sub Perform(owner As Guid, gs As GameState)
        Function Id() As Guid
    End Interface

End Namespace