Namespace GameEngine

    Public Interface IGameEngineGameFlowController
        Sub StartGame()
        Sub NewRound()
        Sub PassTurn()
        Sub CancelAction()
        Function StateBasedEffectsAllowForTurnToBePassed() As Boolean
    End Interface

End Namespace