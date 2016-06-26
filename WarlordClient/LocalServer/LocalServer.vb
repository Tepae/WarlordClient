Imports WarlordClient.Comm
Imports WarlordClient.Common

Namespace LocalServer

    Public Class LocalServer
        Implements IServerComm

        Private ReadOnly _players As List(Of PlayerState)
        Private _activePlayer As Player
        Private ReadOnly _initiatives As Dictionary(Of Guid, Integer)
        Private ReadOnly _passes As List(Of Guid)

        Public Event PlayersTurn(id As Guid) Implements IServerComm.PlayersTurn
        Public Event NewRound() Implements IServerComm.NewRound
        Public Event PlayEffect(plrId As Guid, effectId As Guid, effect As Object) Implements IServerComm.PlayEffect

        Public Sub New()
            _players = New List(Of PlayerState)
            _initiatives = New Dictionary(Of Guid, Integer)
            _passes = New List(Of Guid)
        End Sub

#Region "IServerComm"

        Public Sub RegisterPlayer(plr As Player) Implements IServerComm.RegisterPlayer
            If _players.Count < 2 Then
                _players.Add(New PlayerState(plr))
            End If
        End Sub

        Public Sub PlayerEndsTurn(guid As Guid, done As Boolean) Implements IServerComm.PlayerEndsTurn
            If done AndAlso Not _passes.Contains(guid) Then
                _passes.Add(guid)
            End If
            If _passes.Count = _players.Count Then
                RaiseNewRoundEvent()
            Else
                For Each ps As PlayerState In _players
                    If Not ps.Player.Id = guid Then
                        GivePlayerTurn(ps.Player)
                        Exit For
                    End If
                Next
            End If
        End Sub

        Public Sub RegisterDeckForPlayer(id As Guid) Implements IServerComm.RegisterDeckForPlayer
            For Each ps As PlayerState In _players
                If ps.Player.Id = id Then
                    ps.RegisterDeck()
                    Exit For
                End If
            Next
        End Sub

        Public Sub RollInitiative(id As Guid, initiative As Integer) Implements IServerComm.RollInitiative
            _initiatives.Add(id, initiative)
            If _initiatives.Keys.Count = 2 Then
                GiveTurnToPlayerWithHighestInitiative()
                _initiatives.Clear()
            End If
        End Sub

        Public Sub PlayEffectForOpponent(plrId As Guid, effectId As Guid, effect As Object) Implements IServerComm.PlayEffectForOpponent
            RaisePlayEffectEvent(plrId, effectId, effect)
        End Sub

        Public ReadOnly Property ActivePlayer() As Player Implements IServerComm.ActivePlayer
            Get
                Return _activePlayer
            End Get
        End Property

#End Region

        Private Sub GivePlayerTurn(plr As Player)
            _activePlayer = plr
            RaiseEvent PlayersTurn(plr.Id)
        End Sub

        Private Sub GivePlayerTurn(id As Guid)
            For Each ps As PlayerState In _players
                If id = ps.Player.Id Then
                    GivePlayerTurn(ps.Player)
                    Exit For
                End If
            Next
        End Sub

        Private Sub RaiseNewRoundEvent()
            _passes.Clear()
            RaiseEvent NewRound()
        End Sub

        Private Sub RaisePlayEffectEvent(plrId As Guid, effectId As Guid, effect As Object)
            RaiseEvent PlayEffect(GetOpponent(plrId).Player.Id, effectId, effect)
        End Sub

        Private Sub GiveTurnToPlayerWithHighestInitiative()
            Dim highest As Integer = Integer.MinValue
            Dim plrId As Guid = Guid.Empty
            For Each id As Guid In _initiatives.Keys
                If _initiatives(id) > highest Then
                    highest = _initiatives(id)
                    plrId = id
                End If
            Next
            GivePlayerTurn(plrId)
        End Sub

        Private Function GetOpponent(source As Guid) As PlayerState
            Dim ret As PlayerState = Nothing
            For Each ps As PlayerState In _players
                If ps.Player.Id <> source Then
                    ret = ps
                    Exit For
                End If
            Next
            Return ret
        End Function

    End Class

End Namespace
