﻿Namespace GameEngine.CharacterMovement

    Public Class StandardPlacementButtonConfiguration
        Inherits ButtonConfiguration

        Public Sub New(cancelAction As Action)
            MyBase.New(False, True, False, Nothing, cancelAction, Nothing)
        End Sub

    End Class

End Namespace