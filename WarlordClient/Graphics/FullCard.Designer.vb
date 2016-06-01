<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FullCard
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.image = New System.Windows.Forms.PictureBox()
        CType(Me.image, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'image
        '
        Me.image.Location = New System.Drawing.Point(0, 0)
        Me.image.Name = "image"
        Me.image.Size = New System.Drawing.Size(390, 546)
        Me.image.TabIndex = 0
        Me.image.TabStop = False
        '
        'FullCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.image)
        Me.Name = "FullCard"
        Me.Size = New System.Drawing.Size(390, 546)
        CType(Me.image, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents image As System.Windows.Forms.PictureBox

End Class
