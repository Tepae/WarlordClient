Namespace GameEngine.CharacterMovement

    Public Class IllegalRankMovementRankDeterminer
        Implements IRanksAvalibleForPlacementDeterminer

        Public Function GetAvalibleRanksForMovement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer) Implements IRanksAvalibleForPlacementDeterminer.GetAvalibleRanksForPlacement
            Return New List(Of Integer) From {cc.RankAndPlaceOfCharacter(ci).Key - 1}
        End Function

    End Class

End Namespace