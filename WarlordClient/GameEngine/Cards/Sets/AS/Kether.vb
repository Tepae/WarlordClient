Imports WarlordClient.GameEngine.Cards.Card

Namespace GameEngine

    Public Class Kether
        Inherits WlCharacter

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Kether"
            Me._imagePath = "\images\AS\kether.jpg"
            Me._level = 1
            Me._classes.Add(ClassEnum.Rogue)
            'WlCharacter
            Me.Races.Add(RaceEnum.Elf)
            Me.Traits.Add(CharacterTraitEnum.Scout)
            Me.ArmorClass = 11
            Me.Skill = 0
            Me._hitPoints = 1
            Me.Alignment = AlignmentEnum.Good

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(5))
        End Function

        Public Overrides Function GetFilterForMeleeStrike() As ClickFilter.ClickFilter
            Dim cf As ClickFilter.ClickFilter = MyBase.GetFilterForMeleeStrike()
            cf.AddCriteria(New ClickFilter.Filter(ClickFilter.Filter.LogicalOperatorEnum.Not, New ClickFilter.StateFilter(CardInstance.State.Ready)))
            Return cf
        End Function

    End Class

End Namespace