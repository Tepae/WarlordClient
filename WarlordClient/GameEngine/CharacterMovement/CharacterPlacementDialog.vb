Namespace GameEngine.CharacterMovement

    Public Class CharacterPlacementDialog

        Private ReadOnly _uim As UserInterfaceManipulator
        Private ReadOnly _sc As SmallCard
        Private ReadOnly _range As Integer
        Private ReadOnly _excludeOwnRank As Boolean
        Private ReadOnly _rankDeterminer As IRanksAvailableForPlacementDeterminer
        Private ReadOnly _buttonConfiguration As ButtonConfiguration
        Private ReadOnly _infoBoxTextGenerator As IInfoBoxTextGenerator
        Private ReadOnly _cardCollectionToPlaceCharacter As CardCollection

        Public Event PlacementChoicesAvailable(sc As SmallCard, mcs As List(Of PlacementChoice))

        Public Sub New(uim As UserInterfaceManipulator, sc As SmallCard, cardCollectionToPlaceCharacter As CardCollection, range As Integer, excludeOwnRank As Boolean, type As PlacementChoice.PlacementTypeEnum, rankDeterminer As IRanksAvailableForPlacementDeterminer, buttonConfiguration As ButtonConfiguration, infoBoxTextGenerator As IInfoBoxTextGenerator)
            _uim = uim
            _sc = sc
            _cardCollectionToPlaceCharacter = cardCollectionToPlaceCharacter
            _range = range
            _excludeOwnRank = excludeOwnRank
            PlacementType = type
            _rankDeterminer = rankDeterminer
            _buttonConfiguration = buttonConfiguration
            _infoBoxTextGenerator = infoBoxTextGenerator
        End Sub

        Public Property PlacementType As PlacementChoice.PlacementTypeEnum

        Public Sub ChooseLocationForPlacement()
            DisableAllOtherUserInput()
            SetInfoBox()
            SetupForPlayerInputForPlacement(GetPossiblePlacementChoices)
        End Sub

        Private Sub DisableAllOtherUserInput()
            _uim.SetInactiveFilterForPlayer()
        End Sub

        Private Sub SetInfoBox()
            Dim data As New InfoboxData(_infoBoxTextGenerator.GetText(_sc.Card), _buttonConfiguration)
            _uim.SetInfoBox(data)
        End Sub

        Private Function GetPossiblePlacementChoices() As List(Of PlacementChoice)
            Dim ret As New List(Of PlacementChoice)
            Dim ranks As List(Of Integer) = GetAvailableRanksForPlacement()
            For Each rank As Integer In ranks
                ret.AddRange(GetPlacementChoices(rank, _sc.Card))
            Next
            Return ret
        End Function

        Private Function GetAvailableRanksForPlacement() As List(Of Integer)
            Return _rankDeterminer.GetAvailableRanksForMovement(_cardCollectionToPlaceCharacter, _sc.Card, _range)
        End Function

        Private Function GetPlacementChoices(rank As Integer, c As CardInstance) As List(Of PlacementChoice)
            Dim ret As New List(Of PlacementChoice)
            Dim charactersInRank As List(Of CardInstance) = _cardCollectionToPlaceCharacter.CharactersInRank(rank)
            If (Not (_excludeOwnRank AndAlso rank = _cardCollectionToPlaceCharacter.RankAndPlaceOfCharacter(c).Key)) AndAlso charactersInRank.Count > 0 Then
                For i = 0 To charactersInRank.Count - 1 Step 1
                    Dim currentCard As CardInstance = charactersInRank(i)
                    Dim nextCard As CardInstance = If(i < charactersInRank.Count - 1, charactersInRank(i + 1), Nothing)
                    If i = 0 AndAlso Not currentCard.Id = c.Id Then
                        ret.Add(New PlacementChoice(rank, Nothing, currentCard, PlacementType))
                    End If
                    If Not currentCard.Id = c.Id AndAlso (nextCard Is Nothing OrElse Not nextCard.Id = c.Id) Then
                        ret.Add(New PlacementChoice(rank, currentCard, nextCard, PlacementType))
                    End If
                Next
            ElseIf charactersInRank.Count = 0 Then
                ret.Add(New PlacementChoice(rank, Nothing, Nothing, PlacementType))
            End If
            Return ret
        End Function

        Private Sub SetupForPlayerInputForPlacement(mcs As List(Of PlacementChoice))
            RaiseEvent PlacementChoicesAvailable(_sc, mcs)
        End Sub

    End Class

End Namespace