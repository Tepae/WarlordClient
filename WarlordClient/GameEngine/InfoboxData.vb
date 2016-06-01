Namespace GameEngine

    Public Class InfoboxData

        Private _text As String = String.Empty
        Private _buttonConfiguration As ButtonConfiguration

        Public Sub New(text As String)
            Me.New(text, New ButtonConfiguration)
        End Sub

        Public Sub New(text As String, bc As ButtonConfiguration)
            _text = text
            _buttonConfiguration = bc
        End Sub

        Public ReadOnly Property Text As String
            Get
                Return _text
            End Get
        End Property

        Public ReadOnly Property ButtonConfiguration As ButtonConfiguration
            Get
                Return _buttonConfiguration
            End Get
        End Property

    End Class

End Namespace