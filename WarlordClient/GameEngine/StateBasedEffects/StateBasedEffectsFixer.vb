Imports WarlordClient.Common
Imports WarlordClient.GameEngine.IllegalRank

Namespace GameEngine.StateBasedEffects

    Public Class StateBasedEffectsFixer

        Private ReadOnly _ge As IGameEngineStateBasedEffectsFixer
        Private ReadOnly _gs As GameState
        Private ReadOnly _reentryPointWhenFixed As Action

        Public Sub New(ge As IGameEngineStateBasedEffectsFixer, gs As GameState, reentryPointWhenFixed As Action)
            _ge = ge
            _gs = gs
            _reentryPointWhenFixed = reentryPointWhenFixed
        End Sub

        Public Function StateBasedEffectsAllowForTurnToBePassed() As Boolean
            Dim ret As Boolean
            ret = _ge.CheckForDeadCharacters() AndAlso _ge.CheckForPlayerLoss()
            Dim plr As Player = _ge.CheckIllegalRanks()
            If plr IsNot Nothing Then
                ret = False
                FixIllegalRanks(plr)
            End If
            Return ret
        End Function

        Private Sub FixIllegalRanks(plr As Player)
            Dim irf As New IllegalRankFixer(_gs, _reentryPointWhenFixed)
            irf.PromptPlayerToFixIllegalRank(_gs.GetFirstIllegalRank(plr.Id), plr)
        End Sub

    End Class

End Namespace