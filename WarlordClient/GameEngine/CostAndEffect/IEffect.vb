Namespace GameEngine.CostAndEffect

    Public Interface IEffect
        Sub Perform(id As Guid, sc As SmallCard, ge As GameEngine, passTurn As Boolean)
        Property Performed As Boolean
        Event EffectPerformed(effect As IEffect)
    End Interface

End Namespace