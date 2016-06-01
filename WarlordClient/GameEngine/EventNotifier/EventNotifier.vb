Namespace GameEngine.EventNotifier

    Public Class EventNotifier

        Private Shared _listeners As New List(Of ListenerEntry)
        Private Shared _data As New Dictionary(Of Guid, Object)

        Public Shared Sub Register(id As Guid, listener As IListener, removeWhenNotified As Boolean)
            _listeners.Add(New ListenerEntry(id, listener, removeWhenNotified))
        End Sub

        Private Shared Function GetListenersById(id As Guid)
            Dim ret As New List(Of ListenerEntry)
            For Each listener As ListenerEntry In _listeners
                If listener.Id = id Then
                    ret.Add(listener)
                End If
            Next
            Return ret
        End Function

        Public Shared Sub Notify(id As Guid)
            For Each listener As ListenerEntry In GetListenersById(id)
                listener.Listener.Notify(id, _data.ContainsKey(id))
                If listener.RemoveWhenNotified Then
                    _listeners.Remove(listener)
                End If
            Next
        End Sub

        Public Shared Function GetData(id As Guid) As Object
            Dim ret As Object = Nothing
            If _data.ContainsKey(id) Then
                ret = _data(id)
                _data.Remove(id)
            End If
            Return ret
        End Function

    End Class

End Namespace