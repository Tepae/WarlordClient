Namespace GameEngine

    Public Class BrineFiend
        Inherits Card.Character

        Public Sub New()

            MyBase.New()

            'card
            Me._name = "Brine Fiend"
            Me._imagePath = "\images\SotS\brinefiend.jpg"
            Me._level = 1
            Me._classes.Add([Class].None)
            'character
            Me.Races.Add(RaceEnum.Mercenary)
            Me.ArmorClass = 8
            Me.Skill = 0
            Me._hitPoints = 2
            Me.Alignment = AlignmentEnum.Evil
            Me.Traits.Add(CharacterTraitEnum.Monster)

        End Sub
    End Class

End Namespace
