Namespace GameEngine.Strike

    Public Class Strike
        Private _onHit As Action(Of CardInstance, CardInstance) = Nothing
        Private _onMiss As Action(Of CardInstance, CardInstance) = Nothing

        Public Sub New(strikeType As StrikeTypeEnum, modifier As Integer, minRange As Integer, maxRange As Integer)
            Me.New(strikeType, modifier, minRange, maxRange, 1)
        End Sub

        Public Sub New(strikeType As StrikeTypeEnum, modifier As Integer, minRange As Integer, maxRange As Integer, wounds As Integer)
            Me.StrikeType = strikeType
            Me.Modifier = modifier
            Me.MinRange = minRange
            Me.MaxRange = maxRange
            Me.Wounds = wounds
        End Sub

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

        Public Property StrikeType As StrikeTypeEnum

        Public Property Modifier As Integer

        Public Property MinRange As Integer

        Public Property MaxRange As Integer

        Public Property Wounds As Integer

        Public Enum StrikeTypeEnum
            None
            Melee
            Ranged
        End Enum
    End Class

End Namespace