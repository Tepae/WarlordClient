Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine

    Public Interface IUserInterfaceManipulator
        Sub SetActiveFilterForPlayer()
        Sub SetInactiveFilterForPlayer()
        Sub SetFilterForPlayer(cf As ClickFilter.ClickFilter, cb As ClickFilter.ClickFilterManager.Callback)
        Sub SetInfoBox(data As InfoboxData)
        Sub SetInfoboxToDefault()
        Sub DrawPlacementDotsToCardGrid(id As Guid, sc As SmallCard, movementChoices As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice))
        Sub ClearPlacementDotsFromCardGrid(id As Guid)
    End Interface

End Namespace