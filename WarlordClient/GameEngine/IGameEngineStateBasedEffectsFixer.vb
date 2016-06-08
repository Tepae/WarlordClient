Namespace GameEngine

    Public Interface IGameEngineStateBasedEffectsFixer
        Function CheckForDeadCharacters() As Boolean
        Function CheckForPlayerLoss() As Boolean
        Function CheckIllegalRanks() As Boolean
    End Interface

End Namespace