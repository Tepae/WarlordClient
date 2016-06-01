Namespace GameEngine.ClickFilter

    Public Class RankFilter
        Implements IFilter

        Private _rank As Integer = -1

        Public Sub New(rank As Integer) '
            _rank = rank
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Return _rank = args.Rank Or _rank = -1
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("Rank = {0}", _rank.ToString)
        End Function


    End Class

End Namespace