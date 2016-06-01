Namespace GameEngine.ClickFilter

    Public Class OwnerFilter
        Implements IFilter

        Private _owner As Guid

        Public Sub New(owner As Guid)
            _owner = owner
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Return _owner = args.Owner
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("Owner = {0}", _owner.ToString)
        End Function

    End Class

End Namespace