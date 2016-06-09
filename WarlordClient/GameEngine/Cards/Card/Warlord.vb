Namespace GameEngine.Cards.Card

    Public MustInherit Class Warlord
        Inherits WlCharacter

        Public Sub New()
            MyBase.New
        End Sub

        Public Overridable Function StartingRanks() As List(Of StartingRank)
            Return GetDefaultStartingRanks()
        End Function

        Public Overridable Function StartsInRankAsWarlord() As Integer
            Return Constants.WarlordDefaultStartingRank
        End Function

        Public Function CharacterCanStartInMyArmy(ch As WlCharacter) As Boolean
            Dim ret = False
            For Each sr As StartingRank In StartingRanks()
                If CharacterMatchesAnyStartingRankCharacterDescription(ch, sr.Traits) Then
                    ret = True
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function CharacterMatchesAnyStartingRankCharacterDescription(ch As WlCharacter, srcds As List(Of StartingRankCharacterDescription)) As Boolean
            Dim ret = False
            For Each srcd As StartingRankCharacterDescription In srcds
                If (ch.Races.Contains(srcd.CharacterRace) OrElse srcd.CharacterRace = RaceEnum.Any) _
                AndAlso (ch.Classes.Contains(srcd.CharacterClassEnum) OrElse srcd.CharacterClassEnum = ClassEnum.Any) _
                AndAlso ch.StartsInRank = srcd.CharacterLevel Then
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
            For Each race As RaceEnum In Races
                Dim srcds As New List(Of StartingRankCharacterDescription)
                srcds.Add(New StartingRankCharacterDescription(ClassEnum.Any, race, rank, Nothing))
                Dim sr As New StartingRank(rank, numberOfChars, srcds)
                ret.Add(sr)
            Next
            Return ret
        End Function

        Private Function GetStartingRankForMyClass(rank As Integer, numberOfChars As Integer) As List(Of StartingRank)
            Dim ret As New List(Of StartingRank)
            For Each c As ClassEnum In Classes
                Dim srcds As New List(Of StartingRankCharacterDescription)
                srcds.Add(New StartingRankCharacterDescription(c, RaceEnum.Any, rank, Nothing))
                Dim sr As New StartingRank(rank, numberOfChars, srcds)
                ret.Add(sr)
            Next
            Return ret
        End Function

        Public Overridable Function Loyalty() As NoLoyaltyPenalty
            Return New NoLoyaltyPenalty(Races, New List(Of ClassEnum), New List(Of CharacterTraitEnum))
        End Function

    End Class

End Namespace



