Imports WarlordClient.GameEngine.CharacterMovement
Imports WarlordClient.GameEngine.Order

Namespace GameEngine.CardPlayer

    Public Class CharacterPlayer
        Implements ICardPlayer

        Private ReadOnly _sc As SmallCard
        Private ReadOnly _uim As UserInterfaceManipulator = GameEngineObjects.UserInterfaceManipulator
        Private ReadOnly _gs As GameState

        Public Sub New(sc As SmallCard, gs As GameState)
            _sc = sc
            _gs = gs
        End Sub

        Public Sub PlayCard() Implements ICardPlayer.PlayCard
            CreateDialog()
        End Sub

        Private Sub CreateDialog()
            Dim cpd As New CharacterPlacementDialog(_uim,
                                                    _sc,
                                                    _gs.GetCollectionById(_gs.GetOwnerOfCardInstance(_sc.Card)),
                                                    -1,
                                                    False,
                                                    PlacementChoice.PlacementTypeEnum.PlayFromHand,
                                                    New PlayFromHandRankDeterminer,
                                                    New StandardUserInputNeededButtonConfiguration(AddressOf _uim.CleanContextSensitiveVisuals),
                                                    New PlayFromHandInfoBoxTextGenerator)
            AddHandler cpd.PlacementChoicesAvailable, AddressOf PlacementChoicesAvailable
            cpd.ChooseLocationForPlacement()
        End Sub

        Private Sub PlacementChoicesAvailable(sc As SmallCard, mcs As List(Of PlacementChoice))
            _uim.DrawPlacementDotsToCardGrid(_gs.GetOwnerOfCardInstance(sc.Card), sc, mcs, AddressOf PlayCharacter)
        End Sub

        Private Sub PlayCharacter(sc As SmallCard, pc As PlacementChoice)
            Dim op As New OrderPerformer(_gs.GetOwnerOfCardInstance(sc.Card), _gs)
            op.Perform(New PlayCharacter(Guid.NewGuid(), sc, pc), True, Nothing)
        End Sub

    End Class

End Namespace
