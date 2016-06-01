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
            Me._races.Add(Race.Mercenary)
            Me._armorClass = 9
            Me._skill = 0
            Me._hitPoints = 1
            Me._alignment = Alignment.Good
            Me._flavorTraits.Add("Tribe of Stags")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(4))
        End Function

    End Class

End Namespace