Namespace GameEngine

    ' ReSharper disable once ClassNeverInstantiated.Global
    Public Class Die

        Private Shared _next As Integer = -1
        Private Shared ReadOnly Rng As New Random

        Public Shared Function Roll() As Integer
            Return Roll(1, 20)
        End Function

        Public Shared Sub SetNextRoll(nextRoll As Integer)
            _next = nextRoll
        End Sub

        Private Shared Function Roll(minValue As Integer, maxValue As Integer) As Integer
            Dim ret As Integer
            If _next > 0 Then
                ret = _next
                _next = -1
            Else
                ret = Rng.Next(minValue, maxValue)
            End If
            Return ret
        End Function

    End Class

End Namespace