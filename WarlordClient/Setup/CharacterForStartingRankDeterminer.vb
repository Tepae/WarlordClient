Imports WarlordClient.GameEngine.Card
Imports WarlordClient.GameEngine
Imports WarlordClient.GameEngine.Cards.Card

Namespace Setup

    Public Class CharacterForStartingRankDeterminer

        Public Function GetListOfUniqueCharactersEliglibleForThisPlace(dl As Decklist, wl As Warlord, rank As Integer, cc As CardCollection) As List(Of Card)
            Dim ret As New List(Of Card)
            If wl IsNot Nothing Then
                For Each dle As DeckListEntry In dl.Cards
                    If TypeOf (dle.Card) Is WlCharacter _
                        AndAlso wl.CharacterCanStartInMyArmy(dle.Card) _
                        AndAlso rank = dle.Card.StartsInRank _
                        AndAlso Not AllInstancesOfCharacterHasBeenPlaced(dl.GetCardAmount(dle.Card), dle.Card, cc) Then
                        ret.Add(dle.Card)
                    End If
                Next
            End If
            Return ret
        End Function

        Private Function AllInstancesOfCharacterHasBeenPlaced(amount As Integer, c As Card, cc As CardCollection) As Boolean
            Dim count As Integer = 0
            For i As Integer = 0 To cc.RankCount
                For Each ch As CardInstance In cc.CharactersInRank(i)
                    If c.Name.Equals(ch.Card.Name) Then
                        count += 1
                    End If
                Next
            Next
            Return count >= amount
        End Function

    End Class

End Namespace