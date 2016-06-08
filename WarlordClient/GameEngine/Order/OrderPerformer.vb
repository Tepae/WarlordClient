Imports WarlordClient.GameEngine.EventNotifier

Namespace GameEngine.Order

    Public Class OrderPerformer

        Private ReadOnly _owner As Guid
        Private ReadOnly _gs As GameState
        Private ReadOnly _gfc As GameFlowController
        Private _passTurn As Boolean = True
        Private _id As Guid

        Public Sub New(owner As Guid, gs As GameState, gfc As GameFlowController)
            _owner = owner
            _gs = gs
            _gfc = gfc
        End Sub

        Public Sub Perform(o As IOrder, passTurn As Boolean)
            _id = o.Id
            _passTurn = passTurn
            AllowBeforeResponses()
            o.Perform(_owner, _gs)
            AllowAfterResponses()
            CleanInterface()
            PassTurnIfAble()
        End Sub

        Private Sub AllowBeforeResponses()
            BeforeAllowLocalPlayerToRespond()
            BeforeAllowOpponentToRespond()
        End Sub

        Private Sub AllowAfterResponses()
            AfterAllowLocalPlayerToRespond()
            AfterAllowOpponentToRespond()
        End Sub

        Private Sub BeforeAllowLocalPlayerToRespond()

        End Sub

        Private Sub BeforeAllowOpponentToRespond()

        End Sub

        Private Sub AfterAllowLocalPlayerToRespond()

        End Sub

        Private Sub AfterAllowOpponentToRespond()

        End Sub

        Private Sub CleanInterface()
            GameEngineObjects.UserInterfaceManipulator.CleanContextSensitiveVisuals()
        End Sub

        Private Sub PassTurnIfAble()
            If _passTurn Then
                If _gfc.StateBasedEffectsAllowForTurnToBePassed() Then
                    _gfc.PassTurn()
                End If
            End If
        End Sub

    End Class



End Namespace