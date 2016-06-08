Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.Order

    Public Class MoveCharacter
        Implements IOrder

        Private ReadOnly _id As Guid
        Friend ReadOnly Sc As SmallCard
        Private ReadOnly _pc As PlacementChoice

        Public Sub New(id As Guid, sc As SmallCard, pc As PlacementChoice)
            _id = id
            Me.Sc = sc
            _pc = pc
        End Sub

        Public Overridable Sub Perform(owner As Guid, gs As GameState) Implements IOrder.Perform
            gs.MoveCharacter(owner, Sc.Card, _pc)
        End Sub

        Public Function Id() As Guid Implements IOrder.Id
            Return _id
        End Function
    End Class

End Namespace