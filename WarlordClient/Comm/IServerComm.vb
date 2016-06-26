Namespace Comm

    Public Interface IServerComm

        Sub RegisterPlayer(plr As Common.Player)
        Sub RegisterDeckForPlayer(id As Guid)
        Sub PlayerEndsTurn(id As Guid, pass As Boolean)
        Sub RollInitiative(id As Guid, initiative As Integer)
        Sub PlayEffectForOpponent(plrId As Guid, effectId As Guid, effect As Object)
        ReadOnly Property ActivePlayer() As Common.Player
        Event PlayersTurn(plrId As Guid)
        Event NewRound()
        Event PlayEffect(plrId As Guid, effectId As Guid, effect As Object)

    End Interface

End Namespace
