Namespace GameEngine.Order
    Public Class PerformStrike
        Implements IOrder

        Private ReadOnly _id As Guid
        Private ReadOnly _source As SmallCard
        Private ReadOnly _target As SmallCard
        Private ReadOnly _strike As Strike.Strike
        Private ReadOnly _uim As UserInterfaceManipulator = GameEngineObjects.UserInterfaceManipulator

        Public Sub New(id As Guid, source As SmallCard, target As SmallCard, strike As Strike.Strike)
            _id = id
            _source = source
            _target = target
            _strike = strike
        End Sub

        Public Sub Perform(owner As Guid, gs As GameState) Implements IOrder.Perform
            SystemMessage(String.Format("{0} targets {1} with a {2} strike ({3}{4})", _source.Card.Card.Name,
                                                  _target.Card.Card.Name,
                                                  _strike.StrikeType.ToString().ToLower(), If(_strike.Modifier > -1, "+", "-"),
                                                  _strike.Modifier))
            Dim roll As Integer = Die.Roll()
            SystemMessage(String.Format("{0} rolls a {1}", _source.Card.Card.Name, roll.ToString()))
            If ((roll + _strike.Modifier) >= _target.Card.ArmorClass() OrElse roll = 20) AndAlso (Not roll = 1) Then
                _strike.OnHit(_source.Card, _target.Card)
                _target.Card.Wounds += _strike.Wounds
                SystemMessage(String.Format("{0} suffers {1} {2}", _target.Card.Card.Name, _strike.Wounds, If(_strike.Wounds > 1, "wounds", "wound")))
            Else
                SystemMessage(String.Format("{0} misses", _source.Card.Card.Name))
                _strike.OnMiss(_source.Card, _target.Card)
            End If
        End Sub

        Private Sub SystemMessage(message As String)
            _uim.RaiseSystemMessage(message)
        End Sub

        Public Function Id() As Guid Implements IOrder.Id
            Return _id
        End Function

    End Class
End Namespace