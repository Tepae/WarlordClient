Namespace GameEngine.Order

    Public MustInherit Class PlayCard

        Friend Id As Guid
        Friend Owner As Guid
        Friend Ci As CardInstance
        Friend PassTurn As Boolean

        Public Sub New(id As Guid, owner As Guid, ci As CardInstance, passTurn As Boolean)
            Me.Id = id
            Me.Owner = owner
            Me.Ci = ci
            Me.PassTurn = passTurn
        End Sub

    End Class

End Namespace