Namespace GameEngine.CharacterMovement

    ' ReSharper disable once ClassNeverInstantiated.Global
    Public Class CharacterPlacementDialogFactory

        Public Shared Function CreateDialogForStandardMovement(ge As IUserInterfaceManipulator, sc As SmallCard, cc As CardCollection, range As Integer) As CharacterPlacementDialog
            Return CreateDialog(ge,
                                sc,
                                cc,
                                range,
                                PlacementChoice.PlacementTypeEnum.Regular,
                                New StandardPlacementRankDeterminer,
                                New StandardPlacementButtonConfiguration(ge),
                                New PlacementInfoBoxTextGenerator)
        End Function

        Public Shared Function CreateDialogForIllegalRank(ge As IUserInterfaceManipulator, sc As SmallCard, cc As CardCollection) As CharacterPlacementDialog
            Return CreateDialog(ge,
                                sc,
                                cc,
                                1,
                                PlacementChoice.PlacementTypeEnum.IllegalRank,
                                New IllegalRankMovementRankDeterminer,
                                New IllegalRankButtonConfiguration(ge),
                                New PlacementInfoBoxTextGenerator)
        End Function

        Public Shared Function CreateDialogForGenericNonSpendningMovement(ge As IUserInterfaceManipulator, sc As SmallCard, cc As CardCollection, range As Integer) As CharacterPlacementDialog
            Return CreateDialog(ge,
                                sc,
                                cc,
                                range,
                                PlacementChoice.PlacementTypeEnum.Other,
                                New StandardPlacementRankDeterminer,
                                New StandardPlacementButtonConfiguration(ge),
                                New PlacementInfoBoxTextGenerator)
        End Function

        Private Shared Function CreateDialog(ge As IUserInterfaceManipulator, sc As SmallCard, cc As CardCollection, range As Integer, type As PlacementChoice.PlacementTypeEnum, rankDeterminer As IRanksAvalibleForPlacementDeterminer, buttons As ButtonConfiguration, textGenerator As IInfoBoxTextGenerator)
            Return New CharacterPlacementDialog(ge,
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