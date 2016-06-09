Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once UnusedMember.Global
    Public Class BrineFiend
        Inherits WlCharacter

        Public Sub New()

            MyBase.New()

            'card
            _name = "Brine Fiend"
            _imagePath = "\images\SotS\brinefiend.jpg"
            _level = 1
            _classes.Add(ClassEnum.None)
            'WlCharacter
            Races.Add(RaceEnum.Mercenary)
            ArmorClass = 8
            Skill = 0
            _hitPoints = 2
            Alignment = AlignmentEnum.Evil
            Traits.Add(CharacterTraitEnum.Monster)

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(0))
        End Function

    End Class

End Namespace
