Namespace GameEngine

    Public Class ActionPerformer

        Private Shared _ge As GameEngine

        Public Shared Sub Initialize(ge As GameEngine)
            _ge = ge
        End Sub

        Public Shared Sub PerformAction(sc As SmallCard, pa As Card.PerformableAction)
            If _ge IsNot Nothing Then
                pa.Action.Invoke(sc, _ge)
            Else
                NotInitialized()
            End If
        End Sub

        Private Shared Sub NotInitialized()
            Throw New NoNullAllowedException("ActionPerfomer not initialized, GameEngine was Nothing")
        End Sub

    End Class

End Namespace