Namespace GameEngine
    Public Class IllegalRankButtonConfiguration
        Inherits ButtonConfiguration

        Public Sub New(ge As GameEngine)
            MyBase.New(False, True, False, Nothing, AddressOf ge.CheckIllegalRanks, Nothing)
        End Sub

    End Class
End Namespace