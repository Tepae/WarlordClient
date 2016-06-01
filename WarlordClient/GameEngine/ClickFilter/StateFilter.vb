Namespace GameEngine.ClickFilter

    Public Class StateFilter
        Implements IFilter

        Private _state As CardInstance.State

        Public Sub New(owner As CardInstance.State)
            _state = owner
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Return _state = args.State Or _state = CardInstance.State.Any
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("State = {0}", _state.ToString)
        End Function

    End Class

End Namespace