Namespace GameEngine

    Public Class OrderPerTurnCounter

        Private Shared ReadOnly OrdersPlayedByCardInstance As New Dictionary(Of Guid, Dictionary(Of String, Integer))

        Public Shared Sub Increment(id As Guid, orderName As String)
            If Not OrdersPlayedByCardInstance.ContainsKey(id) Then
                OrdersPlayedByCardInstance.Add(id, New Dictionary(Of String, Integer))
            End If
            If Not OrdersPlayedByCardInstance(id).ContainsKey(orderName) Then
                OrdersPlayedByCardInstance(id).Add(orderName, 1)
            Else
                OrdersPlayedByCardInstance(id)(orderName) += 1
            End If
        End Sub

        Public Shared Function CanPerformOrder(id As Guid, orderName As String, maxAmount As Integer) As Boolean
            Return maxAmount < CountForOrder(id, orderName)
        End Function

        Private Shared Function HasCharacter(id As Guid) As Boolean
            Return OrdersPlayedByCardInstance.ContainsKey(id)
        End Function

        Private Shared Function HasEntryForOrder(id As Guid, orderName As String) As Boolean
            Return HasCharacter(id) AndAlso OrdersPlayedByCardInstance(id).ContainsKey(orderName)
        End Function

        Private Shared Function CountForOrder(id As Guid, ordername As String) As Integer
            Dim ret As Integer = -1
            If HasEntryForOrder(id, ordername) Then
                ret = OrdersPlayedByCardInstance(id)(ordername)
            End If
            Return ret
        End Function

    End Class

End Namespace