Namespace GameEngine

    Public Class GameStateManipulator

        Private ReadOnly _ge As IGameEngineGameStateManipulator

        Public Sub New(ge As IGameEngineGameStateManipulator)
            _ge = ge
        End Sub

        Public Sub DrawXCards(owner As Guid, x As Integer)
            _ge.DrawXCards(owner, x)
        End Sub

    End Class

End Namespace