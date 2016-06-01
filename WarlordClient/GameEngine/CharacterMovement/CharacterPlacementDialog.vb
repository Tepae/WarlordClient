Namespace GameEngine.CharacterMovement

    Public Class CharacterPlacementDialog

        Private ReadOnly _ge As IUserInterfaceManipulator
        Private ReadOnly _sc As SmallCard
        Private ReadOnly _range As Integer
        Private ReadOnly _type As PlacementChoice.PlacementTypeEnum
        Private ReadOnly _rankDeterminer As IRanksAvalibleForPlacementDeterminer
        Private ReadOnly _buttonConfiguration As ButtonConfiguration
        Private ReadOnly _infoBoxTextGenerator As IInfoBoxTextGenerator
        Private ReadOnly _cardCollectionToPlaceCharacter As CardCollection

        Public Event PlacementChoicesAvalible(sc As SmallCard, mcs As List(Of PlacementChoice))

        Public Sub New(ge As IUserInterfaceManipulator, sc As SmallCard, cardCollectionToPlaceCharacter As CardCollection, range As Integer, type As PlacementChoice.PlacementTypeEnum, rankDeterminer As IRanksAvalibleForPlacementDeterminer, buttonConfiguration As ButtonConfiguration, infoBoxTextGenerator As IInfoBoxTextGenerator)
            _ge = ge
            _sc = sc
            _cardCollectionToPlaceCharacter = cardCollectionToPlaceCharacter
            _range = range
            _type = type
            _rankDeterminer = rankDeterminer
            _buttonConfiguration = buttonConfiguration
            _infoBoxTextGenerator = infoBoxTextGenerator
        End Sub

        Public Sub ChooseLocationForPlacement()
            DisableAllOtherUserInput()
            SetInfoBox()
            SetupForPlayerInputForPlacement(GetPossiblePlacementChoices)
        End Sub

        Private Sub DisableAllOtherUserInput()
            _ge.SetInactiveFilterForPlayer()
        End Sub

        Private Sub SetInfoBox()
            Dim data As New InfoboxData(_infoBoxTextGenerator.GetText(_sc.Card), _buttonConfiguration)
            _ge.SetInfoBox(data)
        End Sub

        Private Function GetPossiblePlacementChoices() As List(Of PlacementChoice)
            Dim ret As New List(Of PlacementChoice)
            Dim ranks As List(Of Integer) = GetAvalibleRanksForPlacement()
            For Each rank As Integer In ranks
                ret.AddRange(GetMovementChoicesForRank(rank, _sc.Card))
            Next
            Return ret
        End Function

        Private Function GetAvalibleRanksForPlacement() As List(Of Integer)
            Return _rankDeterminer.GetAvalibleRanksForPlacement(_cardCollectionToPlaceCharacter, _sc.Card, _range)
        End Function

        Private Function GetMovementChoicesForRank(rank As Integer, c As CardInstance) As List(Of PlacementChoice)
            Dim ret As New List(Of PlacementChoice)
            Dim charactersInRank As List(Of CardInstance) = _cardCollectionToPlaceCharacter.CharactersInRank(rank)
            If charactersInRank.Count > 0 Then
                If Not _cardCollectionToPlaceCharacter.RankAndPlaceOfCharacter(c).Key = rank Then
                    For i = 0 To charactersInRank.Count - 1 Step 1
                        Dim currentCard As CardInstance = charactersInRank(i)
                        Dim nextCard As CardInstance = If(i < charactersInRank.Count - 1, charactersInRank(i + 1), Nothing)
                        If i = 0 AndAlso Not currentCard.Id = c.Id Then
                            ret.Add(New PlacementChoice(rank, Nothing, currentCard, _type))
                        End If
                        If Not currentCard.Id = c.Id AndAlso (nextCard Is Nothing OrElse Not nextCard.Id = c.Id) Then
                            ret.Add(New PlacementChoice(rank, currentCard, nextCard, _type))
                        End If
                    Next
                End If
            ElseIf charactersInRank.Count = 0 Then
                ret.Add(New PlacementChoice(rank, Nothing, Nothing, _type))
            End If
            Return ret
        End Function

        Private Sub SetupForPlayerInputForPlacement(mcs As List(Of PlacementChoice))
            RaiseEvent PlacementChoicesAvalible(_sc, mcs)
        End Sub

    End Class

End Namespace