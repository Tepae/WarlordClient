Imports WarlordClient.GameEngine
Imports WarlordClient.Common.Player

Namespace Setup

    Public Class SetupInfo

        Private _playerName As String = String.Empty
        Private _id As Guid
        Private _playerType As PlayerType
        Private _deck As Decklist = Nothing
        Private _startingCharacters As CardCollection

#Region "ctor"

        Public Sub New(deck As Decklist, startingCharacters As CardCollection)
            Me.New("Noname", deck, startingCharacters)
        End Sub

        Public Sub New(playerName As String, deck As Decklist, startingCharacters As CardCollection)
            Me.New(playerName, Guid.NewGuid, deck, startingCharacters)
        End Sub

        Public Sub New(playerName As String, id As Guid, deck As Decklist, startingCharacters As CardCollection)
            Me.New(playerName, id, PlayerType.Local, deck, startingCharacters)
        End Sub

        Public Sub New(playerName As String, id As Guid, playerType As PlayerType, deck As Decklist, startingCharacters As CardCollection)
            _playerName = playerName
            _id = id
            _playerType = playerType
            _deck = deck
            _startingCharacters = startingCharacters
            SetValuesForStartingCharacters()
        End Sub

#End Region

#Region "methods"

        Private Sub SetValuesForStartingCharacters()
            If _startingCharacters IsNot Nothing Then
                For i As Integer = 1 To _startingCharacters.RankCount Step 1
                    For Each ci As CardInstance In _startingCharacters.CharactersInRank(i)
                        ci.CardLocation = CardInstance.Location.InPlay
                        ci.CardState = ci.Card.BeginsPlayAs
                    Next
                Next
            End If
        End Sub

#End Region

        Public ReadOnly Property Playername As String
            Get
                Return _playerName
            End Get
        End Property

        Public ReadOnly Property Id As Guid
            Get
                Return _id
            End Get
        End Property

        Public ReadOnly Property Type As PlayerType
            Get
                Return _playerType
            End Get
        End Property

        Public ReadOnly Property Deck As Decklist
            Get
                Return _deck
            End Get
        End Property

        Public ReadOnly Property StartingCharacters As CardCollection
            Get
                Return _startingCharacters
            End Get
        End Property

    End Class

End Namespace