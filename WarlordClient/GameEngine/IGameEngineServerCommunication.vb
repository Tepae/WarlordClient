Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine

    Public Interface IGameEngineServerCommunication
        Sub HaveOpponentPlayEffect(plrId As Guid, effectId As Guid, effect As IEffect)
    End Interface

End Namespace