Namespace GameEngine.Strike

    Public Class Strike

        Private _strikeType As StrikeTypeEnum
        Private _modifier As Integer
        Private _minRange As Integer
        Private _maxRange As Integer
        Private _wounds As Integer
        Private _characterStateResult As CharacterStateResultEnum
        Private _onHit As Action(Of CardInstance, CardInstance) = Nothing
        Private _onMiss As Action(Of CardInstance, CardInstance) = Nothing

        Public Sub New(strikeType As StrikeTypeEnum, modifier As Integer, minRange As Integer, maxRange As Integer, characterStateResult As CharacterStateResultEnum)
            Me.New(strikeType, modifier, minRange, maxRange, 1, characterStateResult)
        End Sub

        Public Sub New(strikeType As StrikeTypeEnum, modifier As Integer, minRange As Integer, maxRange As Integer, characterStateResult As CharacterStateResultEnum, wounds As Integer)
            _strikeType = strikeType
            _modifier = modifier
            _minRange = minRange
            _maxRange = maxRange
            _wounds = wounds
            _characterStateResult = characterStateResult
        End Sub

        Public Property StrikeType As StrikeTypeEnum
            Get
                Return _strikeType
            End Get
            Set(value As StrikeTypeEnum)
                _strikeType = value
            End Set
        End Property

        Public Property Modifier As Integer
            Get
                Return _modifier
            End Get
            Set(value As Integer)
                _modifier = value
            End Set
        End Property

        Public Property MinRange As Integer
            Get
                Return _minRange
            End Get
            Set(value As Integer)
                _minRange = value
            End Set
        End Property

        Public Property MaxRange As Integer
            Get
                Return _maxRange
            End Get
            Set(value As Integer)
                _maxRange = value
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

        Public Property CharacterStateResult As CharacterStateResultEnum
            Get
                Return _characterStateResult
            End Get
            Set(value As CharacterStateResultEnum)
                _characterStateResult = value
            End Set
        End Property

        Public Sub OnHit(source As CardInstance, target As CardInstance)
            If _onHit IsNot Nothing Then
                _onHit.Invoke(source, target)
            End If
        End Sub

        Public Sub OnMiss(source As CardInstance, target As CardInstance)
            If _onMiss IsNot Nothing Then
                _onMiss.Invoke(source, target)
            End If
        End Sub

        Public Enum StrikeTypeEnum
            None
            Melee
            Ranged
        End Enum

        Public Enum CharacterStateResultEnum
            NoChange
            Spent
            Stunned
        End Enum

    End Class

End Namespace