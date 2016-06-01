Namespace GameEngine

    Public Class CardNameMapper

        Private _mappings As Dictionary(Of String, String)

        Public Sub New()
            _mappings = New Dictionary(Of String, String)
            Setup()
        End Sub

        Private Sub Setup()
            _mappings.Add("Throw", "Throw_")
        End Sub

        Private Function HasMapping(cardname As String) As Boolean
            Return _mappings.ContainsKey(cardname)
        End Function

        Public Function GetMappedCardname(cardname As String) As String
            Dim ret As String = cardname
            If HasMapping(cardname) Then
                ret = _mappings(cardname)
            End If
            Return ret
        End Function

    End Class

End Namespace
