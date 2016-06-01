Namespace GameEngine

    Public Class CardInstance

        Private _card As Card.Card
        Private _id As Guid
        Private _location As Location
        Private _state As State
        Private _attachments As List(Of CardInstance)
        Private _attachedTo As CardInstance
        Private _wounds As Integer
        Private _warlord As Boolean

        Public Event CardInstanceHasChanged(sender As Object)

        Public Sub New(card As Card.Card)
            _card = card
            _id = Guid.NewGuid
            _attachments = New List(Of CardInstance)
        End Sub

#Region "properties"

        Public ReadOnly Property Card As Card.Card
            Get
                Return _card
            End Get
        End Property

        Public ReadOnly Property Id As Guid
            Get
                Return _id
            End Get
        End Property

        Public ReadOnly Property Attachments As List(Of CardInstance)
            Get
                Return _attachments
            End Get
        End Property

        Public Property AttachedTo As CardInstance
            Get
                Return _attachedTo
            End Get
            Set(value As CardInstance)
                _attachedTo = value
            End Set
        End Property

        Public Property CardState As State
            Get
                Return _state
            End Get
            Set(value As State)
                _state = value
                RaiseEvent CardInstanceHasChanged(Me)
            End Set
        End Property

        Public Property CardLocation As Location
            Get
                Return _location
            End Get
            Set(value As Location)
                _location = value
            End Set
        End Property

        Public Property Wounds As Integer
            Get
                Return _wounds
            End Get
            Set(value As Integer)
                _wounds = value
            End Set
        End Property

        Public Property Warlord As Boolean
            Get
                Return _warlord
            End Get
            Set(value As Boolean)
                _warlord = value
            End Set
        End Property

#End Region

#Region "methods"

        Public Overrides Function ToString() As String
            Return String.Format("{0} - {1} ({2})", Me.Card.CardType.ToString, Me.Card.Name, Me.Id.ToString)
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            Dim ret As Boolean = False
            If TypeOf (obj) Is CardInstance Then
                ret = DirectCast(obj, CardInstance).Id.Equals(Me.Id)
            End If
            Return ret
        End Function

        Public Function ArmorClass() As Integer
            Return DirectCast(_card, Card.Character)._armorClass
        End Function

        Public Sub Wound(numberOfWounds As Integer)
            Wounds += numberOfWounds
        End Sub

        Public Sub Unspend()
            Select Case CardState
                Case State.Ready
                    'do nothing
                Case State.Spent
                    CardState = State.Ready
                Case State.Stunned
                    CardState = State.Spent
            End Select
        End Sub

#End Region

#Region "enums"

        Public Enum State
            Any 'used for ClickFilter

            Ready
            Spent
            Stunned
        End Enum

        Public Enum Location
            Any  'used for ClickFilter

            InPlay
            InHand
            InDiscardPile
            InDeck
            OnStack
            RemovedFromGame
        End Enum

#End Region

    End Class

End Namespace