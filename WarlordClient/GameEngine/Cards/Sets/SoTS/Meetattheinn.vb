Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect.Effect

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
            _classes.Add(ClassEnum.Any)

        End Sub

        Protected Overrides Sub Setup()
            Effects.Add(New DrawCardEffect(2))
            Effects.Add(New EffectPlayedByOpponent(New DrawCardEffect(1)))
        End Sub

    End Class

End Namespace
