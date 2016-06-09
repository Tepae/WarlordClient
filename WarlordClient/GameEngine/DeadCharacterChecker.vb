Imports WarlordClient.Common
Imports WarlordClient.GameEngine.Cards.Card

Namespace GameEngine

    Public Class DeadCharacterChecker

        Public Function GetDeadCharacters(ge As GameEngineGameEngine, players As PlayerList) As List(Of CardInstance)
            Dim ret As New List(Of CardInstance)
            For Each plr As Player In players.Players
                Dim cc As CardCollection = ge.GameState.GetCollectionById(plr.Id)
                For Each ci As CardInstance In cc.AllCards
                    If ci.Card.GetType.IsSubclassOf(GetType(WlCharacter)) Then
                        If ci.Wounds >= DirectCast(ci.Card, WlCharacter).HitPoints Then
                            ret.Add(ci)
                        End If
                    End If
                Next
            Next
            Return ret
        End Function

    End Class

End Namespace