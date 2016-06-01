Namespace GameEngine.CharacterMovement

    Public Interface IRanksAvalibleForPlacementDeterminer

        Function GetAvalibleRanksForPlacement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer)

    End Interface

End Namespace
