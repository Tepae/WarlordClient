Imports WarlordClient.Common
Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.IllegalRank

    Public Class IllegalRankFixer

        Private ReadOnly _gs As GameState
        Private ReadOnly _reentryPoint As Action
        Private ReadOnly _uim As UserInterfaceManipulator = GameEngineObjects.UserInterfaceManipulator

        Public Sub New(gs As GameState, reentryPoint As Action)
            _gs = gs
            _reentryPoint = reentryPoint
        End Sub

        Public Sub PromptPlayerToFixIllegalRank(rank As Integer, plr As Player)
            _uim.RaiseSystemMessage(String.Format("Player {0} has an illegal rank: {1}", plr.Name, rank.ToString))
            _uim.SetInfoBox(New InfoboxData(String.Format("Select a character to fall forward from rank {0}", rank.ToString), New NoUserInputButtonConfiguration))
            SetClickFilterForIllegalRank(rank, plr)
        End Sub

        Private Sub SetClickFilterForIllegalRank(rank As Integer, plr As Player)
            Dim f As New ClickFilter.Filter
            f.Add(New ClickFilter.OwnerFilter(plr.Id))
            f.Add(New ClickFilter.LocationFilter(CardInstance.Location.InPlay))
            f.Add(New ClickFilter.RankFilter(rank))
            f.LogicalOperator = ClickFilter.Filter.LogicalOperatorEnum.And
            _uim.SetFilterForPlayer(New ClickFilter.ClickFilter(f, True), AddressOf CharacterToFallForwardChosen)
        End Sub

        Private Sub CharacterToFallForwardChosen(sc As SmallCard, owner As Guid, btn As MouseButtons)
            Dim cm As New CharacterMover(New Guid, _gs, CharacterPlacementDialogFactory.CreateDialogForIllegalRank(sc, _gs.GetCollectionById(_gs.GetOwnerOfCardInstance(sc.Card)), _reentryPoint), True)
            cm.MoveCharacter()
        End Sub

    End Class

End Namespace