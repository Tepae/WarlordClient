Namespace GameEngine.CharacterMovement

    Public Interface IRanksAvailableForPlacementDeterminer

        Function GetAvailableRanksForMovement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer)

    End Interface

End Namespace
