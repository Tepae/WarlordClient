Namespace GameEngine.EventNotifier

    Public Interface IListener

        Sub Notify(id As Guid, hasData As Boolean)

    End Interface

End Namespace