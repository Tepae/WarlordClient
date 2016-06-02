Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.CostAndEffect.Effect

    Public Class MoveCharacter
        Implements IEffect

        Private ReadOnly _range As Integer
        Private _isPerformed As Boolean
        Private _uim As IUserInterfaceManipulator

        Public Sub New(range As Integer)
            _range = range
        End Sub

        Public Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, uim As IUserInterfaceManipulator, passTurn As Boolean, cancelAction As Action) Implements IEffect.Perform
            _uim = uim
            Dim cm As New CharacterMover(id,
                                         gs,
                                         uim,
                                         CharacterPlacementDialogFactory.CreateDialogForStandardMovement(uim,
                                                                                                         sc,
                                                                                                         gs.GetCollectionById(owner),
                                                                                                         _range,
                                                                                                         cancelAction),
                                         passTurn)
            cm.MoveCharacter()
        End Sub

        Public Sub Cancel() Implements IEffect.Cancel
            If _uim IsNot Nothing Then
                _uim.CleanContextSensitiveVisuals()
            End If
            _isPerformed = False
        End Sub

        Public Function IsPerformed() As Boolean Implements IEffect.IsPerformed
            Return _isPerformed
        End Function

    End Class
End Namespace