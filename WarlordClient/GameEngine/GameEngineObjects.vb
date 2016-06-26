Namespace GameEngine
    ' ReSharper disable once ClassNeverInstantiated.Global
    Public Class GameEngineObjects

        Private Shared _ge As GameEngine

        Public Shared Sub Register(ge As GameEngine)
            _ge = ge
        End Sub

        Public Shared ReadOnly Property UserInterfaceManipulator() As UserInterfaceManipulator
            Get
                Return _ge.UserInterfaceManipulator
            End Get
        End Property

        Public Shared ReadOnly Property GameFlowController() As GameFlowController
            Get
                Return _ge.GameFlowController
            End Get
        End Property

        Public Shared ReadOnly Property GameStateManipulator() As GameStateManipulator
            Get
                Return _ge.GameStateManipulator
            End Get
        End Property

        Public Shared ReadOnly Property ServerCommunication() As ServerCommunication
            Get
                Return _ge.ServerCommunication
            End Get
        End Property

    End Class
End Namespace