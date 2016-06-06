Namespace GameEngine.CharacterMovement

    Public Class PlayFromHandRankDeterminer
        Implements IRanksAvailableForPlacementDeterminer

        Public Function GetAvailableRanksForMovement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer) Implements IRanksAvailableForPlacementDeterminer.GetAvailableRanksForMovement
            Return DirectCast(ci.Card, Card.Character).RanksForPlacement
        End Function

    End Class

End Namespace