Namespace Common

    Public Class Player

        Private _name As String
        Private _id As Guid
        Private _playerType As PlayerType

        Public Sub New()
            Me.New("Noname")
        End Sub

        Public Sub New(name As String)
            Me.New(name, Guid.NewGuid)
        End Sub

        Public Sub New(name As String, id As Guid)
            Me.New(name, id, PlayerType.Local)
        End Sub

        Public Sub New(name As String, id As Guid, type As PlayerType)
            _name = name
            _id = id
            _playerType = type
        End Sub

        Public Property Name As String
            Get
                Return _name
            End Get
            Set(value As String)
                _name = value
            End Set
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

        Public Enum PlayerType
            Local
            [Global]
        End Enum

    End Class

End Namespace
