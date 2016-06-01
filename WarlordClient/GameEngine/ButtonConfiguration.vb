Namespace GameEngine

    Public Class ButtonConfiguration

        Private _showOKButton As Boolean
        Private _showCancelButton As Boolean
        Private _showDoneButton As Boolean
        Private _okCallback As Action
        Private _cancelCallback As Action
        Private _doneCallback As Action

        Public Sub New()
            Me.New(True, True, True, Nothing, Nothing, Nothing)
        End Sub

        Public Sub New(showOKButton As Boolean, showCancelButton As Boolean, showDoneButton As Boolean)
            Me.New(showOKButton, showCancelButton, showDoneButton, Nothing, Nothing, Nothing)
        End Sub

        Public Sub New(showOKButton As Boolean, showCancelButton As Boolean, showDoneButton As Boolean, okCallback As Action, cancelCallback As Action, doneCallback As Action)
            _showOKButton = showOKButton
            _showCancelButton = showCancelButton
            _showDoneButton = showDoneButton
            _okCallback = okCallback
            _cancelCallback = cancelCallback
            _doneCallback = doneCallback
        End Sub

        Public ReadOnly Property EnableOKButton As Boolean
            Get
                Return _showOKButton
            End Get
        End Property

        Public ReadOnly Property EnableCancelButton As Boolean
            Get
                Return _showCancelButton
            End Get
        End Property

        Public ReadOnly Property EnableDoneButton As Boolean
            Get
                Return _showDoneButton
            End Get
        End Property

        Public ReadOnly Property OKCallback As Action
            Get
                Return _okCallback
            End Get
        End Property

        Public ReadOnly Property CancelCallback As Action
            Get
                Return _cancelCallback
            End Get
        End Property

        Public ReadOnly Property DoneCallback As Action
            Get
                Return _doneCallback
            End Get
        End Property

    End Class

End Namespace