Namespace GameEngine.Strike

    Public Class MeleeStrike
        Inherits Strike

        Public Sub New(modifier As Integer)
            MyBase.New(StrikeTypeEnum.Melee, modifier, 1, 1, CharacterStateResultEnum.Spent)
        End Sub

    End Class

End Namespace