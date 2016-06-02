Namespace GameEngine

    Public Class Jigoral
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Jigoral"
            Me._imagePath = "\images\SotS\jigoral.jpg"
            Me._level = 1
            Me._classes.Add([Class].Rogue)
            'character
            Me.Races.Add(RaceEnum.Elf)
            Me.ArmorClass = 12
            Me.Skill = 0
            Me._hitPoints = 1
            Me.Alignment = AlignmentEnum.Evil

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(0))
        End Function

    End Class

End Namespace