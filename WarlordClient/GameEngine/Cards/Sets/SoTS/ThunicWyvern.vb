Imports WarlordClient.GameEngine.Cards.Card

Namespace GameEngine

    Public Class ThunicWyvern
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Thunic Wyvern"
            Me._imagePath = "\images\SotS\thunicwyvern.jpg"
            Me._level = 2
            Me._classes.Add([Class].None)
            'character
            Me.Races.Add(RaceEnum.Mercenary)
            Me.ArmorClass = 13
            Me.Skill = 1
            Me._hitPoints = 1
            Me.Alignment = AlignmentEnum.Evil
            Me.Traits.Add(CharacterTraitEnum.Monster)

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(3))
        End Function

    End Class

End Namespace