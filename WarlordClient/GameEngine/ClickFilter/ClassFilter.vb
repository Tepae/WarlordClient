Namespace GameEngine.ClickFilter

    Public Class ClassFilter
        Implements IFilter

        Private ReadOnly _c As Cards.Card.Card.ClassEnum

        Public Sub New(c As Cards.Card.Card.ClassEnum)
            _c = c
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Return args.Source.Card.Classes.Contains(_c)
        End Function

    End Class

End Namespace