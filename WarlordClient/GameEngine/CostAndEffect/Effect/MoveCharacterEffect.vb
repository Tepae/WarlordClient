Imports WarlordClient.GameEngine.CharacterMovement

Namespace GameEngine.CostAndEffect.Effect

    Public Class MoveCharacterEffect
        Implements IEffect

        Private ReadOnly _range As Integer
        Private ReadOnly _excludeOwnRank As Boolean
        Private _isPerformed As Boolean

        Public Sub New(range As Integer, excludeOwnRank As Boolean)
            _range = range
            _excludeOwnRank = excludeOwnRank
        End Sub

        Public Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, passTurn As Boolean, cancelAction As Action) Implements IEffect.Perform
            Dim cm As New CharacterMover(id,
                                         gs,
                                         CharacterPlacementDialogFactory.CreateDialogForStandardMovement(sc,
                                                                                                         gs.GetCollectionById(owner),
                                                                                                         _range,
                                                                                                         _excludeOwnRank,
                                                                                                         cancelAction),
                                         passTurn)
            cm.MoveCharacter()
        End Sub

        Public Function IsPerformed() As Boolean Implements IEffect.IsPerformed
            Return _isPerformed
        End Function

    End Class
End Namespace