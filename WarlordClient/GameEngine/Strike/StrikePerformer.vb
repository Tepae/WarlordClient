Imports WarlordClient.GameEngine.Card
Imports WarlordClient.GameEngine.Strike.Strike

Namespace GameEngine.Strike

    Public Class StrikePerformer

        Private _ge As GameEngine
        Private _source As SmallCard
        Private _target As SmallCard
        Private _strike As Strike
        Private _index As Integer
        Private _exitPoint As Action(Of Integer)

        Public Sub New(ge As GameEngine, source As SmallCard, strike As Strike, index As Integer, exitPoint As Action(Of Integer))
            _ge = ge
            _source = source
            _strike = strike
            _index = index
            _exitPoint = exitPoint
        End Sub

        Public Sub PerformStrike()
            SetFilter()
            SetInfoBoxAndButtons()
        End Sub

        Private Sub SetFilter()
            Dim cf As ClickFilter.ClickFilter = Nothing
            If _strike.StrikeType = StrikeTypeEnum.Melee Then
                cf = DirectCast(_source.Card.Card, IMeleeStriker).GetFilterForMeleeStrike '
            ElseIf _strike.StrikeType = StrikeTypeEnum.Ranged Then
                cf = DirectCast(_source.Card.Card, IRangedStriker).GetFilterForRangedStrike '
            End If
            cf.AddCriteria(New ClickFilter.OwnerFilter(_ge.MyOpponent().Id))
            cf.AddCriteria(New ClickFilter.RangeFilter(_ge.GameState.GetCollectionById(_ge.LocalPlayer.Id).RankAndPlaceOfCharacter(_source.Card).Key, _strike.MinRange, _strike.MaxRange))
            cf.RemoveFilterAfterPositiveEvaluation = True
            _ge.SetFilterForPlayer(cf, AddressOf CharacterChosenForStrike)
        End Sub

        Private Sub SetInfoBoxAndButtons()
            _ge.SetInfoBox(New InfoboxData(String.Format("Choose target for {0} strike ({1}{2})", _strike.StrikeType.ToString, If(_strike.Modifier > -1, "+", String.Empty), _strike.Modifier), _
                                           New ButtonConfiguration(False, True, False, Nothing, AddressOf StrikeCanceled, Nothing)))
        End Sub

        Private Sub CharacterChosenForStrike(sc As SmallCard, owner As Guid, btn As MouseButtons)
            _target = sc
            _ge.RaiseSystemMessage(String.Format("{0} targets {1} with a {2} strike ({3}{4})", _
                                                 _source.Card.Card.Name, _
                                                 _target.Card.Card.Name, _
                                                 _strike.StrikeType.ToString.ToLower, _
                                                 If(_strike.Modifier > -1, "+", String.Empty), _
                                                 _strike.Modifier))
            SpendSource()
            _ge.PerformOrder(New Order.PerformStrike(Guid.NewGuid, _source.Card, _target.Card, _strike))
            _exitPoint.Invoke(_index + 1)
        End Sub

        Private Sub SpendSource()
            Select Case _strike.CharacterStateResult
                Case CharacterStateResultEnum.Spent
                    _source.Card.CardState = CardInstance.State.Spent
                Case CharacterStateResultEnum.Stunned
                    _source.Card.CardState = CardInstance.State.Stunned
            End Select
        End Sub

        Private Sub StrikeCanceled()
            _ge.CancelAction()
        End Sub

    End Class

End Namespace