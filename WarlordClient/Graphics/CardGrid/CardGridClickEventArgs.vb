Namespace Graphics.CardGrid

    Public Class CardGridClickEventArgs
        Inherits CardGridEventArgs

        Public MouseArgs As MouseEventArgs

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(rank As Integer, place As Integer, owner As Guid)
            MyBase.New(rank, place, owner)
        End Sub

        Public Sub New(rank As Integer, place As Integer, owner As Guid, args As MouseEventArgs)
            MyBase.New(rank, place, owner)
            MouseArgs = args
        End Sub

    End Class

End Namespace
