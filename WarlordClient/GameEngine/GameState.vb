Imports WarlordClient.GameEngine.CharacterMovement
Imports WarlordClient.GameEngine.Hand

Namespace GameEngine

    Public Class GameState

        Private ReadOnly _cards As New List(Of CardCollection)
        Private ReadOnly _discardPiles As New List(Of DiscardPile)
        Public Event CardCollectionChanged(cc As CardCollection)

        Public Sub AddCharacterToRankInPlace(owner As Guid, c As CardInstance, rank As Integer, place As Integer, suppressRedraw As Boolean)
            Dim cc As CardCollection = GetCollectionById(owner)
            If cc IsNot Nothing Then
                c.CardLocation = CardInstance.Location.InPlay
                cc.AddCharacterToRankInPlace(c, rank, place)
                If Not suppressRedraw Then
                    RaiseEvent CardCollectionChanged(cc)
                End If
            End If
        End Sub

        Public Sub AddCharacterToRankFromPlacementChoice(owner As Guid, ci As CardInstance, pc As PlacementChoice)
            Dim cc As CardCollection = GetCollectionById(owner)
            Dim rank As List(Of CardInstance) = cc.CharactersInRank(pc.Rank)
            Dim place As Integer = rank.Count
            If pc.Right IsNot Nothing Then
                For i = 0 To rank.Count - 1 Step 1
                    If rank(i).Id = pc.Right.Id Then
                        place = i
                        Exit For
                    End If
                Next
            End If
            AddCharacterToRankInPlace(owner, ci, pc.Rank, place, False)
        End Sub

        Public Sub MoveCharacter(owner As Guid, c As CardInstance, pc As PlacementChoice)
            Dim cc As CardCollection = GetCollectionById(owner)
            cc.MoveCharacter(c, pc)
            RaiseEvent CardCollectionChanged(cc)
        End Sub

        Public Sub DiscardCardFromHand(ci As CardInstance)
            Dim owner As Guid = GetOwnerOfCardInstance(ci)
            Dim hand As HandModel = HandHolder.GetHandModelForOwner(owner)
            hand.RemoveCard(ci, True)
            GetDiscardPileById(owner).AddToDiscardPile(ci)
        End Sub

        Public Sub PutCardIntoDiscardPile(ci As CardInstance)
            Dim cc As CardCollection = ThisCardInstanceBelongsToCardCollection(ci)
            cc.Remove(ci)
            GetDiscardPileById(cc.Owner).AddToDiscardPile(ci)
            RaiseEvent CardCollectionChanged(cc)
        End Sub

        Public Sub RegisterPlayer(id As Guid)
            _discardPiles.Add(New DiscardPile(id))
        End Sub

        Public Sub RegisterHand(model As HandModel)
            HandHolder.RegisterHandModel(model)
        End Sub

        Public Function GetCollectionById(id As Guid) As CardCollection
            Dim ret As CardCollection = Nothing
            For Each cc As CardCollection In _cards
                If cc.Owner = id Then
                    ret = cc
                    Exit For
                End If
            Next
            If ret Is Nothing Then
                Throw New GameStateOutOfSync(String.Format("Gamestate->GetCollectionById: Tried to access CardCollection with owner {0}, but no such CardCollection exists", id.ToString))
            End If
            Return ret
        End Function

        Public Sub SetCollectionForOwner(ccToSet As CardCollection)
            Dim found As Boolean = False
            For Each cc As CardCollection In _cards
                If cc.Owner = ccToSet.Owner Then
                    'todo switch cc and cctoset
                    found = True
                    Exit For
                End If
            Next
            If Not found Then
                _cards.Add(ccToSet)
            End If
            RaiseEvent CardCollectionChanged(ccToSet)
        End Sub

        Public Sub UnspendAllCharacters(id As Guid)
            Dim cc As CardCollection = GetCollectionById(id)
            Dim cards As List(Of CardInstance) = cc.AllCards
            For Each ci As CardInstance In cards
                ci.Unspend()
            Next
            RaiseEvent CardCollectionChanged(cc)
        End Sub

        Public Function ThisCardInstanceBelongsToCardCollection(ci As CardInstance) As CardCollection
            Dim ret As CardCollection = Nothing
            For Each cc As CardCollection In _cards
                If cc.ContainsCardInstance(ci) Then
                    ret = cc
                    Exit For
                End If
            Next
            If ret Is Nothing Then
                Throw New GameStateOutOfSync(String.Format("Gamestate->ThisCardInstanceBelongsToPlayer: Tried to find owner of card {0}, but failed", ci.ToString))
            End If
            Return ret
        End Function

        Public Function GetFirstIllegalRank(id As Guid) As Integer
            Dim ret As Integer = 0
            Dim cc As CardCollection = GetCollectionById(id)
            For i As Integer = 1 To cc.RankCount - 1
                If cc.CharactersInRank(i).Count < cc.CharactersInRank(i + 1).Count Then
                    ret = i + 1
                    Exit For
                End If
            Next
            Return ret
        End Function

        Private Function GetDiscardPileById(id As Guid) As DiscardPile
            Dim ret As DiscardPile = Nothing
            For Each dp As DiscardPile In _discardPiles
                If dp.Owner = id Then
                    ret = dp
                    Exit For
                End If
            Next
            If ret Is Nothing Then
                Throw New GameStateOutOfSync(String.Format("Gamestate->GetDIscardPileById: Tried to access DiscardPile with owner {0}, but no such DiscardPile exists", id.ToString))
            End If
            Return ret
        End Function

        Public Function GetHandModelById(owner As Guid) As HandModel
            Return HandHolder.GetHandModelForOwner(owner)
        End Function

        Public Function GetOwnerOfCardInstance(ci As CardInstance) As Guid
            Dim ret As Guid = Guid.Empty
            For Each cc As CardCollection In _cards
                If cc.ContainsCardInstance(ci) Then
                    ret = cc.Owner
                End If
            Next
            If ret = Guid.Empty Then
                For Each model As HandModel In HandHolder.Hands
                    If model.Cards.Contains(ci) Then
                        ret = model.Owner
                    End If
                Next
            End If
            Return ret
        End Function

        Private Property HandHolder As Handholder = New Handholder

        Public Class GameStateOutOfSync
            Inherits Exception

            Public Sub New(message As String)
                MyBase.New(message)
            End Sub

        End Class

    End Class

End Namespace