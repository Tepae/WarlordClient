Imports WarlordClient.GameEngine.Cards.Card

Public Class DisplayCard

    Public Sub UpdateImage(card As Card)
        Dim path As String = Constants.ExecutablePath & card.ImagePath
        Me.image.Load(path)
    End Sub

    Private Sub DisplayCard_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Me.image.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

End Class
