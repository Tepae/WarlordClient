Namespace GameEngine

    Public Class Throw_
        Inherits Card.Action

        Public Sub New()

            MyBase.New()

            'card
            Me._name = "Throw"
            Me._imagePath = "\images\SotS\throw.jpg"
            Me._level = 1
            Me._classes.Add([Class].Rogue)

        End Sub
    End Class

End Namespace
