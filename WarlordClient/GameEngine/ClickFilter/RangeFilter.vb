Namespace GameEngine.ClickFilter

    Public Class RangeFilter
        Implements IFilter

        Private _rank As Integer = -1
        Private _minRange As Integer = Integer.MinValue
        Private _maxRange As Integer = Integer.MaxValue

        Public Sub New(rank As Integer, minRange As Integer, maxRange As Integer)
            _rank = rank
            _minRange = minRange
            _maxRange = maxRange
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Return _minRange >= (_rank - 1) + args.Rank AndAlso _maxRange <= (_rank - 1) + args.Rank
        End Function

        Public Overrides Function ToString() As String
            Dim ret As String = String.Empty
            If _minRange = _maxRange Then
                ret = String.Format("Range = {0}", _minRange)
            Else
                ret = String.Format("Range between {0} and {1}", _minRange, _maxRange)
            End If
            Return ret
        End Function

    End Class

End Namespace