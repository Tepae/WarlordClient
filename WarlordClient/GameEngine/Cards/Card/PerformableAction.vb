Namespace GameEngine.Card

    Public Class PerformableAction

        Private _description As String = String.Empty
        Private _requiresSpending As Boolean = False
        Private _action As Card.ActionDelegate = Nothing

        Public Sub New(description As String, requiresSpending As Boolean, action As Card.ActionDelegate)
            _description = description
            _requiresSpending = requiresSpending
            _action = action
        End Sub

        Public ReadOnly Property Description As String
            Get
                Return _description
            End Get
        End Property

        Public ReadOnly Property RequiresSpending As Boolean
            Get
                Return _requiresSpending
            End Get
        End Property

        Public ReadOnly Property Action As Card.ActionDelegate
            Get
                Return _action
            End Get
        End Property

    End Class

End Namespace
