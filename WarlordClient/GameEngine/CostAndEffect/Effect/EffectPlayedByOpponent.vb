Namespace GameEngine.CostAndEffect.Effect

    Public Class EffectPlayedByOpponent
        Implements IEffect

        Private ReadOnly _effect As IEffect

        Public Sub New(effect As IEffect)
            _effect = effect
        End Sub

        Public Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, passTurn As Boolean, cancelAction As Action) Implements IEffect.Perform
            GameEngineObjects.ServerCommunication.HaveOpponentPlayEffect(owner, id, _effect)
        End Sub

        Public Function IsPerformed() As Boolean Implements IEffect.IsPerformed
            Return _effect.IsPerformed()
        End Function

    End Class

End Namespace