Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.CostAndEffect
Imports WarlordClient.GameEngine.CostAndEffect.Effect
Imports WarlordClient.GameEngine.Strike

' ReSharper disable once CheckNamespace
Namespace GameEngine

    ' ReSharper disable once InconsistentNaming
    ' ReSharper disable once UnusedMember.Global
    Public Class Throw_
        Inherits WlAction

        Public Sub New()

            MyBase.New()

            'card
            _name = "Throw"
            _imagePath = "\images\SotS\throw.jpg"
            _level = 1
            _classes.Add(ClassEnum.Rogue)

        End Sub

        Protected Overrides Sub Setup()
            Effects.Add(New PerformStrikeEffect(New StrikeSet(False, StrikeSet.TargetingTypeEnum.Consecutive, New RangedStrike(2))))
        End Sub

    End Class

End Namespace
