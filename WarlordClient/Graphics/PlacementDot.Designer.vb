Namespace Graphics
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class PlacementDot
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            Try
                If disposing AndAlso components IsNot Nothing Then
                    components.Dispose()
                End If
            Finally
                MyBase.Dispose(disposing)
            End Try
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()>
        Private Sub InitializeComponent()
            Me.pBoxDot = New System.Windows.Forms.PictureBox()
            CType(Me.pBoxDot, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'pBoxDot
            '
            Me.pBoxDot.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                        Or System.Windows.Forms.AnchorStyles.Left) _
                                       Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.pBoxDot.Image = Global.WarlordClient.My.Resources.Resources.placementdot
            Me.pBoxDot.Location = New System.Drawing.Point(0, 0)
            Me.pBoxDot.Name = "pBoxDot"
            Me.pBoxDot.Size = New System.Drawing.Size(11, 13)
            Me.pBoxDot.TabIndex = 0
            Me.pBoxDot.TabStop = False
            '
            'PlacementDot
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.pBoxDot)
            Me.Name = "PlacementDot"
            Me.Size = New System.Drawing.Size(13, 15)
            CType(Me.pBoxDot, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents pBoxDot As System.Windows.Forms.PictureBox

    End Class
End Namespace