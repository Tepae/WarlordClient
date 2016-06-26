Namespace GameEngine.RespondableAction

    Public Class RespondableActionPerformer

        Private ReadOnly _owner As Guid
        Private ReadOnly _gs As GameState
        Private ReadOnly _gfc As GameFlowController = GameEngineObjects.GameFlowController
        Private _passTurn As Boolean = True
        Private _id As Guid
        Private _exitPoint As Action

        Public Sub New(owner As Guid, gs As GameState)
            _owner = owner
            _gs = gs
        End Sub

        Public Sub Perform(o As IRespondableAction, passTurn As Boolean, exitPoint As Action)
            _id = o.Id
            _passTurn = passTurn
            _exitPoint = exitPoint
            o.MakeChoices()
            AllowBeforeResponses()
            o.Perform(_owner, _gs)
            AllowAfterResponses()
            CleanInterface()
            Pass()
        End Sub

        Private Sub AllowBeforeResponses()

        End Sub

        Private Sub AllowAfterResponses()

        End Sub

        Private Sub CleanInterface()
            GameEngineObjects.UserInterfaceManipulator.CleanContextSensitiveVisuals()
        End Sub

        Private Sub Pass()
            If _gfc.StateBasedEffectsAllowForTurnToBePassed(AddressOf Pass) Then
                If _passTurn Then
                    _gfc.PassTurn()
                ElseIf _exitPoint IsNot Nothing Then
                    _exitPoint.Invoke()
                End If
            End If
        End Sub

    End Class

End Namespace