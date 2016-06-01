Namespace GameEngine

    Public Class Kether
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Kether"
            Me._imagePath = "\images\AS\kether.jpg"
            Me._level = 1
            Me._classes.Add([Class].Rogue)
            'character
            Me._races.Add(Race.Elf)
            Me._traits.Add(CharacterTrait.Scout)
            Me._armorClass = 11
            Me._skill = 0
            Me._hitPoints = 1
            Me._alignment = Alignment.Good

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