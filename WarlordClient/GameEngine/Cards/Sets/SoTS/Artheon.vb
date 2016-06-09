Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class Artheon
        Inherits WlCharacter

        Public Sub New()

            MyBase.New()

            'card
            _name = "Artheon"
            _imagePath = "\images\SotS\artheon.jpg"
            _level = 2
            _classes.Add(ClassEnum.Wizard)
            'WlCharacter
            Races.Add(RaceEnum.Elf)
            ArmorClass = 10
            Skill = 3
            _hitPoints = 1
            Alignment = AlignmentEnum.Evil
            FlavorTraits.Add("Syneri")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(5))
        End Function

    End Class

End Namespace