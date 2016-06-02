Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine.Cards.Card

    Public Class PerformableAction

        Private ReadOnly _description As String = String.Empty

        Public Sub New(description As String, costs As List(Of ICost), effects As List(Of IEffect))
            _description = description
            Me.Effects = effects
            Me.Costs = costs
        End Sub

        Public ReadOnly Property Description As String
            Get
                Return _description
            End Get
        End Property

        Public Property Costs As List(Of ICost)
        Public Property Effects As List(Of IEffect)

    End Class

End Namespace
