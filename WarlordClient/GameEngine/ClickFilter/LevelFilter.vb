Namespace GameEngine.ClickFilter

    Public Class LevelFilter
        Implements IFilter

        Private ReadOnly _level As Integer
        Private ReadOnly _comparison As ClickFilter.ComparisonOperatorEnum

        Public Sub New(level As Integer, comparison As ClickFilter.ComparisonOperatorEnum)
            _level = level
            _comparison = comparison
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Dim ret As Boolean = False
            Dim sourceLevel As Integer = args.Source.Card.Level

            Select Case _comparison
                Case ClickFilter.ComparisonOperatorEnum.Equals
                    ret = _level = sourceLevel
                Case ClickFilter.ComparisonOperatorEnum.NotEquals
                    ret = _level <> sourceLevel
                Case ClickFilter.ComparisonOperatorEnum.GreaterThan
                    ret = _level > sourceLevel
                Case ClickFilter.ComparisonOperatorEnum.LesserThan
                    ret = _level < sourceLevel
                Case ClickFilter.ComparisonOperatorEnum.GreaterThanOrEqual
                    ret = _level >= sourceLevel
                Case ClickFilter.ComparisonOperatorEnum.LesserThanOrEqual
                    ret = _level <= sourceLevel
            End Select

            Return ret
        End Function

    End Class

End Namespace