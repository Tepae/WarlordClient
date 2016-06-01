Namespace GameEngine

    Public Class Meetattheinn
        Inherits Card.Action

        Public Sub New()

            MyBase.New()

            'card
            Me._name = "Meet at the inn!"
            Me._imagePath = "\images\SotS\meetattheinn.jpg"
            Me._level = 1
            Me._classes.Add([Class].None)

        End Sub
    End Class

End Namespace
