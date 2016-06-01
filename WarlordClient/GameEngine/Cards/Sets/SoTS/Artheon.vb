Namespace GameEngine

    Public Class Artheon
        Inherits Card.Character

        Public Sub New()

            MyBase.New()

            'card
            Me._name = "Artheon"
            Me._imagePath = "\images\SotS\artheon.jpg"
            Me._level = 2
            Me._classes.Add([Class].Wizard)
            'character
            Me._races.Add(Race.Elf)
            Me._armorClass = 10
            Me._skill = 3
            Me._hitPoints = 1
            Me._alignment = Alignment.Evil
            Me._flavorTraits.Add("Syneri")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(5))
        End Function

    End Class

End Namespace