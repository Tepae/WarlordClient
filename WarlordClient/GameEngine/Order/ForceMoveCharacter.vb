Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.Order

    Public Class ForceMoveCharacter
        Inherits MoveCharacter

        Public Sub New(id As Guid, sc As SmallCard, pc As PlacementChoice)
            MyBase.New(id, sc, pc)
        End Sub

        Public Overrides Sub Perform(owner As Guid, gs As GameState)
            SetState()
            MyBase.Perform(owner, gs)
        End Sub

        Private Sub SetState()
            If Sc.Card.CardState = CardInstance.State.Ready Then
                Sc.Card.CardState = CardInstance.State.Spent
            Else
                Sc.Card.CardState = CardInstance.State.Stunned
            End If
        End Sub

    End Class

End Namespace