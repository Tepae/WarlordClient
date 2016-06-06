Namespace GameEngine.CharacterMovement

    Public Class IllegalRankMovementRankDeterminer
        Implements IRanksAvailableForPlacementDeterminer

        Public Function GetAvailableRanksForMovement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer) Implements IRanksAvailableForPlacementDeterminer.GetAvailableRanksForMovement
            Return New List(Of Integer) From {cc.RankAndPlaceOfCharacter(ci).Key - 1}
        End Function

    End Class

End Namespace