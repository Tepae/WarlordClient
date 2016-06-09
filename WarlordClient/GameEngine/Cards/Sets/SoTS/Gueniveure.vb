Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class Gueniveure
        Inherits WlCharacter

        Public Sub New()
            MyBase.New()

            'card
            _name = "Gueniveure"
            _imagePath = "\images\SotS\gueniveure.jpg"
            _level = 2
            _classes.Add(ClassEnum.Rogue)
            'WlCharacter
            Races.Add(RaceEnum.Elf)
            ArmorClass = 12
            Skill = 2
            _hitPoints = 1
            Alignment = AlignmentEnum.Evil
            FlavorTraits.Add("Glyn")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(1))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(3))
        End Function

    End Class

End Namespace