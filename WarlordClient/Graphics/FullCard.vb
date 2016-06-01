Public Class FullCard

    Public Sub UpdateImage(card As GameEngine.Card.Card)
        Dim path As String = Constants.ExecutablePath & card.ImagePath
        Me.image.Load(path)
    End Sub

    Private Sub FullCard_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.image.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

End Class
