Imports WarlordClient.GameEngine.Strike

Namespace GameEngine.CostAndEffect.Effect

    Public Class PerformStrikeEffect
        Implements IEffect

        Private ReadOnly _ss As StrikeSet
        Private _id As Guid
        Private _owner As Guid
        Private _sc As SmallCard
        Private _gs As GameState
        Private _cancelAction As Action
        Private _index As Integer = -1

        Public Sub New(ss As StrikeSet)
            _ss = ss
        End Sub

        Public Sub Perform(id As Guid, owner As Guid, sc As SmallCard, gs As GameState, passTurn As Boolean, cancelAction As Action) Implements IEffect.Perform
            _id = id
            _owner = owner
            _sc = sc
            _gs = gs
            _cancelAction = cancelAction
            NextStrike()
        End Sub

        Private Sub NextStrike()
            _index += 1
            If _index < _ss.Count() Then
                Dim sp As New StrikePerformer(_id, _owner, _sc, _gs, _ss.GetStrike(_index), AddressOf NextStrike, _cancelAction, _index = 0, _index = _ss.Count() - 1)
                sp.Perform()
            End If
        End Sub

        Public Function IsPerformed() As Boolean Implements IEffect.IsPerformed
            Return _index >= _ss.Count()
        End Function

    End Class

End Namespace