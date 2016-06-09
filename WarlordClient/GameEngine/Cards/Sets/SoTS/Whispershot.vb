Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    Public Class Whispershot
        Inherits WlCharacter

        Public Sub New()
            MyBase.New()

            'card
            _name = "Whispershot"
            _imagePath = "\images\SotS\whispershot.jpg"
            _level = 1
            _classes.Add(ClassEnum.Fighter)
            'WlCharacter
            Races.Add(RaceEnum.Elf)
            ArmorClass = 10
            Skill = 0
            _hitPoints = 1
            Alignment = AlignmentEnum.Evil

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(1))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(1))
        End Function

    End Class

End Namespace