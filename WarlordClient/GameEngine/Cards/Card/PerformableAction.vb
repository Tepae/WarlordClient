Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine.Cards.Card

    Public Class PerformableAction
        Public Sub New(description As String, costs As List(Of ICost), effects As List(Of IEffect))
            Me.Description = description
            Me.Effects = effects
            Me.Costs = costs
        End Sub

        Public ReadOnly Property Description As String = String.Empty
        Public Property Costs As List(Of ICost)
        Public Property Effects As List(Of IEffect)

        Public Function CanPayCosts(sourceCard As SmallCard, owner As Guid, gs As GameState) As Boolean
            Dim ret = False
            For Each cost As ICost In Costs
                ret = cost.CanPay(sourceCard, owner, gs)
                If Not ret Then
                    Exit For
                End If
            Next
            Return ret
        End Function

    End Class

End Namespace
