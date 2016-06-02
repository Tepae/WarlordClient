Namespace GameEngine

    Public Class Keridwen
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Keridwen"
            Me._imagePath = "\images\SotS\keridwen.jpg"
            Me._level = 2
            Me._classes.Add([Class].Rogue)
            'character
            Me.Races.Add(RaceEnum.Mercenary)
            Me.ArmorClass = 9
            Me.Skill = 0
            Me._hitPoints = 1
            Me.Alignment = AlignmentEnum.Good
            Me.FlavorTraits.Add("Tribe of Stags")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(4))
        End Function

    End Class

End Namespace