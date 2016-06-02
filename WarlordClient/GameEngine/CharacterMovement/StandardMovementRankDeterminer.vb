Namespace GameEngine.CharacterMovement

    Public Class StandardPlacementRankDeterminer
        Implements IRanksAvalibleForPlacementDeterminer

        Public Function GetAvalibleRanksForPlacement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer) Implements IRanksAvalibleForPlacementDeterminer.GetAvalibleRanksForPlacement
            Dim ret As New List(Of Integer)
            Dim currentRank As Integer = cc.RankAndPlaceOfCharacter(ci).Key
            For i As Integer = 1 To cc.RankCount Step 1
                If i = currentRank Then
                    ret.Add(i)
                ElseIf i < currentRank AndAlso currentRank - range <= i Then
                    ret.Add(i)
                ElseIf i > currentRank AndAlso currentRank + range >= i Then
                    ret.Add(i)
                End If
            Next
            Return ret
        End Function

    End Class

End Namespace

