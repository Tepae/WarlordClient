Imports WarlordClient.Common
Imports WarlordClient.Common.Player

Namespace GameEngine

    Public Class PlayerList

        Private _players As List(Of Player)

        Public Sub New()
            _players = New List(Of Player)
        End Sub

        Public Sub AddPlayer(pl As Player)
            _players.Add(pl)
        End Sub

        Public Function GetPlayer(id As Guid) As Player
            Dim ret As Player = Nothing
            For Each pl As Player In _players
                If pl.Id = id Then
                    ret = pl
                    Exit For
                End If
            Next
            Return ret
        End Function

        Public Function GetPlayersByType(type As PlayerType) As List(Of Player)
            Dim ret As New List(Of Player)
            For Each pl As Player In _players
                If pl.Type = type Then
                    ret.Add(pl)
                End If
            Next
            Return ret
        End Function

        Public Function GetOpponent(id As Guid) As Player
            Dim ret As Player = Nothing
            If _players.Count = 2 Then
                For Each plr As Player In _players
                    If plr.Id <> id Then
                        ret = plr
                    End If
                Next
            End If
            Return ret
        End Function

        Public ReadOnly Property Players() As List(Of Player)
            Get
                Return _players
            End Get
        End Property

    End Class

End Namespace