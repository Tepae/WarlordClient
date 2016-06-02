Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.ClickFilter
Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect.Cost
Imports WarlordClient.GameEngine.CostAndEffect.Effect

Namespace GameEngine.Card

    Public MustInherit Class Character
        Inherits Card
        Implements IMeleeStriker
        Implements IRangedStriker

        Private ReadOnly _races As New List(Of RaceEnum)
        Friend ArmorClass As Integer
        Friend Skill As Integer
        Friend _hitPoints As Integer
        Friend Alignment As AlignmentEnum
        Friend ReadOnly Traits As New List(Of CharacterTraitEnum)
        Friend ReadOnly FlavorTraits As New List(Of String)

        Public Sub New()
            MyBase.New()
            Me._cardType = CardTypeEnum.Character
            _races = New List(Of RaceEnum)
            Traits = New List(Of CharacterTraitEnum)
            FlavorTraits = New List(Of String)
            AddPerformableActions()
        End Sub

#Region "methods"

        Public Overridable Function CanSpendToMoveForward() As Boolean
            Return True
        End Function

        Public Overridable Function CanSpendToMoveBackward() As Boolean
            Return True
        End Function

        Public Overridable Function StartingState() As CardInstance.State
            Return CardInstance.State.Ready
        End Function

        Public Overridable Function RanksForPlacement() As List(Of Integer)
            Return New List(Of Integer) From {Me.Level}
        End Function

        Public Overridable Function GetMeleeStrikes() As Strike.StrikeSet Implements IMeleeStriker.GetMeleeStrikes
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive)
        End Function

        Public Overridable Function GetRangedStrikes() As Strike.StrikeSet Implements IRangedStriker.GetRangedStrikes
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive)
        End Function

        Public Overridable Function GetOtherActions() As List(Of PerformableAction)
            Return New List(Of PerformableAction)
        End Function

        Public Overridable Function GetFilterForMeleeStrike() As ClickFilter.ClickFilter Implements IMeleeStriker.GetFilterForMeleeStrike
            Return New ClickFilter.ClickFilter(New Filter(Filter.LogicalOperatorEnum.And, New LocationFilter(CardInstance.Location.InPlay), New RankFilter(1)), True)
        End Function

        Public Overridable Function GetFilterForRangedStrike() As ClickFilter.ClickFilter Implements IRangedStriker.GetFilterForRangedStrike
            Return New ClickFilter.ClickFilter(New Filter(Filter.LogicalOperatorEnum.And, New LocationFilter(CardInstance.Location.InPlay)), True)
        End Function

        Private Sub AddPerformableActions()
            If CanSpendToMoveForward() Or CanSpendToMoveBackward() Then
                Me.Actions.Add(New PerformableAction("Spend to move", New List(Of ICost) From {New SpendMe()}, New List(Of IEffect) From {New MoveCharacter(1)}))
            End If
            If GetMeleeStrikes().Count > 0 Then
                Me.Actions.Add(New PerformableAction(GetMeleeStrikes.ToString, New List(Of ICost) From {New SpendMe()}, New List(Of IEffect)))
            End If
            If GetRangedStrikes().Count > 0 Then
                Me.Actions.Add(New PerformableAction(GetRangedStrikes.ToString, New List(Of ICost) From {New SpendMe()}, New List(Of IEffect)))
            End If
            For Each pa As PerformableAction In GetOtherActions()
                Me.Actions.Add(pa)
            Next
        End Sub

#End Region

#Region "properties"

        Public ReadOnly Property Races As List(Of RaceEnum)
            Get
                Return _races
            End Get
        End Property

        Friend Overridable ReadOnly Property MovementRange
            Get
                Return 1
            End Get
        End Property

        Public ReadOnly Property HitPoints As Integer
            Get
                Return _hitPoints
            End Get
        End Property

#End Region

#Region "enums"

        Public Enum AlignmentEnum
            Evil
            Good
        End Enum

        Public Enum CharacterTraitEnum
            Any
            Monster
            Scout
            Warlord
            Unique
        End Enum

        Public Enum RaceEnum
            Any
            Deveranian
            Dwarf
            Elf
            FreeKingdoms
            Mercenary
            Nothrog
        End Enum

#End Region

    End Class

End Namespace