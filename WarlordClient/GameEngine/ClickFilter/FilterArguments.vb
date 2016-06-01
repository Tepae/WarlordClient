Namespace GameEngine.ClickFilter

    Public Class FilterArguments

        Private _owner As Guid = Guid.Empty
        Private _location As CardInstance.Location = CardInstance.Location.Any
        Private _state As CardInstance.State = CardInstance.State.Any
        Private _rank As Integer = -1
        Private _distance As Integer = -1
        Private _source As CardInstance

        Public Property Owner As Guid
            Get
                Return _owner
            End Get
            Set(value As Guid)
                _owner = value
            End Set
        End Property

        Public Property Location As CardInstance.Location
            Get
                Return _location
            End Get
            Set(value As CardInstance.Location)
                _location = value
            End Set
        End Property

        Public Property State As CardInstance.State
            Get
                Return _state
            End Get
            Set(value As CardInstance.State)
                _state = value
            End Set
        End Property

        Public Property Rank As Integer
            Get
                Return _rank
            End Get
            Set(value As Integer)
                _rank = value
            End Set
        End Property

        Public Property Distance As Integer
            Get
                Return _distance
            End Get
            Set(value As Integer)
                _distance = value
            End Set
        End Property

        Public Property Source As CardInstance
            Get
                Return _source
            End Get
            Set(value As CardInstance)
                _source = value
            End Set
        End Property

    End Class

End Namespace