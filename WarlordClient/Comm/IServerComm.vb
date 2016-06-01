Namespace Comm

    Public Interface IServerComm

        Sub RegisterPlayer(plr As Common.Player)
        Sub RegisterDeckForPlayer(id As Guid)
        Sub PlayerEndsTurn(id As Guid, pass As Boolean)
        Sub RollInitiative(id As Guid, initiative As Integer)
        ReadOnly Property ActivePlayer() As Common.Player
        Event PlayersTurn(id As Guid)
        Event NewRound()

    End Interface

End Namespace
