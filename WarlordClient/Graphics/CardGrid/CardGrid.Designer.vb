<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CardGrid
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
        Me.lblOwnerTop = New System.Windows.Forms.Label()
        Me.lblOwnerBottom = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblOwnerTop
        '
        Me.lblOwnerTop.AutoSize = True
        Me.lblOwnerTop.Location = New System.Drawing.Point(3, 0)
        Me.lblOwnerTop.Name = "lblOwnerTop"
        Me.lblOwnerTop.Size = New System.Drawing.Size(39, 13)
        Me.lblOwnerTop.TabIndex = 0
        Me.lblOwnerTop.Text = "Label1"
        '
        'lblOwnerBottom
        '
        Me.lblOwnerBottom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOwnerBottom.AutoSize = True
        Me.lblOwnerBottom.Location = New System.Drawing.Point(3, 513)
        Me.lblOwnerBottom.Name = "lblOwnerBottom"
        Me.lblOwnerBottom.Size = New System.Drawing.Size(39, 13)
        Me.lblOwnerBottom.TabIndex = 1
        Me.lblOwnerBottom.Text = "Label1"
        '
        'CardGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightYellow
        Me.Controls.Add(Me.lblOwnerBottom)
        Me.Controls.Add(Me.lblOwnerTop)
        Me.Name = "CardGrid"
        Me.Size = New System.Drawing.Size(1182, 526)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblOwnerTop As System.Windows.Forms.Label
    Friend WithEvents lblOwnerBottom As System.Windows.Forms.Label

End Class
