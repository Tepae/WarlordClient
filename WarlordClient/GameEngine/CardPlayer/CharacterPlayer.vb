Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.CardPlayer

    Public Class CharacterPlayer
        Implements ICardPlayer

        Private ReadOnly _sc As SmallCard
        Private ReadOnly _uim As UserInterfaceManipulator
        Private ReadOnly _gs As GameState

        Public Sub New(sc As SmallCard, gs As GameState)
            _sc = sc
            _uim = GameEngineObjects.UserInterfaceManipulator
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
                                                    PlacementChoice.PlacementTypeEnum.PlayFromHand,
                                                    New PlayFromHandRankDeterminer,
                                                    New StandardPlacementButtonConfiguration(AddressOf _uim.CleanContextSensitiveVisuals),
                                                    New PlayFromHandInfoBoxTextGenerator)
            AddHandler cpd.PlacementChoicesAvailable, AddressOf PlacementChoicesAvailable
            cpd.ChooseLocationForPlacement()
        End Sub

        Private Sub PlacementChoicesAvailable(sc As SmallCard, mcs As List(Of PlacementChoice))
            _uim.DrawPlacementDotsToCardGrid(_gs.GetOwnerOfCardInstance(sc.Card), sc, mcs, AddressOf PlayCharacter)
        End Sub

        Private Sub PlayCharacter(sc As SmallCard, pc As PlacementChoice)

        End Sub

    End Class

End Namespace
