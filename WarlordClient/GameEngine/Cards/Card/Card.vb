Namespace GameEngine.Cards.Card

    Public MustInherit Class Card

#Region "members"

        Friend _name As String
        Friend _imagePath As String
        Friend _cardType As CardTypeEnum
        Friend _level As Integer
        Friend _classes As List(Of ClassEnum)
        Friend _actions As List(Of PerformableAction)
        Friend _defaultPerformableAction As PerformableAction

#End Region

#Region "ctor"

        Public Sub New()
            _classes = New List(Of ClassEnum)
            _actions = New List(Of PerformableAction)
        End Sub

#End Region

#Region "methods"

        Public Overrides Function ToString() As String
            Return Me.Name
        End Function

        Public Function HelpText() As String
            Return String.Format("{0} - {1}", _cardType.ToString, _name.ToString)
        End Function

        Public Overridable Function StartsInRank() As Integer
            Return _level
        End Function

        Public Overridable Function IsDummy() As Boolean
            Return False
        End Function

        Public Overridable Function GetPerformableActions() As List(Of PerformableAction)
            Return Me.Actions
        End Function

        Public Overridable Function BeginsPlayAs() As CardInstance.State
            Return CardInstance.State.Ready
        End Function

#End Region

#Region "properties"

        Public ReadOnly Property Name As String
            Get
                Return _name
            End Get
        End Property

        Public ReadOnly Property ImagePath As String
            Get
                Return _imagePath
            End Get
        End Property

        Public ReadOnly Property CardType As CardTypeEnum
            Get
                Return _cardType
            End Get
        End Property

        Public ReadOnly Property Level As Integer
            Get
                Return _level
            End Get
        End Property

        Public ReadOnly Property Classes As List(Of ClassEnum)
            Get
                Return _classes
            End Get
        End Property

        Public ReadOnly Property Actions As List(Of PerformableAction)
            Get
                Return _actions
            End Get
        End Property

#End Region

#Region "enums"

        Public Enum CardTypeEnum
            Character
            Action
            Item
        End Enum

        Public Enum ClassEnum
            Any
            None
            Rogue
            Cleric
            Wizard
            Fighter
        End Enum

#End Region

    End Class

End Namespace
