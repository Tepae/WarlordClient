Namespace GameEngine.Order

    Public Interface IOrder
        Sub HandleBeforeReacts()
        Sub Perform(ge As GameEngine)
        Sub HandleAfterReacts()
        Property PassTurnWhenDone As Boolean
    End Interface

End Namespace