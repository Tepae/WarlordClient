Namespace GameEngine.CharacterMovement

    Public Class PlacementChoice

        Private _rank As Integer
        Private _left As CardInstance
        Private _right As CardInstance
        Private _placementType As PlacementTypeEnum

        Public Sub New(rank As Integer, left As CardInstance, right As CardInstance, placementType As PlacementTypeEnum)
            _rank = rank
            _left = left
            _right = right
            _placementType = placementType
        End Sub

        Public Overrides Function ToString() As String
            Dim ret As String = String.Empty
            Select Case _placementType
                Case PlacementTypeEnum.Regular, PlacementTypeEnum.IllegalRank
                    ret = String.Format("To rank {0}, between {1} and {2}", _rank.ToString, If(_left Is Nothing, "None", _left.Card.Name), If(_right Is Nothing, "None", _right.Card.Name))
            End Select
            Return ret
        End Function

        Public ReadOnly Property Rank As Integer
            Get
                Return _rank
            End Get
        End Property

        Public ReadOnly Property Left As CardInstance
            Get
                Return _left
            End Get
        End Property

        Public ReadOnly Property Right As CardInstance
            Get
                Return _right
            End Get
        End Property

        Public ReadOnly Property Type As PlacementTypeEnum
            Get
                Return _placementType
            End Get
        End Property

        Public Enum PlacementTypeEnum
            Regular
            IllegalRank
            PlayFromHand
            Other
        End Enum

    End Class

End Namespace