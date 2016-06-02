Namespace GameEngine.CostAndEffect

    Public Class CostAndEffectAction

        Private ReadOnly _source As SmallCard
        Private ReadOnly _ge As GameEngine
        Private ReadOnly _costs As List(Of ICost)
        Private ReadOnly _effects As List(Of IEffect)

        Public Sub New(source As SmallCard, ge As GameEngine, costs As List(Of ICost), effects As List(Of IEffect))
            _source = source
            _ge = ge
            _costs = costs
            _effects = effects
            SetEventHandlers()
        End Sub

        Private Sub SetEventHandlers()
            For Each cost As ICost In _costs
                AddHandler cost.CostPaid, AddressOf HandleCostPaid
            Next
            For Each effect As IEffect In _effects
                AddHandler effect.EffectPerformed, AddressOf HandleEffectPerformed
            Next
        End Sub

        Private Sub RemoveEventHandlers()
            For Each cost As ICost In _costs
                RemoveHandler cost.CostPaid, AddressOf HandleCostPaid
            Next
            For Each effect As IEffect In _effects
                RemoveHandler effect.EffectPerformed, AddressOf HandleEffectPerformed
            Next
        End Sub

        Private Sub HandleCostPaid(cost As ICost)
            If AllCostsPaid() Then
                PlayEffects()
            End If
        End Sub

        Private Sub HandleEffectPerformed(effect As IEffect)
            PlayEffects()
        End Sub

        Public Sub PayCostsToGetEffects()
            Dim cost As ICost = GetNextCost()
            If cost IsNot Nothing Then
                cost.Pay()
            End If
        End Sub

        Private Function GetNextCost() As ICost
            Dim ret As ICost = Nothing
            For Each cost As ICost In _costs
                If Not cost.Paid Then
                    ret = cost
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function GetNextEffect() As IEffect
            Dim ret As IEffect = Nothing
            For Each effect As IEffect In _effects
                If Not effect.Performed Then
                    ret = effect
                End If
            Next
            Return ret
        End Function

        Private Function EffectIsLastToBePerformed(effect As IEffect) As Boolean
            Return _effects.Last.Equals(effect)
        End Function

        Private Function AllCostsPaid()
            Dim ret As Boolean = True
            For Each cost As ICost In _costs
                If Not cost.Paid Then
                    ret = False
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Sub PlayEffects()
            Dim effect As IEffect = GetNextEffect()
            If effect IsNot Nothing Then
                effect.Perform(Guid.NewGuid, _source, _ge, EffectIsLastToBePerformed(effect))
            Else
                RemoveEventHandlers()
            End If
        End Sub

    End Class

End Namespace