Imports WarlordClient.GameEngine.Cards.Card

' ReSharper disable once CheckNamespace
Namespace GameEngine

    Public Class Meetattheinn
        Inherits WlAction

        Public Sub New()

            MyBase.New()

            'card
            _name = "Meet at the inn!"
            _imagePath = "\images\SotS\meetattheinn.jpg"
            _level = 1
            _classes.Add(ClassEnum.None)

        End Sub

        Public Overrides Sub Perform(gs As GameState, source As SmallCard)

        End Sub

        Protected Overrides Sub Setup()
            ' Throw New NotImplementedException()
        End Sub

    End Class

End Namespace
