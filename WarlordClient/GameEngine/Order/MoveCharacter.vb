Namespace GameEngine.Order

    Public Class MoveCharacter
        Implements IOrder

        Private _id As Guid
        Private ReadOnly _owner As Guid
        Private ReadOnly _sc As SmallCard
        Private ReadOnly _mc As CharacterMovement.PlacementChoice

        Public Sub New(id As Guid, owner As Guid, sc As SmallCard, movementChoice As CharacterMovement.PlacementChoice)
            Me.New(id, owner, sc, movementChoice, True)
        End Sub

        Public Sub New(id As Guid, owner As Guid, sc As SmallCard, movementChoice As CharacterMovement.PlacementChoice, passTurnWhenDone As Boolean)
            _id = id
            _owner = owner
            _sc = sc
            _mc = movementChoice
            Me.PassTurnWhenDone = passTurnWhenDone
        End Sub

        Public Sub HandleAfterReacts() Implements IOrder.HandleAfterReacts

        End Sub

        Public Sub HandleBeforeReacts() Implements IOrder.HandleBeforeReacts

        End Sub

        Public Sub Perform(ge As GameEngine) Implements IOrder.Perform
            If _mc.Type = CharacterMovement.PlacementChoice.PlacementTypeEnum.Regular Then
                _sc.Card.CardState = CardInstance.State.Spent
            ElseIf _mc.Type = CharacterMovement.PlacementChoice.PlacementTypeEnum.IllegalRank Then
                If _sc.Card.CardState = CardInstance.State.Ready Then
                    _sc.Card.CardState = CardInstance.State.Spent
                Else
                    _sc.Card.CardState = CardInstance.State.Stunned
                End If
            End If
            ge.GameState.MoveCharacter(_owner, _sc.Card, _mc)
            ge.RaiseSystemMessage(String.Format("{0} moves to rank {1}", _sc.Card.Card.Name, _mc.Rank))
            ge.ClearMovementSettings()
        End Sub

        Public Property PassTurnWhenDone As Boolean Implements IOrder.PassTurnWhenDone

    End Class

End Namespace