Imports WarlordClient.Common

Namespace GameEngine

    Public Interface IGameEngineStateBasedEffectsFixer
        Function CheckForDeadCharacters() As Boolean
        Function CheckForPlayerLoss() As Boolean
        Function CheckIllegalRanks() As Player
    End Interface

End Namespace