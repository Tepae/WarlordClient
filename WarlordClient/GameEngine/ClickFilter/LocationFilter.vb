Namespace GameEngine.ClickFilter

    Public Class LocationFilter
        Implements IFilter

        Private _location As CardInstance.Location

        Public Sub New(owner As CardInstance.Location)
            _location = owner
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Return _location = args.Location Or _location = CardInstance.Location.Any
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("Location = {0}", _location.ToString)
        End Function

    End Class

End Namespace