Namespace GameEngine.EventNotifier

    Public Class ListenerEntry

        Public Sub New(id As Guid, listener As IListener, removeWhenNotified As Boolean)
            Me.Id = id
            Me.Listener = listener
            Me.RemoveWhenNotified = removeWhenNotified
        End Sub

        Public ReadOnly Property Id As Guid

        Public ReadOnly Property Listener As IListener

        Public ReadOnly Property RemoveWhenNotified As Boolean

    End Class

End Namespace