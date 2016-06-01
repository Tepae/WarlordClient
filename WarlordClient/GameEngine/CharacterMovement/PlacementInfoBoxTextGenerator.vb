Namespace GameEngine.CharacterMovement

    Public Class PlayFromHandInfoBoxTextGenerator
        Implements IInfoBoxTextGenerator

        Public Function GetText(ci As CardInstance) As Object Implements IInfoBoxTextGenerator.GetText
            Return String.Format("Choose where {0} will enter play", ci.Card.Name)
        End Function

    End Class

End Namespace