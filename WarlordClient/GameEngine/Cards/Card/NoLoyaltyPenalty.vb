Imports WarlordClient.GameEngine.Card

Namespace GameEngine.Cards.Card

    Public Class NoLoyaltyPenalty

        Private ReadOnly _races As List(Of WlCharacter.RaceEnum)
        Private ReadOnly _classes As List(Of Global.WarlordClient.GameEngine.Cards.Card.Card.ClassEnum)
        Private ReadOnly _traits As List(Of WlCharacter.CharacterTraitEnum)

        Public Sub New(races As List(Of WlCharacter.RaceEnum), classes As List(Of Global.WarlordClient.GameEngine.Cards.Card.Card.ClassEnum), traits As List(Of WlCharacter.CharacterTraitEnum))
            _races = races
            _classes = classes
            _traits = traits
        End Sub

        Public Function CharacterSuffersPenalty(c As WlCharacter) As Boolean
            Return Not RaceReducesPenalty(c) AndAlso Not ClassReducesPenalty(c) AndAlso Not TraitReducesPenalty(c) AndAlso Not IsMercenary(c)
        End Function

        Private Function RaceReducesPenalty(c As WlCharacter) As Boolean
            Dim ret As Boolean = False
            For Each r1 As WlCharacter.RaceEnum In _races
                For Each r2 As WlCharacter.RaceEnum In c.Races
                    If r1 = r2 Then
                        ret = True
                    End If
                Next
                If ret Then
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function IsMercenary(c As WlCharacter) As Boolean
            Return c.Races.Contains(WlCharacter.RaceEnum.Mercenary)
        End Function

        Private Function ClassReducesPenalty(c As WlCharacter) As Boolean
            Dim ret As Boolean = False
            For Each c1 As Global.WarlordClient.GameEngine.Cards.Card.Card.ClassEnum In _classes
                For Each c2 As Global.WarlordClient.GameEngine.Cards.Card.Card.ClassEnum In c.Classes
                    If c1 = c2 Then
                        ret = True
                    End If
                Next
                If ret Then
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function TraitReducesPenalty(c As WlCharacter) As Boolean
            Dim ret As Boolean = False
            For Each t1 As WlCharacter.CharacterTraitEnum In _traits
                For Each t2 As WlCharacter.CharacterTraitEnum In c.Traits
                    If t1 = t2 Then
                        ret = True
                    End If
                Next
                If ret Then
                    Exit For
                End If
            Next
            Return ret
        End Function

    End Class

End Namespace