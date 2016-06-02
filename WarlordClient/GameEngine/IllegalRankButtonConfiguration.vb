Namespace GameEngine
    Public Class IllegalRankButtonConfiguration
        Inherits ButtonConfiguration

        Public Sub New(cancelAction As Action)
            MyBase.New(False, True, False, Nothing, cancelAction, Nothing)
        End Sub

    End Class
End Namespace