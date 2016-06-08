Namespace GameEngine

    Public Class InfoboxData
        Public Sub New(text As String)
            Me.New(text, New ButtonConfiguration)
        End Sub

        Public Sub New(text As String, bc As ButtonConfiguration)
            Me.Text = text
            ButtonConfiguration = bc
        End Sub

        Public ReadOnly Property Text As String = String.Empty

        Public ReadOnly Property ButtonConfiguration As ButtonConfiguration

    End Class

End Namespace