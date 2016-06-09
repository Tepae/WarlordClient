Namespace GameEngine
    ' ReSharper disable once ClassNeverInstantiated.Global
    Public Class GameEngineObjects

        Private Shared _ge As GameEngineGameEngine

        Public Shared Sub Register(ge As GameEngineGameEngine)
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

    End Class
End Namespace