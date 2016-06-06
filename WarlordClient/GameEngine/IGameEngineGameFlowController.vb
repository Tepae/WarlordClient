Namespace GameEngine

    Public Interface IGameEngineGameFlowController
        Sub StartGame()
        Sub NewRound()
        Sub PassTurn()
        Sub CancelAction()
        Sub HandleStateBasedEffects(callingId As Guid)
        Function StateBasedEffectsAllowForTurnToBePassed() As Boolean
    End Interface

End Namespace