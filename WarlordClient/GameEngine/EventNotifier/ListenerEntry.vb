Namespace GameEngine.EventNotifier

    Public Class ListenerEntry

        Private _id As Guid
        Private _listener As IListener
        Private _removeWhenNotified As Boolean

        Public Sub New(id As Guid, listener As IListener, removeWhenNotified As Boolean)
            _id = id
            _listener = listener
            _removeWhenNotified = removeWhenNotified
        End Sub

        Public ReadOnly Property Id As Guid
            Get
                Return _id
            End Get
        End Property

        Public ReadOnly Property Listener As IListener
            Get
                Return _listener
            End Get
        End Property

        Public ReadOnly Property RemoveWhenNotified As Boolean
            Get
                Return _removeWhenNotified
            End Get
        End Property

    End Class

End Namespace