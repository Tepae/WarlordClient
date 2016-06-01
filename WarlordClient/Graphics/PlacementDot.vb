Imports WarlordClient.GameEngine.CharacterMovement

Namespace Graphics

    Public Class PlacementDot

        Public Event DotClicked(sender As Object, e As EventArgs)

        Private Sub PlacementDot_Load(sender As Object, e As EventArgs) Handles Me.Load
            pBoxDot.BackColor = Color.Transparent
        End Sub

        Private Sub pBoxDot_MouseClick(sender As Object, e As MouseEventArgs) Handles pBoxDot.MouseClick
            If e.Button = Windows.Forms.MouseButtons.Left Then
                RaiseEvent DotClicked(Me, New EventArgs)
            End If
        End Sub

        Public Property MovementChoice As PlacementChoice

        Public Property Smallcard As SmallCard

    End Class
End Namespace