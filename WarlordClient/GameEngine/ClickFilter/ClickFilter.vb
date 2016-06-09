Namespace GameEngine.ClickFilter

    Public Class ClickFilter

        Private _filter As Filter

        Public Sub New(filter As Filter, removeFilterAfterPositiveEvaluation As Boolean)
            _filter = filter
            Me.RemoveFilterAfterPositiveEvaluation = removeFilterAfterPositiveEvaluation
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean
            Return _filter.Evaluate(args)
        End Function

        Public Sub AddCriteria(f As IFilter)
            _filter.Add(f)
        End Sub

        Public Property RemoveFilterAfterPositiveEvaluation As Boolean

        Public Enum ComparisonOperatorEnum
            Equals
            NotEquals
            GreaterThan
            LesserThan
            GreaterThanOrEqual
            LesserThanOrEqual
        End Enum

    End Class

End Namespace