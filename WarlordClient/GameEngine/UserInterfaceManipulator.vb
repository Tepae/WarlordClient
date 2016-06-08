Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine

    Public Class UserInterfaceManipulator

        Private ReadOnly _ge As IGameEngineUserInterfaceManipulator

        Public Sub New(ge As IGameEngineUserInterfaceManipulator)
            _ge = ge
        End Sub

        Public Sub SetActiveFilterForPlayer()
            _ge.SetActiveFilterForPlayer()
        End Sub

        Public Sub SetInactiveFilterForPlayer()
            _ge.SetInactiveFilterForPlayer()
        End Sub

        Public Sub SetFilterForPlayer(cf As ClickFilter.ClickFilter, cb As ClickFilter.ClickFilterManager.Callback)
            _ge.SetFilterForPlayer(cf, cb)
        End Sub

        Public Sub SetInfoBox(data As InfoboxData)
            _ge.SetInfoBox(data)
        End Sub

        Public Sub SetInfoboxToDefault()
            _ge.SetInfoboxToDefault()
        End Sub

        Public Sub DrawPlacementDotsToCardGrid(id As Guid, sc As SmallCard, placementChoices As List(Of PlacementChoice), callback As Action(Of SmallCard, PlacementChoice))
            _ge.DrawPlacementDotsToCardGrid(id, sc, placementChoices, callback)
        End Sub

        Public Sub ClearPlacementDotsFromCardGrid(id As Guid)
            _ge.ClearPlacementDotsFromCardGrid(id)
        End Sub

        Public Sub CleanContextSensitiveVisuals()
            _ge.CleanContextSensitiveVisuals()
        End Sub

        Public Sub RaiseSystemMessage(message As String)
            _ge.RaiseSystemMessage(message)
        End Sub

    End Class

End Namespace