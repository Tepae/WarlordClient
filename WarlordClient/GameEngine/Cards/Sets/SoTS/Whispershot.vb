Namespace GameEngine

    Public Class Whispershot
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Whispershot"
            Me._imagePath = "\images\SotS\whispershot.jpg"
            Me._level = 1
            Me._classes.Add([Class].Fighter)
            'character
            Me.Races.Add(RaceEnum.Elf)
            Me.ArmorClass = 10
            Me.Skill = 0
            Me._hitPoints = 1
            Me.Alignment = AlignmentEnum.Evil

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(1))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(1))
        End Function

    End Class

End Namespace