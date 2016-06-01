Namespace Common

    Public Class PlayerState

        Private _player As Player = Nothing
        Private _deckRegistered As Boolean = False

        Public Sub New(plr As Player)
            _player = plr
        End Sub

        Public Sub RegisterDeck()
            _deckRegistered = True
        End Sub

        Public ReadOnly Property Player As Player
            Get
                Return _player
            End Get
        End Property

        Public ReadOnly Property DeckRegistered As Boolean
            Get
                Return _deckRegistered
            End Get
        End Property

    End Class

End Namespace