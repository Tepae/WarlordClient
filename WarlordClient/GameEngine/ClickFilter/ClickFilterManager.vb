Imports WarlordClient.Graphics.Hand
Imports WarlordClient.Graphics.CardGrid

Namespace GameEngine.ClickFilter

    Public Class ClickFilterManager

        Private _ge As GameEngineGameEngine
        Private ReadOnly _filters As New Stack(Of ClickFilter)

        Public Delegate Sub Callback(sc As SmallCard, owner As Guid, btn As MouseButtons)
        Public Event LeftClickInHand(sender As Object, e As HandClickEventArgs)
        Public Event LeftClickInPlay(sender As Object, e As CardGridClickEventArgs)
        Public Event RightClickInHand(sender As Object, e As HandClickEventArgs)
        Public Event RightClickInPlay(sender As Object, e As CardGridClickEventArgs)

        Public Sub New(ge As GameEngineGameEngine)
            _ge = ge
        End Sub

        Public Sub SetActivePlayerFilter(id As Guid)
            Clear()
            Dim f As New Filter()
            f.Add(New OwnerFilter(id))
            f.Add(New LocationFilter(CardInstance.Location.Any))
            f.Add(New StateFilter(CardInstance.State.Any))
            f.LogicalOperator = Filter.LogicalOperatorEnum.And
            _filters.Push(New ClickFilter(f, False))
        End Sub

        Public Sub SetInactiveFilter()
            Clear()
            Dim f As New Filter()
            f.Add(New OwnerFilter(Guid.Empty))
            f.Add(New LocationFilter(CardInstance.Location.Any))
            f.Add(New StateFilter(CardInstance.State.Any))
            f.LogicalOperator = Filter.LogicalOperatorEnum.And
            _filters.Push(New ClickFilter(f, False))
        End Sub

        Private Sub Clear()
            _filters.Clear()
            CallBackForClick = Nothing
        End Sub

        Public Sub SetFilter(cf As ClickFilter, cb As Callback)
            _filters.Push(cf)
            CallBackForClick = cb
        End Sub

        Private Function EvaluateClick(args As FilterArguments) As Boolean
            Dim ret As Boolean = False
            Dim filter As ClickFilter = Nothing
            If _filters.Count > 0 Then
                filter = _filters.Peek
                ret = filter.Evaluate(args)
            End If
            If ret AndAlso Not filter Is Nothing AndAlso filter.RemoveFilterAfterPositiveEvaluation Then
                _filters.Pop()
            End If
            Return ret
        End Function

        Public Sub HandleCardInHandClicked(sender As Object, e As HandClickEventArgs)
            If EvaluateClick(GetFilterArguments(e.Owner, DirectCast(sender, SmallCard).Card)) Then
                If CallBackForClick Is Nothing Then
                    Select Case e.MouseArgs.Button
                        Case MouseButtons.Left
                            RaiseEvent LeftClickInHand(sender, e)
                        Case MouseButtons.Right
                            RaiseEvent RightClickInHand(sender, e)
                    End Select
                ElseIf CallBackForClick IsNot Nothing Then
                    CallBackForClick.Invoke(DirectCast(sender, SmallCard), e.Owner, e.MouseArgs.Button)
                End If
            End If
        End Sub

        Public Sub HandleCardInPlayClicked(sender As Object, e As CardGridClickEventArgs)
            If EvaluateClick(GetFilterArguments(e.Owner, DirectCast(sender, SmallCard).Card)) Then
                If CallBackForClick Is Nothing Then
                    Select Case e.MouseArgs.Button
                        Case MouseButtons.Left
                            RaiseEvent LeftClickInPlay(sender, e)
                        Case MouseButtons.Right
                            RaiseEvent RightClickInPlay(sender, e)
                    End Select
                ElseIf CallBackForClick IsNot Nothing Then
                    Dim cb As Callback = CallBackForClick
                    CallBackForClick = Nothing
                    cb.Invoke(DirectCast(sender, SmallCard), e.Owner, e.MouseArgs.Button)
                End If
            End If
        End Sub

        Private Function GetFilterArguments(owner As Guid, ci As CardInstance)
            Return New FilterArguments With {.Owner = owner,
                                             .Location = ci.CardLocation,
                                             .State = ci.CardState,
                                             .Rank = _ge.GameState.GetCollectionById(owner).RankAndPlaceOfCharacter(ci).Key,
                                             .Source = ci}
        End Function

        Private Property CallBackForClick As Callback

    End Class

End Namespace