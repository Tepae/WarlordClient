Namespace Graphics.Hand

    Public Class HandClickEventArgs
        Inherits EventArgs

        Public Owner As Guid
        Public MouseArgs As MouseEventArgs

        Public Sub New(ByVal o As Guid, args As MouseEventArgs)
            MyBase.New()
            Owner = o
            MouseArgs = args
        End Sub

    End Class

End Namespace