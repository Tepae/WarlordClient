Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect
Imports WarlordClient.GameEngine.EventNotifier

Namespace GameEngine.CostAndEffect

    Public Class CostManagerEffectPerformer
        Implements IListener

        Private ReadOnly _gs As GameState
        Private ReadOnly _gfc As GameFlowController
        Private ReadOnly _uim As UserInterfaceManipulator
        Private _costs As List(Of ICost)
        Private _effects As List(Of IEffect)
        Private _sc As SmallCard
        Private _owner As Guid
        Private _costId As Guid
        Private _effectId As Guid

        Public Sub New(gs As GameState, gfc As GameFlowController)
            _gs = gs
            _gfc = gfc
            _uim = GameEngineObjects.UserInterfaceManipulator
        End Sub

        Public Sub PayCostsToGetEffects(action As PerformableAction, sc As SmallCard)
            _costs = action.Costs
            _effects = action.Effects
            _sc = sc
            _owner = _gs.GetOwnerOfCardInstance(_sc.Card)
            PayNextCost()
        End Sub

        Private Sub PayNextCost()
            Dim cost As ICost = GetNextCost()
            If Not cost Is Nothing Then
                _costId = Guid.NewGuid()
                EventNotifier.EventNotifier.Register(_costId, Me, True)
                cost.Pay(_costId, _sc, _owner, _gs)
            Else
                PlayNextEffect()
            End If
        End Sub

        Private Function GetNextCost() As ICost
            Dim ret As ICost = Nothing
            For Each cost As ICost In _costs
                If Not cost.Paid() Then
                    ret = cost
                End If
            Next
            Return ret
        End Function

        Private Sub PlayNextEffect()
            Dim effect As IEffect = GetNextEffect()
            If Not effect Is Nothing Then
                _effectId = Guid.NewGuid()
                EventNotifier.EventNotifier.Register(_effectId, Me, True)
                effect.Perform(_effectId, _owner, _sc, _gs, IsLastEffectInList(effect), AddressOf Cancel)
            End If
        End Sub

        Private Function GetNextEffect() As IEffect
            Dim ret As IEffect = Nothing
            For Each effect As IEffect In _effects
                If Not effect.IsPerformed() Then
                    ret = effect
                End If
            Next
            Return ret
        End Function

        Private Function IsLastEffectInList(effect As IEffect) As Boolean
            Return _effects.Last().Equals(effect)
        End Function

        Public Sub Cancel()
            For Each cost As ICost In _costs
                cost.Refund(_costId, _sc, _owner, _gs)
            Next
            For Each effect As IEffect In _effects
                effect.Cancel()
            Next
        End Sub

        Public Sub Notify(id As Guid, hasData As Boolean) Implements IListener.Notify
            If _costId = id Then
                PayNextCost()
            ElseIf _effectId = id Then
                PlayNextEffect()
            End If
        End Sub

    End Class

End Namespace