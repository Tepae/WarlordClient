Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class Keridwen
        Inherits WlCharacter

        Public Sub New()
            MyBase.New()

            'card
            _name = "Keridwen"
            _imagePath = "\images\SotS\keridwen.jpg"
            _level = 2
            _classes.Add(ClassEnum.Rogue)
            'WlCharacter
            Races.Add(RaceEnum.Mercenary)
            ArmorClass = 9
            Skill = 0
            _hitPoints = 1
            Alignment = AlignmentEnum.Good
            FlavorTraits.Add("Tribe of Stags")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(4))
        End Function

    End Class

End Namespace