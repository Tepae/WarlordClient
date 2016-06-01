Namespace Graphics.CardGrid

    Public Class CardGridEventArgs
        Inherits EventArgs

        Public CardIsInRank As Integer = -1
        Public CardIsInPlace As Integer = -1
        Public Owner As Guid

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(rank As Integer, place As Integer, id As Guid)
            MyBase.New()
            CardIsInRank = rank
            CardIsInPlace = place
            Owner = id
        End Sub

    End Class

End Namespace