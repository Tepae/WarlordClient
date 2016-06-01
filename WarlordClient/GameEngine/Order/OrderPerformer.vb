Namespace GameEngine.Order

    Public Class OrderPerformer

        Private _ge As GameEngine = Nothing

        Public Sub New(ge As GameEngine)
            _ge = ge
        End Sub

        Public Sub Perform(o As IOrder)
            o.HandleBeforeReacts()
            o.Perform(_ge)
            o.HandleAfterReacts()
            If _ge.StateBasedEffectsAllowForTurnToBePassed() AndAlso o.PassTurnWhenDone Then
                _ge.PassTurn()
            End If
        End Sub

    End Class

End Namespace