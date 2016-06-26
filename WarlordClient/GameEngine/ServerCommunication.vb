Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine

    Public Class ServerCommunication

        Private ReadOnly _ge As IGameEngineServerCommunication

        Public Sub New(ge As IGameEngineServerCommunication)
            _ge = ge
        End Sub

        Public Sub HaveOpponentPlayEffect(plrId As Guid, effectId As Guid, effect As IEffect)
            _ge.HaveOpponentPlayEffect(plrId, effectId, effect)
        End Sub

    End Class

End Namespace