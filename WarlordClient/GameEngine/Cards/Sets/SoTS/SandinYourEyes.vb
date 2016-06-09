Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    Public Class SandinYourEyes
        Inherits WlAction

        Public Sub New()

            MyBase.New()

            'card
            _name = "Sand in Your Eyes"
            _imagePath = "\images\SotS\sandinyoureyes.jpg"
            _level = 1
            _classes.Add(ClassEnum.Rogue)

        End Sub

        Public Overrides Sub Perform(gs As GameState, source As SmallCard)
            Throw New NotImplementedException()
        End Sub

        Protected Overrides Sub Setup()
            'Throw New NotImplementedException()
        End Sub

    End Class

End Namespace
