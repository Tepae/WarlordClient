Namespace GameEngine.CharacterMovement

    Public Class StandardPlacementButtonConfiguration
        Inherits ButtonConfiguration

        Public Sub New(ge As GameEngine)
            MyBase.New(False, True, False, Nothing, AddressOf ge.CancelMove, Nothing)
        End Sub

    End Class

End Namespace