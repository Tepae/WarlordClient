Imports WarlordClient.GameEngine.Cards.Card
Imports WarlordClient.GameEngine.RespondableAction

Namespace GameEngine.Strike

    Public Class StrikePerformer

        Private ReadOnly _id As Guid
        Private ReadOnly _owner As Guid
        Private ReadOnly _source As SmallCard
        Private ReadOnly _gs As GameState
        Private ReadOnly _s As Strike
        Private ReadOnly _nextStrike As Action
        Private ReadOnly _cancelAction As Action
        Private ReadOnly _isFirst As Boolean
        Private ReadOnly _isLast As Boolean
        Private ReadOnly _uim As UserInterfaceManipulator = GameEngineObjects.UserInterfaceManipulator

        Public Sub New(id As Guid, owner As Guid, source As SmallCard, gs As GameState, s As Strike, nextStrike As Action, cancelAction As Action, isFirst As Boolean, isLast As Boolean)
            _id = id
            _owner = owner
            _source = source
            _gs = gs
            _s = s
            _nextStrike = nextStrike
            _cancelAction = cancelAction
            _isFirst = isFirst
            _isLast = isLast
        End Sub

        Public Sub Perform()
            SetFilter()
            SetInfoBox()
        End Sub

        Private Sub SetFilter()
            Select Case _s.StrikeType
                Case Strike.StrikeTypeEnum.Melee
                    _uim.SetFilterForPlayer(DirectCast(_source.Card.Card, WlCharacter).GetFilterForMeleeStrike(), AddressOf TargetChosen)
                Case Strike.StrikeTypeEnum.Ranged
                    _uim.SetFilterForPlayer(DirectCast(_source.Card.Card, WlCharacter).GetFilterForRangedStrike(), AddressOf TargetChosen)
                Case Strike.StrikeTypeEnum.Special
                    _uim.SetFilterForPlayer(_s.Filter, AddressOf TargetChosen)
            End Select
        End Sub

        Private Sub SetInfoBox()
            Dim prompt As String = String.Format("Select target for {0} strike ({1}{2})", _s.StrikeType.ToString().ToLower(), If(_s.Modifier > -1, "+", "-"), _s.Modifier.ToString())
            If _isFirst Then
                _uim.SetInfoBox(New InfoboxData(prompt, New StandardUserInputNeededButtonConfiguration(_cancelAction)))
            Else
                _uim.SetInfoBox(New InfoboxData(prompt, New NoUserInputButtonConfiguration))
            End If
        End Sub

        Private Sub TargetChosen(sc As SmallCard, owner As Guid, btn As MouseButtons)
            Dim op As New RespondableActionPerformer(_owner, _gs)
            op.Perform(New PerformStrike(_id, _source, sc, _s), _isLast, _nextStrike)
        End Sub

    End Class

End Namespace