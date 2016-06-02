Namespace GameEngine.CharacterMovement

    Public Class CharacterMover

        Private ReadOnly _id As Guid
        Private ReadOnly _gs As GameState
        Private ReadOnly _uim As IUserInterfaceManipulator
        Private WithEvents _cpd As CharacterPlacementDialog
        Private ReadOnly _passTurn As Boolean
        Private ReadOnly _cancelAction As Action

        Public Sub New(id As Guid, gs As GameState, uim As IUserInterfaceManipulator, cpd As CharacterPlacementDialog, passTurn As Boolean)
            _id = id
            _gs = gs
            _uim = uim
            _cpd = cpd
            _passTurn = passTurn
        End Sub

        Public Sub MoveCharacter()
            _cpd.ChooseLocationForPlacement()
        End Sub

        Private Sub HandleMovementChoicesFound(sc As SmallCard, mcs As List(Of PlacementChoice)) Handles _cpd.PlacementChoicesAvalible
            _uim.DrawPlacementDotsToCardGrid(_gs.GetOwnerOfCardInstance(sc.Card), sc, mcs, AddressOf LocationChosen)
        End Sub

        Private Sub LocationChosen(sc As SmallCard, movementChoice As PlacementChoice)

        End Sub

    End Class

End Namespace
