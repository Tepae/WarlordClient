Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.CardPlayer

    Public Class CharacterPlayer
        Implements ICardPlayer

        Private ReadOnly _sc As SmallCard
        Private ReadOnly _ge As IUserInterfaceManipulator
        Private ReadOnly _gs As GameState

        Public Sub New(sc As SmallCard, ge As GameEngine, gs As GameState)
            _sc = sc
            _ge = ge
            _gs = gs
        End Sub

        Public Sub PlayCard() Implements ICardPlayer.PlayCard
            CreateDialog()
        End Sub

        Private Sub CreateDialog()
            Dim cpd As New CharacterPlacementDialog(_ge,
                                                    _sc,
                                                    _gs.GetCollectionById(_gs.GetOwnerOfCardInstance(_sc.Card)),
                                                    -1,
                                                    PlacementChoice.PlacementTypeEnum.PlayFromHand,
                                                    New PlayFromHandRankDeterminer,
                                                    New StandardPlacementButtonConfiguration(_ge),
                                                    New PlayFromHandInfoBoxTextGenerator)
            AddHandler cpd.PlacementChoicesAvalible, AddressOf PlacementChoicesAvalible
            cpd.ChooseLocationForPlacement()
        End Sub

        Private Sub PlacementChoicesAvalible(sc As SmallCard, mcs As List(Of PlacementChoice))
            _ge.DrawPlacementDotsToCardGrid(_gs.GetOwnerOfCardInstance(sc.Card), sc, mcs, AddressOf PlayCharacter)
        End Sub

        Private Sub PlayCharacter(sc As SmallCard, pc As PlacementChoice)

        End Sub

    End Class

End Namespace
