Namespace GameEngine

    Public Class Gueniveure
        Inherits Card.Character

        Public Sub New()
            MyBase.New()

            'card
            Me._name = "Gueniveure"
            Me._imagePath = "\images\SotS\gueniveure.jpg"
            Me._level = 2
            Me._classes.Add([Class].Rogue)
            'character
            Me._races.Add(Race.Elf)
            Me._armorClass = 12
            Me._skill = 2
            Me._hitPoints = 1
            Me._alignment = Alignment.Evil
            Me._flavorTraits.Add("Glyn")

        End Sub

        Public Overrides Function GetMeleeStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.MeleeStrike(1))
        End Function

        Public Overrides Function GetRangedStrikes() As Strike.StrikeSet
            Return New Strike.StrikeSet(True, Strike.StrikeSet.TargetingTypeEnum.Consecutive, New Strike.RangedStrike(3))
        End Function

    End Class

End Namespace