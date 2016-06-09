Imports WarlordClient.Common

Namespace GameEngine

    Public Interface IGameEngineStateBasedEffectsFixer
        Function CheckForDeadCharacters() As Boolean
        Function CheckForPlayerLoss() As Boolean
        Function CheckIllegalRanks() As Player
        Sub PromptPlayerToFixIllegalRank(rank As Integer, plr As Player)
    End Interface

End Namespace