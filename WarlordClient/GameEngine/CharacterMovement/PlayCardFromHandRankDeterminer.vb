Namespace GameEngine.CharacterMovement

    Public Class PlayFromHandRankDeterminer
        Implements IRanksAvalibleForPlacementDeterminer

        Public Function GetAvalibleRanksForPlacement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer) Implements IRanksAvalibleForPlacementDeterminer.GetAvalibleRanksForPlacement
            Return DirectCast(ci.Card, Card.Character).RanksForPlacement
        End Function

    End Class

End Namespace