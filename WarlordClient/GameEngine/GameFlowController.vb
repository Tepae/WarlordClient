Namespace GameEngine

    Public Class GameFlowController

        Private ReadOnly _ge As IGameEngineGameFlowController

        Public Sub New(ge As IGameEngineGameFlowController)
            _ge = ge
        End Sub

        Public Sub StartGame()
            _ge.StartGame()
        End Sub

        Public Sub NewRound()
            _ge.NewRound()
        End Sub

        Public Sub PassTurn()
            _ge.PassTurn()
        End Sub

        Public Sub CancelAction()
            _ge.CancelAction()
        End Sub

        Public Function StateBasedEffectsAllowForTurnToBePassed() As Boolean
            Return _ge.StateBasedEffectsAllowForTurnToBePassed()
        End Function

    End Class

End Namespace