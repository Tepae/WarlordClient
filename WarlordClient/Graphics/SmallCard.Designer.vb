<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SmallCard
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
        Me.imageReady = New System.Windows.Forms.PictureBox()
        Me.imageSpent = New System.Windows.Forms.PictureBox()
        CType(Me.imageReady, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imageSpent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imageReady
        '
        Me.imageReady.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imageReady.Location = New System.Drawing.Point(5, 5)
        Me.imageReady.Name = "imageReady"
        Me.imageReady.Size = New System.Drawing.Size(65, 95)
        Me.imageReady.TabIndex = 2
        Me.imageReady.TabStop = False
        '
        'imageSpent
        '
        Me.imageSpent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imageSpent.Location = New System.Drawing.Point(5, 21)
        Me.imageSpent.Name = "imageSpent"
        Me.imageSpent.Size = New System.Drawing.Size(95, 65)
        Me.imageSpent.TabIndex = 3
        Me.imageSpent.TabStop = False
        Me.imageSpent.Visible = False
        '
        'SmallCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.imageSpent)
        Me.Controls.Add(Me.imageReady)
        Me.Name = "SmallCard"
        Me.Size = New System.Drawing.Size(105, 105)
        CType(Me.imageReady, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imageSpent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imageReady As System.Windows.Forms.PictureBox
    Friend WithEvents imageSpent As System.Windows.Forms.PictureBox

End Class
