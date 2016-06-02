Namespace GameEngine.CharacterMovement

    Public Class CharacterMover

        Private ReadOnly _ge As GameEngine
        Private ReadOnly _id As Guid
        Private WithEvents _cpd As CharacterPlacementDialog
        Private ReadOnly _passTurn As Boolean

        Public Sub New(id As Guid, ge As GameEngine, cpd As CharacterPlacementDialog)
            Me.New(id, ge, cpd, True)
        End Sub

        Public Sub New(id As Guid, ge As GameEngine, cpd As CharacterPlacementDialog, passTurn As Boolean)
            _id = id
            _ge = ge
            _cpd = cpd
            _passTurn = passTurn
        End Sub

        Public Sub MoveCharacter()
            _cpd.ChooseLocationForPlacement()
        End Sub

        Private Sub HandleMovementChoicesFound(sc As SmallCard, mcs As List(Of PlacementChoice)) Handles _cpd.PlacementChoicesAvalible
            _ge.DrawPlacementDotsToCardGrid(_ge.GetOwnerOfSmallCard(sc), sc, mcs, AddressOf LocationChosen)
        End Sub

        Private Sub LocationChosen(sc As SmallCard, movementChoice As PlacementChoice)
            _ge.PerformOrder(New Order.MoveCharacter(_id, _ge.GetOwnerOfSmallCard(sc), sc, movementChoice, _passTurn))
        End Sub

    End Class

End Namespace
