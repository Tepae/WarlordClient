Namespace GameEngine.StateBasedEffects

    Public Class StateBasedEffectsFixer

        Private ReadOnly _ge As IGameEngineStateBasedEffectsFixer

        Public Sub New(ge As IGameEngineStateBasedEffectsFixer)
            _ge = ge
        End Sub

        Public Function StateBasedEffectsAllowForTurnToBePassed() As Boolean
            Return _ge.CheckForDeadCharacters() _
                AndAlso _ge.CheckForPlayerLoss() _
                AndAlso _ge.CheckIllegalRanks()
        End Function


    End Class

End Namespace