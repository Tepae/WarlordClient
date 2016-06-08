Imports WarlordClient.GameEngine.Order

Namespace GameEngine.CharacterMovement

    Public Class CharacterMover

        Private ReadOnly _id As Guid
        Private ReadOnly _gs As GameState
        Private ReadOnly _gfc As GameFlowController
        Private ReadOnly _uim As UserInterfaceManipulator
        Private WithEvents _cpd As CharacterPlacementDialog
        Private ReadOnly _passTurn As Boolean
        Private _owner As Guid

        Public Sub New(id As Guid, gs As GameState, cpd As CharacterPlacementDialog, passTurn As Boolean)
            _id = id
            _gs = gs
            _gfc = GameEngineObjects.GameFlowController
            _uim = GameEngineObjects.UserInterfaceManipulator
            _cpd = cpd
            _passTurn = passTurn
        End Sub

        Public Sub MoveCharacter()
            _cpd.ChooseLocationForPlacement()
        End Sub

        Private Sub HandleMovementChoicesFound(sc As SmallCard, mcs As List(Of PlacementChoice)) Handles _cpd.PlacementChoicesAvailable
            _owner = _gs.GetOwnerOfCardInstance(sc.Card)
            _uim.DrawPlacementDotsToCardGrid(_owner, sc, mcs, AddressOf LocationChosen)
        End Sub

        Private Sub LocationChosen(sc As SmallCard, placementChoice As PlacementChoice)
            Dim op As New OrderPerformer(_owner, _gs, _gfc)
            Dim o As IOrder = Nothing
            Select Case _cpd.PlacementType
                Case PlacementChoice.PlacementTypeEnum.Regular
                    o = New MoveCharacter(_id, sc, placementChoice)
                Case PlacementChoice.PlacementTypeEnum.IllegalRank
                    o = New ForceMoveCharacter(_id, sc, placementChoice)
            End Select
            op.Perform(o, _passTurn)
        End Sub

    End Class

End Namespace
