Namespace GameEngine.CostAndEffect.Effect

    Public Class DrawCardEffect
        Implements IEffect

        Private ReadOnly _amount As Integer
        Private _performed As Boolean = False

        Public Sub New(amount As Integer)
            _amount = amount
        End Sub

        Public Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, passTurn As Boolean, cancelAction As Action) Implements IEffect.Perform
            GameEngineObjects.GameStateManipulator.DrawXCards(owner, _amount)
            _performed = True
            EventNotifier.EventNotifier.Notify(id)
        End Sub

        Public Function IsPerformed() As Boolean Implements IEffect.IsPerformed
            Return _performed
        End Function

    End Class

End Namespace