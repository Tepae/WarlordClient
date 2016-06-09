Namespace GameEngine

    Public Class CardCollection

#Region "members"

        Private _cards As Dictionary(Of Integer, List(Of CardInstance))
        Private _owner As Guid

#End Region

#Region "ctor"

        Public Sub New(owner As Guid)
            _owner = owner
            _cards = New Dictionary(Of Integer, List(Of CardInstance))
        End Sub

#End Region

#Region "gets"

        Public Function RankCount() As Integer
            Return _cards.Keys.Count
        End Function

        Public Function CharactersInRank(rank As Integer) As List(Of CardInstance)
            Dim ret As New List(Of CardInstance)
            If _cards.ContainsKey(rank) Then
                ret = _cards(rank)
            End If
            Return ret
        End Function

        Public Function RankAndPlaceOfCharacter(c As CardInstance) As KeyValuePair(Of Integer, Integer)
            If c.AttachedTo IsNot Nothing Then
                Return RankAndPlaceOfCharacter(c.AttachedTo)
            End If
            Dim ret As KeyValuePair(Of Integer, Integer) = Nothing
            For Each rank As Integer In _cards.Keys
                For Each ci As CardInstance In _cards(rank)
                    If ci.Id = c.Id Then
                        ret = New KeyValuePair(Of Integer, Integer)(rank, _cards(rank).IndexOf(ci))
                        Exit For
                    End If
                Next
            Next
            Return ret
        End Function

        Public Function ContainsDummies() As Boolean
            Dim ret As Boolean = False
            For Each rank As Integer In Me._cards.Keys
                For Each c As CardInstance In _cards(rank)
                    If c.Card.IsDummy Then
                        ret = True
                        Exit For
                    End If
                Next
                If ret Then
                    Exit For
                End If
            Next
            Return ret
        End Function

        Public Function GetAmountOfCharacterInRanks(c As Global.WarlordClient.GameEngine.Cards.Card.Card) As Integer
            Dim ret As Integer = 0
            For Each rank As Integer In Me._cards.Keys
                For Each ci As CardInstance In _cards(rank)
                    If ci.Card.Name.Equals(c.Name) Then
                        ret += 1
                    End If
                Next
            Next
            Return ret
        End Function

        Public Function CharacterIsInLastRank(ci As CardInstance) As Boolean
            Return _cards(GetLastRankNumber).Contains(ci)
        End Function

        Public Function GetLastRankNumber() As Integer
            Dim ret As Integer = 0
            For Each key As Integer In _cards.Keys
                If key > ret Then
                    ret = key
                End If
            Next
            Return ret
        End Function

        Public Function ContainsCardInstance(ci As CardInstance) As Boolean
            Dim ret As Boolean = False
            For Each rank As Integer In _cards.Keys
                For Each instance As CardInstance In _cards(rank)
                    If ci.Id = instance.Id OrElse IsAttachedTo(instance, ci) Then
                        ret = True
                        Exit For
                    End If
                Next
                If ret Then
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function IsAttachedTo(cardToCheckForAttachments As CardInstance, cardToCheckFor As CardInstance) As Boolean
            Dim ret As Boolean = False
            For Each attachment As CardInstance In cardToCheckForAttachments.Attachments
                If attachment.Id = cardToCheckFor.Id Then
                    ret = True
                    Exit For
                End If
            Next
            Return ret
        End Function

        Public Function HasACharacterAt(rank As Integer, place As Integer) As Boolean
            Dim ret As Boolean = True
            If Not _cards.Keys.Contains(rank) Then
                ret = False
            End If
            If Not (ret AndAlso _cards(rank).Count > place) Then
                ret = False
            End If
            Return ret
        End Function

        Public Function AllCards() As List(Of CardInstance)
            Dim ret As New List(Of CardInstance)
            For i As Integer = 0 To RankCount() Step 1
                ret.AddRange(CharactersInRank(i))
            Next
            Return ret
        End Function

        Public Function Warlord() As CardInstance
            Dim ret As CardInstance = Nothing
            For Each ci As CardInstance In AllCards()
                If ci.Warlord Then
                    ret = ci
                    Exit For
                End If
            Next
            Return ret
        End Function

#End Region

#Region "manipulation"

        Public Sub AddCharacterToRank(c As CardInstance, rank As Integer)
            AddCharacterToRankInPlace(c, rank, 0)
        End Sub

        Public Sub AddCharacterToRankInPlace(ci As CardInstance, rank As Integer, place As Integer)
            If Not _cards.ContainsKey(rank) Then
                _cards.Add(rank, New List(Of CardInstance))
            End If
            _cards(rank).Insert(place, ci)
        End Sub

        Public Sub MoveCharacter(ci As CardInstance, mc As CharacterMovement.PlacementChoice)
            If ContainsCardInstance(ci) Then
                Dim rank As List(Of CardInstance) = _cards(mc.Rank)
                If mc.Left Is Nothing Then
                    Remove(ci)
                    AddCharacterToRankInPlace(ci, mc.Rank, 0)
                ElseIf mc.Right Is Nothing Then
                    Remove(ci)
                    AddCharacterToRankInPlace(ci, mc.Rank, rank.Count)
                Else
                    Remove(ci)
                    AddCharacterToRankInPlace(ci, mc.Rank, RankAndPlaceOfCharacter(mc.Left).Value + 1)
                End If
            End If
        End Sub

        Public Sub Replace(old As CardInstance, [new] As CardInstance)
            For Each rank As Integer In _cards.Keys
                For Each ci As CardInstance In _cards(rank)
                    If ci.Id = old.Id Then
                        _cards(rank).Item(_cards(rank).IndexOf(old)) = [new]
                        Exit For
                    End If
                Next
            Next
        End Sub

        Public Sub Replace([new] As CardInstance, rankOfOldCharacter As Integer, placeOfOldCharacter As Integer)
            _cards(rankOfOldCharacter)(placeOfOldCharacter) = [new]
        End Sub

        Public Sub Remove(ci As CardInstance)
            For Each rank As List(Of CardInstance) In _cards.Values
                Dim toDelete As CardInstance = Nothing
                For Each c As CardInstance In rank
                    If c.Id = ci.Id Then
                        toDelete = c
                    End If
                Next
                If toDelete IsNot Nothing Then
                    rank.Remove(toDelete)
                    Exit For
                End If
            Next
        End Sub

        Public Sub Clear()
            For Each key As Integer In _cards.Keys
                _cards(key).Clear()
            Next
        End Sub

#End Region

#Region "properties"

        Public Property Owner As Guid
            Get
                Return _owner
            End Get
            Set(value As Guid)
                _owner = value
            End Set
        End Property

#End Region

    End Class

End Namespace