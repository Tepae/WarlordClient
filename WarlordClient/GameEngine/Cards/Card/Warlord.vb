Namespace GameEngine.Card

    Public MustInherit Class Warlord
        Inherits Character

        Public Overridable Function StartingRanks() As List(Of StartingRank)
            Return GetDefaultStartingRanks()
        End Function

        Public Overridable Function StartsInRankAsWarlord() As Integer
            Return Constants.WarlordDefaultStartingRank
        End Function

        Public Function CharacterCanStartInMyArmy(c As Character) As Boolean
            Dim ret As Boolean = False
            For Each sr As StartingRank In StartingRanks()
                If CharacterMatchesAnyStartingRankCharacterDescription(c, sr.Traits) Then
                    ret = True
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function CharacterMatchesAnyStartingRankCharacterDescription(c As Character, srcds As List(Of StartingRankCharacterDescription)) As Boolean
            Dim ret As Boolean = False
            For Each srcd As StartingRankCharacterDescription In srcds
                If (c.Races.Contains(srcd.CharacterRace) OrElse srcd.CharacterRace = RaceEnum.Any) _
                AndAlso (c.Classes.Contains(srcd.CharacterClass) OrElse srcd.CharacterClass = [Class].Any) _
                AndAlso c.StartsInRank = srcd.CharacterLevel Then
                    ret = True
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function GetDefaultStartingRanks() As List(Of StartingRank)
            Dim ret As New List(Of StartingRank)
            ret.AddRange(GetStartingRankForMyRace(1, 3))
            ret.AddRange(GetStartingRankForMyRace(2, 2))
            Return ret
        End Function

        Private Function GetStartingRankForMyRace(rank As Integer, numberOfChars As Integer) As List(Of StartingRank)
            Dim ret As New List(Of StartingRank)
            For Each r As RaceEnum In Me.Races
                Dim traits As New List(Of StartingRankCharacterDescription)
                traits.Add(New StartingRankCharacterDescription([Class].Any, r, rank, Nothing))
                Dim sr As New StartingRank(rank, numberOfChars, traits)
                ret.Add(sr)
            Next
            Return ret
        End Function

        Private Function GetStartingRankForMyClass(rank As Integer, numberOfChars As Integer) As List(Of StartingRank)
            Dim ret As New List(Of StartingRank)
            For Each c As [Class] In Me.Classes
                Dim traits As New List(Of StartingRankCharacterDescription)
                traits.Add(New StartingRankCharacterDescription(c, RaceEnum.Any, rank, Nothing))
                Dim sr As New StartingRank(rank, numberOfChars, traits)
                ret.Add(sr)
            Next
            Return ret
        End Function

    End Class

End Namespace



