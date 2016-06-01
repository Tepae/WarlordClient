Namespace GameEngine.ClickFilter

    Public Class Filter
        Implements IFilter

#Region "members"

        Private _filters As List(Of IFilter)
        Private _operator As LogicalOperatorEnum

#End Region

#Region "ctor"

        Public Sub New()
            Me.New(LogicalOperatorEnum.And)
        End Sub

        Public Sub New(logicalOperator As LogicalOperatorEnum)
            Me.New(logicalOperator, (New List(Of IFilter)).ToArray)
        End Sub

        Public Sub New(logicalOperator As LogicalOperatorEnum, ByVal ParamArray filters As IFilter())
            _filters = New List(Of IFilter)
            _operator = logicalOperator
            For i As Integer = 0 To filters.Length - 1 Step 1
                _filters.Add(filters(i))
            Next
        End Sub

#End Region

#Region "methods"

        Public Sub Add(f As IFilter)
            _filters.Add(f)
        End Sub

        Public Function Evaluate(args As FilterArguments) As Boolean Implements IFilter.Evaluate
            Dim ret As Boolean = False
            Select Case _operator
                Case LogicalOperatorEnum.And
                    For Each f As IFilter In _filters
                        ret = f.Evaluate(args)
                        If Not ret Then
                            Exit For
                        End If
                    Next
                Case LogicalOperatorEnum.Or
                    For Each f As IFilter In _filters
                        ret = f.Evaluate(args)
                        If ret Then
                            Exit For
                        End If
                    Next
                Case LogicalOperatorEnum.Xor
                    Dim wasTrue As Boolean = False
                    For Each f As IFilter In _filters
                        wasTrue = f.Evaluate(args)
                        If Not ret Then
                            ret = wasTrue
                        Else
                            If wasTrue Then
                                ret = False
                                Exit For
                            End If
                        End If
                    Next
                Case LogicalOperatorEnum.Not
                    For Each f As IFilter In _filters
                        ret = f.Evaluate(args)
                    Next
                    ret = Not ret
            End Select
            Return ret
        End Function

#End Region

#Region "properties"

        Friend ReadOnly Property Filters As List(Of IFilter)
            Get
                Return _filters
            End Get
        End Property

        Public Property LogicalOperator As LogicalOperatorEnum
            Get
                Return _operator
            End Get
            Set(value As LogicalOperatorEnum)
                _operator = value
            End Set
        End Property

#End Region

#Region "enums"

        Public Enum LogicalOperatorEnum
            [And]
            [Or]
            [Not]
            [Xor]
        End Enum

#End Region

    End Class

End Namespace