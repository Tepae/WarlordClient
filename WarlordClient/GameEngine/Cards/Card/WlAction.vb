Imports WarlordClient.GameEngine.ClickFilter
Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine.Cards.Card

    Public MustInherit Class WlAction
        Inherits Card

        Friend _traits As New List(Of ActionTrait)
        Friend _costs As List(Of ICost)
        Friend ReadOnly Effects As List(Of IEffect)
        Private _gs As GameState = Nothing

        Public Sub New()
            MyBase.New()
            _cardType = CardTypeEnum.Action
            _traits = New List(Of ActionTrait)
            _costs = New List(Of ICost)
            Effects = New List(Of IEffect)
            Setup()
        End Sub

#Region "methods"

        Protected MustOverride Sub Setup()

        Public Overridable Sub Perform(owner As Guid, gs As GameState)
            ChooseCharacterToPerformAction(owner)
            _gs = gs
        End Sub

        Private Sub ChooseCharacterToPerformAction(owner As Guid)
            Dim uim As UserInterfaceManipulator = GameEngineObjects.UserInterfaceManipulator
            uim.SetFilterForPlayer(GetFilterForPerformer(owner), AddressOf CharacterChosenToPerform)
            uim.SetInfoBox(New InfoboxData(String.Format("Select character to perform {0}", Name), New StandardUserInputNeededButtonConfiguration(AddressOf uim.CleanContextSensitiveVisuals)))
        End Sub

        Private Function GetFilterForPerformer(owner As Guid) As ClickFilter.ClickFilter
            Return New ClickFilter.ClickFilter(New Filter(Filter.LogicalOperatorEnum.And,
                                                          New OwnerFilter(owner),
                                                          New LocationFilter(CardInstance.Location.InPlay),
                                                          New LevelFilter(Level, ClickFilter.ClickFilter.ComparisonOperatorEnum.LesserThanOrEqual),
                                                          SubFilterForClasses()), True)
        End Function

        Private Function SubFilterForClasses() As Filter
            Dim f As New Filter(Filter.LogicalOperatorEnum.Or)
            For Each c As ClassEnum In Classes
                f.Add(New ClassFilter(c))
            Next
            Return f
        End Function

        Private Sub CharacterChosenToPerform(sc As SmallCard, owner As Guid, btn As MouseButtons)
            Perform(_gs, sc)
        End Sub

        Public Overridable Sub Perform(gs As GameState, source As SmallCard)
            Dim cmep As New CostManagerEffectPerformer(gs, GameEngineObjects.GameFlowController)
            cmep.PayCostsToGetEffects(_costs, Effects, source)
        End Sub

#End Region

#Region "enums"

        Public Enum ActionTrait
            None
        End Enum

#End Region

    End Class

End Namespace