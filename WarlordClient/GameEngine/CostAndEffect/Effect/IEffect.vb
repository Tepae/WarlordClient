Namespace GameEngine.CostAndEffect.Effect

    Public Interface IEffect
        Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, passTurn As Boolean, cancelAction As Action)
        Sub Cancel()
        Function IsPerformed() As Boolean
    End Interface

End Namespace