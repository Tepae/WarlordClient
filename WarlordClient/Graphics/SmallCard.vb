Imports WarlordClient.GameEngine
Imports WarlordClient.GameEngine.CardInstance

Public Class SmallCard

#Region "members"

    Private WithEvents _card As CardInstance
    Private _readyImageState As State
    Private ReadOnly _toolTip As ToolTip

    Public Event MouseHoverOverMe(sender As Object, e As EventArgs)
    Public Event MouseClickOnMe(sender As Object, e As MouseEventArgs)
    Public Event CardInstanceHasChanged(sender As Object)

#End Region

#Region "ctor"

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(card As CardInstance)
        InitializeComponent()
        _card = card
        _toolTip = New ToolTip()
    End Sub

#End Region

    Private Sub UpdateShowState(ByVal s As State)
        Select Case s
            Case State.Ready
                Me.imageSpent.Hide()
                If _readyImageState = State.Stunned Then
                    Me.imageReady.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                End If
                Me.imageReady.Show()
                _readyImageState = s
            Case State.Spent
                Me.imageReady.Hide()
                Me.imageSpent.Show()
            Case State.Stunned
                Me.imageSpent.Hide()
                If _readyImageState = State.Ready Then
                    Me.imageReady.Image.RotateFlip(RotateFlipType.Rotate180FlipNone)
                End If
                Me.imageReady.Show()
                _readyImageState = s
        End Select
    End Sub

    Public Sub SetToolTip()
        _toolTip.RemoveAll()
        _toolTip.AutoPopDelay = 5000
        _toolTip.InitialDelay = 1000
        _toolTip.ReshowDelay = 500
        _toolTip.SetToolTip(Me.imageSpent, _card.Card.HelpText)
        _toolTip.SetToolTip(Me.imageReady, _card.Card.HelpText)
    End Sub

    Private Sub LoadImageFromCard()
        Dim imagePath As String = Constants.ExecutablePath & _card.Card.ImagePath
        Me.imageReady.Load(imagePath)
        Me.imageSpent.Load(imagePath)
        UpdateShowState(_card.CardState)
        SetToolTip()
    End Sub

    Private Sub RaiseMouseHoverEvent(e As EventArgs)
        RaiseEvent MouseHoverOverMe(Me, e)
    End Sub

    Private Sub RaiseMouseClickEvent(e As MouseEventArgs)
        RaiseEvent MouseClickOnMe(Me, e)
    End Sub

    Private Sub RaiseCardInstanceChangedEvent(sender As Object)
        RaiseEvent CardInstanceHasChanged(sender)
    End Sub

#Region "eventhandlers"

    Private Sub SmallCard_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If _card IsNot Nothing Then
            Me._readyImageState = State.Ready
            LoadImageFromCard()
            Me.imageReady.SizeMode = PictureBoxSizeMode.StretchImage
            Me.imageSpent.SizeMode = PictureBoxSizeMode.StretchImage
            Me.imageSpent.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
        End If
    End Sub

    Private Sub BothImagesMouseHover(sender As Object, e As System.EventArgs) Handles imageReady.MouseHover, imageSpent.MouseHover
        RaiseMouseHoverEvent(e)
    End Sub

    Private Sub BothImagesMouseClick(sender As Object, e As MouseEventArgs) Handles imageReady.MouseClick, imageSpent.MouseClick
        RaiseMouseClickEvent(e)
    End Sub

    Private Sub _card_CardInstanceHasChanged(sender As Object) Handles _card.CardInstanceHasChanged
        RaiseCardInstanceChangedEvent(sender)
    End Sub

#End Region

#Region "properties"

    Public ReadOnly Property Card As CardInstance
        Get
            Return _card
        End Get
    End Property

    Public ReadOnly Property ParentAsCardGrid As CardGrid
        Get
            Return DirectCast(Me.Parent, CardGrid)
        End Get
    End Property

#End Region

End Class
