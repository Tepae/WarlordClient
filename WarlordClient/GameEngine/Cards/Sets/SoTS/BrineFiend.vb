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
            Me._races.Add(Race.Mercenary)
            Me._armorClass = 8
            Me._skill = 0
            Me._hitPoints = 2
            Me._alignment = Alignment.Evil
            Me._traits.Add(CharacterTrait.Monster)

        End Sub
    End Class

End Namespace
