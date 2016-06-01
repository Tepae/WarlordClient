Namespace GameEngine

    Public Class SandinYourEyes
        Inherits Card.Action

        Public Sub New()

            MyBase.New()

            'card
            Me._name = "Sand in Your Eyes"
            Me._imagePath = "\images\SotS\sandinyoureyes.jpg"
            Me._level = 1
            Me._classes.Add([Class].Rogue)

        End Sub
    End Class

End Namespace
