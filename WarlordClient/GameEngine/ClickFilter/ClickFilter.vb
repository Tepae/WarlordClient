Namespace GameEngine.ClickFilter

    Public Class ClickFilter

        Private _filter As Filter
        Private _removeFilterAfterPositiveEvaluation As Boolean

        Public Sub New(filter As Filter, removeFilterAfterPositiveEvaluation As Boolean)
            _filter = filter
            _removeFilterAfterPositiveEvaluation = removeFilterAfterPositiveEvaluation
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean
            Return _filter.Evaluate(args)
        End Function

        Public Sub AddCriteria(f As IFilter)
            _filter.Add(f)
        End Sub

        Public Property RemoveFilterAfterPositiveEvaluation As Boolean
            Get
                Return _removeFilterAfterPositiveEvaluation
            End Get
            Set(value As Boolean)
                _removeFilterAfterPositiveEvaluation = value
            End Set
        End Property

    End Class

End Namespace