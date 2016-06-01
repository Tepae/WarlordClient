Namespace GameEngine.Strike

    Public Class RangedStrike
        Inherits Strike

        Public Sub New(modifier As Integer)
            MyBase.New(StrikeTypeEnum.Ranged, modifier, 2, 2, CharacterStateResultEnum.Spent)
        End Sub

        Public Sub New(modifier As Integer, maxRange As Integer)
            MyBase.New(StrikeTypeEnum.Melee, modifier, 2, maxRange, CharacterStateResultEnum.Spent)
        End Sub

    End Class

End Namespace