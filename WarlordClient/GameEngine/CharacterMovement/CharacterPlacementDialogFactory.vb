Namespace GameEngine.CharacterMovement

    ' ReSharper disable once ClassNeverInstantiated.Global
    Public Class CharacterPlacementDialogFactory

        Public Shared Function CreateDialogForStandardMovement(sc As SmallCard, cc As CardCollection, range As Integer, cancelAction As Action) As CharacterPlacementDialog
            Return CreateDialog(sc,
                                cc,
                                range,
                                PlacementChoice.PlacementTypeEnum.Regular,
                                New StandardPlacementRankDeterminer,
                                New StandardPlacementButtonConfiguration(cancelAction),
                                New PlacementInfoBoxTextGenerator)
        End Function

        Public Shared Function CreateDialogForIllegalRank(sc As SmallCard, cc As CardCollection, cancelAction As Action) As CharacterPlacementDialog
            Return CreateDialog(sc,
                                cc,
                                1,
                                PlacementChoice.PlacementTypeEnum.IllegalRank,
                                New IllegalRankMovementRankDeterminer,
                                New IllegalRankButtonConfiguration(cancelAction),
                                New PlacementInfoBoxTextGenerator)
        End Function

        Public Shared Function CreateDialogForGenericNonSpendningMovement(sc As SmallCard, cc As CardCollection, range As Integer, cancelAction As Action) As CharacterPlacementDialog
            Return CreateDialog(sc,
                                cc,
                                range,
                                PlacementChoice.PlacementTypeEnum.Other,
                                New StandardPlacementRankDeterminer,
                                New StandardPlacementButtonConfiguration(cancelAction),
                                New PlacementInfoBoxTextGenerator)
        End Function

        Private Shared Function CreateDialog(sc As SmallCard, cc As CardCollection, range As Integer, type As PlacementChoice.PlacementTypeEnum, rankDeterminer As IRanksAvailableForPlacementDeterminer, buttons As ButtonConfiguration, textGenerator As IInfoBoxTextGenerator)
            Return New CharacterPlacementDialog(GameEngineObjects.UserInterfaceManipulator,
                                                sc,
                                                cc,
                                                range,
                                                type,
                                                rankDeterminer,
                                                buttons,
                                                textGenerator)
        End Function

    End Class

End Namespace