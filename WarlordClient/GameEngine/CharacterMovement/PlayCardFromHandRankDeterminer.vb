Imports WarlordClient.GameEngine.Cards.Card

Namespace GameEngine.CharacterMovement

    Public Class PlayFromHandRankDeterminer
        Implements IRanksAvailableForPlacementDeterminer

        Public Function GetAvailableRanksForMovement(cc As CardCollection, ci As CardInstance, range As Integer) As List(Of Integer) Implements IRanksAvailableForPlacementDeterminer.GetAvailableRanksForMovement
            Dim ch = DirectCast(ci.Card, WlCharacter)
            Dim penalty As Boolean = DirectCast(cc.Warlord().Card, Warlord).Loyalty().CharacterSuffersPenalty(ch)
            Dim ranks As List(Of Integer) = ch.RanksForPlacement()
            If penalty Then
                For i = 0 To ranks.Count - 1
                    ranks(i) += 1
                Next
            End If
            Return ranks
        End Function

    End Class

End Namespace