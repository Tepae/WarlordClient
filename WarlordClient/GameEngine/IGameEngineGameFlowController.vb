Imports WarlordClient.Common

Namespace GameEngine

    Public Interface IGameEngineGameFlowController
        Sub StartGame()
        Sub NewRound()
        Sub PassTurn()
        Sub CancelAction()
        Function StateBasedEffectsAllowForTurnToBePassed(entryPointWhenFixed As Action) As Boolean
    End Interface

End Namespace