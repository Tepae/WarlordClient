Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class Jigoral
        Inherits WlCharacter

        Public Sub New()
            MyBase.New()

            'card
            _name = "Jigoral"
            _imagePath = "\images\SotS\jigoral.jpg"
            _level = 1
            _classes.Add(ClassEnum.Rogue)
            'WlCharacter
            Races.Add(RaceEnum.Elf)
            ArmorClass = 12
            Skill = 0
            _hitPoints = 1
            Alignment = AlignmentEnum.Evil

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(0))
        End Function

    End Class

End Namespace