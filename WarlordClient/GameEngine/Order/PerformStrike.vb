Namespace GameEngine.Order

    Public Class PerformStrike
        Implements IOrder

        Private _id As Guid
        Private _source As CardInstance
        Private _target As CardInstance
        Private _strike As Strike.Strike
        Private _passTurnWhenDone As Boolean

        Public Sub New(id As Guid, source As CardInstance, target As CardInstance, strike As Strike.Strike)
            Me.New(id, source, target, strike, True)
        End Sub

        Public Sub New(id As Guid, source As CardInstance, target As CardInstance, strike As Strike.Strike, passTurnWhenDone As Boolean)
            _id = id
            _source = source
            _target = target
            _strike = strike
            _passTurnWhenDone = passTurnWhenDone
        End Sub

        Public Sub HandleAfterReacts() Implements IOrder.HandleAfterReacts

        End Sub

        Public Sub HandleBeforeReacts() Implements IOrder.HandleBeforeReacts

        End Sub

        Public Sub Perform(ge As GameEngine) Implements IOrder.Perform
            Dim roll As Integer = Die.Roll
            ge.RaiseSystemMessage(String.Format("{0} rolls a {1}", _source.Card.Name, roll.ToString))
            If (roll + _strike.Modifier >= _target.ArmorClass OrElse roll = 20) AndAlso Not roll = 1 Then
                _strike.OnHit(_source, _target)
                _target.Wound(_strike.Wounds)
                ge.RaiseSystemMessage(String.Format("{0} suffers {1} {2}", _target.Card.Name, _strike.Wounds, If(_strike.Wounds = 1, "wound", "wounds")))
            Else
                ge.RaiseSystemMessage(String.Format("{0} misses", _source.Card.Name))
                _strike.OnMiss(_source, _target)
            End If
        End Sub

        Public Property PassTurnWhenDone As Boolean Implements IOrder.PassTurnWhenDone
            Get
                Return _passTurnWhenDone
            End Get
            Set(value As Boolean)
                _passTurnWhenDone = value
            End Set
        End Property

    End Class

End Namespace
