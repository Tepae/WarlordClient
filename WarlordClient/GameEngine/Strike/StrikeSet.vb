Namespace GameEngine.Strike

    Public Class StrikeSet

        Private _spend As Boolean
        Private _targetingType As TargetingTypeEnum
        Private ReadOnly _strikes As List(Of Strike)
        Private ReadOnly _strikeType As Strike.StrikeTypeEnum = Strike.StrikeTypeEnum.None

        Public Sub New(spend As Boolean, targetingType As TargetingTypeEnum, ByVal ParamArray strikes() As Strike)
            _spend = spend
            _targetingType = targetingType
            _strikes = New List(Of Strike)
            For i As Integer = 0 To strikes.Length - 1 Step 1
                Dim s As Strike = strikes(i)
                If _strikeType = Strike.StrikeTypeEnum.None OrElse _strikeType = s.StrikeType Then
                    _strikeType = s.StrikeType
                    _strikes.Add(s)
                End If
            Next
        End Sub

        Public Function Count() As Integer
            Return _strikes.Count
        End Function

        Public Function GetStrike(index As Integer) As Strike
            Dim ret = Nothing
            If _strikes.Count > index Then
                ret = _strikes(index)
            End If
            Return ret
        End Function

        Public Overrides Function ToString() As String
            Dim ret As String = String.Empty
            If _spend Then
                ret += "Spend to perform "
            Else
                ret += "Perform "
            End If
            ret += _strikeType.ToString.ToLower
            ret += " strike ("
            For Each st As Strike In _strikes
                ret += "+" & st.Modifier.ToString
                If _strikes.Last.Equals(st) Then
                    ret += ")"
                Else
                    ret += "/"
                End If
            Next
            Return ret
        End Function

        Public Enum TargetingTypeEnum
            None
            Consecutive
            Simultaneous
        End Enum

    End Class

End Namespace
