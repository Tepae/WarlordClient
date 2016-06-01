Namespace GameEngine.CharacterMovement

    Public Class PlacementInfoBoxTextGenerator
        Implements IInfoBoxTextGenerator

        Public Function GetText(ci As CardInstance) As Object Implements IInfoBoxTextGenerator.GetText
            Return String.Format("Choose where to move {0}", ci.Card.Name)
        End Function

    End Class

End Namespace