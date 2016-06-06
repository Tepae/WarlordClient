Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.CostAndEffect.Effect

    Public Class MoveCharacterEffect
        Implements IEffect

        Private ReadOnly _range As Integer
        Private _isPerformed As Boolean

        Public Sub New(range As Integer)
            _range = range
        End Sub

        Public Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, passTurn As Boolean, cancelAction As Action) Implements IEffect.Perform
            Dim cm As New CharacterMover(id,
                                         gs,
                                         CharacterPlacementDialogFactory.CreateDialogForStandardMovement(sc,
                                                                                                         gs.GetCollectionById(owner),
                                                                                                         _range,
                                                                                                         cancelAction),
                                         passTurn)
            cm.MoveCharacter()
        End Sub

        Public Sub Cancel() Implements IEffect.Cancel
            GameEngineObjects.UserInterfaceManipulator.CleanContextSensitiveVisuals()
            _isPerformed = False
        End Sub

        Public Function IsPerformed() As Boolean Implements IEffect.IsPerformed
            Return _isPerformed
        End Function

    End Class
End Namespace