<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectGameTypeForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.gBoxGameType = New System.Windows.Forms.GroupBox()
        Me.rBtnOnline = New System.Windows.Forms.RadioButton()
        Me.rBtnLocal = New System.Windows.Forms.RadioButton()
        Me.gBoxConnectionSettings = New System.Windows.Forms.GroupBox()
        Me.txtHostOnPort = New System.Windows.Forms.TextBox()
        Me.lblHostOnPort = New System.Windows.Forms.Label()
        Me.txtConnectOnPort = New System.Windows.Forms.TextBox()
        Me.lblConnectoOnPort = New System.Windows.Forms.Label()
        Me.txtConnectTo = New System.Windows.Forms.TextBox()
        Me.rBtnConnectoToOpponent = New System.Windows.Forms.RadioButton()
        Me.txtHostOn = New System.Windows.Forms.TextBox()
        Me.rBtnHostGame = New System.Windows.Forms.RadioButton()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnConsole = New System.Windows.Forms.Button()
        Me.gBoxGameType.SuspendLayout()
        Me.gBoxConnectionSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'gBoxGameType
        '
        Me.gBoxGameType.Controls.Add(Me.rBtnOnline)
        Me.gBoxGameType.Controls.Add(Me.rBtnLocal)
        Me.gBoxGameType.Location = New System.Drawing.Point(12, 12)
        Me.gBoxGameType.Name = "gBoxGameType"
        Me.gBoxGameType.Size = New System.Drawing.Size(194, 72)
        Me.gBoxGameType.TabIndex = 0
        Me.gBoxGameType.TabStop = False
        Me.gBoxGameType.Text = "Game type"
        '
        'rBtnOnline
        '
        Me.rBtnOnline.AutoSize = True
        Me.rBtnOnline.Location = New System.Drawing.Point(6, 42)
        Me.rBtnOnline.Name = "rBtnOnline"
        Me.rBtnOnline.Size = New System.Drawing.Size(76, 17)
        Me.rBtnOnline.TabIndex = 1
        Me.rBtnOnline.Text = "Play online"
        Me.rBtnOnline.UseVisualStyleBackColor = True
        '
        'rBtnLocal
        '
        Me.rBtnLocal.AutoSize = True
        Me.rBtnLocal.Checked = True
        Me.rBtnLocal.Location = New System.Drawing.Point(6, 19)
        Me.rBtnLocal.Name = "rBtnLocal"
        Me.rBtnLocal.Size = New System.Drawing.Size(77, 17)
        Me.rBtnLocal.TabIndex = 1
        Me.rBtnLocal.TabStop = True
        Me.rBtnLocal.Text = "Play locally"
        Me.rBtnLocal.UseVisualStyleBackColor = True
        '
        'gBoxConnectionSettings
        '
        Me.gBoxConnectionSettings.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gBoxConnectionSettings.Controls.Add(Me.txtHostOnPort)
        Me.gBoxConnectionSettings.Controls.Add(Me.lblHostOnPort)
        Me.gBoxConnectionSettings.Controls.Add(Me.txtConnectOnPort)
        Me.gBoxConnectionSettings.Controls.Add(Me.lblConnectoOnPort)
        Me.gBoxConnectionSettings.Controls.Add(Me.txtConnectTo)
        Me.gBoxConnectionSettings.Controls.Add(Me.rBtnConnectoToOpponent)
        Me.gBoxConnectionSettings.Controls.Add(Me.txtHostOn)
        Me.gBoxConnectionSettings.Controls.Add(Me.rBtnHostGame)
        Me.gBoxConnectionSettings.Location = New System.Drawing.Point(212, 12)
        Me.gBoxConnectionSettings.Name = "gBoxConnectionSettings"
        Me.gBoxConnectionSettings.Size = New System.Drawing.Size(294, 129)
        Me.gBoxConnectionSettings.TabIndex = 1
        Me.gBoxConnectionSettings.TabStop = False
        Me.gBoxConnectionSettings.Text = "Connection settings"
        '
        'txtHostOnPort
        '
        Me.txtHostOnPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHostOnPort.Enabled = False
        Me.txtHostOnPort.Location = New System.Drawing.Point(178, 43)
        Me.txtHostOnPort.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHostOnPort.Name = "txtHostOnPort"
        Me.txtHostOnPort.Size = New System.Drawing.Size(108, 20)
        Me.txtHostOnPort.TabIndex = 8
        '
        'lblHostOnPort
        '
        Me.lblHostOnPort.AutoSize = True
        Me.lblHostOnPort.Location = New System.Drawing.Point(133, 46)
        Me.lblHostOnPort.Name = "lblHostOnPort"
        Me.lblHostOnPort.Size = New System.Drawing.Size(40, 13)
        Me.lblHostOnPort.TabIndex = 7
        Me.lblHostOnPort.Text = "on port"
        '
        'txtConnectOnPort
        '
        Me.txtConnectOnPort.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectOnPort.Enabled = False
        Me.txtConnectOnPort.Location = New System.Drawing.Point(181, 105)
        Me.txtConnectOnPort.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConnectOnPort.Name = "txtConnectOnPort"
        Me.txtConnectOnPort.Size = New System.Drawing.Size(108, 20)
        Me.txtConnectOnPort.TabIndex = 6
        '
        'lblConnectoOnPort
        '
        Me.lblConnectoOnPort.AutoSize = True
        Me.lblConnectoOnPort.Location = New System.Drawing.Point(136, 108)
        Me.lblConnectoOnPort.Name = "lblConnectoOnPort"
        Me.lblConnectoOnPort.Size = New System.Drawing.Size(40, 13)
        Me.lblConnectoOnPort.TabIndex = 5
        Me.lblConnectoOnPort.Text = "on port"
        '
        'txtConnectTo
        '
        Me.txtConnectTo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtConnectTo.Enabled = False
        Me.txtConnectTo.Location = New System.Drawing.Point(136, 78)
        Me.txtConnectTo.Margin = New System.Windows.Forms.Padding(2)
        Me.txtConnectTo.Name = "txtConnectTo"
        Me.txtConnectTo.Size = New System.Drawing.Size(153, 20)
        Me.txtConnectTo.TabIndex = 4
        '
        'rBtnConnectoToOpponent
        '
        Me.rBtnConnectoToOpponent.AutoSize = True
        Me.rBtnConnectoToOpponent.Checked = True
        Me.rBtnConnectoToOpponent.Enabled = False
        Me.rBtnConnectoToOpponent.Location = New System.Drawing.Point(6, 81)
        Me.rBtnConnectoToOpponent.Name = "rBtnConnectoToOpponent"
        Me.rBtnConnectoToOpponent.Size = New System.Drawing.Size(125, 17)
        Me.rBtnConnectoToOpponent.TabIndex = 3
        Me.rBtnConnectoToOpponent.TabStop = True
        Me.rBtnConnectoToOpponent.Text = "Connect to opponent"
        Me.rBtnConnectoToOpponent.UseVisualStyleBackColor = True
        '
        'txtHostOn
        '
        Me.txtHostOn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtHostOn.Enabled = False
        Me.txtHostOn.Location = New System.Drawing.Point(136, 19)
        Me.txtHostOn.Margin = New System.Windows.Forms.Padding(2)
        Me.txtHostOn.Name = "txtHostOn"
        Me.txtHostOn.Size = New System.Drawing.Size(153, 20)
        Me.txtHostOn.TabIndex = 0
        '
        'rBtnHostGame
        '
        Me.rBtnHostGame.AutoSize = True
        Me.rBtnHostGame.Enabled = False
        Me.rBtnHostGame.Location = New System.Drawing.Point(6, 19)
        Me.rBtnHostGame.Name = "rBtnHostGame"
        Me.rBtnHostGame.Size = New System.Drawing.Size(76, 17)
        Me.rBtnHostGame.TabIndex = 2
        Me.rBtnHostGame.Text = "Host game"
        Me.rBtnHostGame.UseVisualStyleBackColor = True
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOk.Location = New System.Drawing.Point(431, 147)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnConsole
        '
        Me.btnConsole.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnConsole.Location = New System.Drawing.Point(12, 147)
        Me.btnConsole.Name = "btnConsole"
        Me.btnConsole.Size = New System.Drawing.Size(75, 23)
        Me.btnConsole.TabIndex = 3
        Me.btnConsole.Text = "Console"
        Me.btnConsole.UseVisualStyleBackColor = True
        '
        'SelectGameTypeForm
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(518, 182)
        Me.Controls.Add(Me.btnConsole)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.gBoxConnectionSettings)
        Me.Controls.Add(Me.gBoxGameType)
        Me.Name = "SelectGameTypeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select game type"
        Me.gBoxGameType.ResumeLayout(False)
        Me.gBoxGameType.PerformLayout()
        Me.gBoxConnectionSettings.ResumeLayout(False)
        Me.gBoxConnectionSettings.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gBoxGameType As System.Windows.Forms.GroupBox
    Friend WithEvents rBtnOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rBtnLocal As System.Windows.Forms.RadioButton
    Friend WithEvents gBoxConnectionSettings As System.Windows.Forms.GroupBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents txtConnectTo As System.Windows.Forms.TextBox
    Friend WithEvents rBtnConnectoToOpponent As System.Windows.Forms.RadioButton
    Friend WithEvents txtHostOn As System.Windows.Forms.TextBox
    Friend WithEvents rBtnHostGame As System.Windows.Forms.RadioButton
    Friend WithEvents txtConnectOnPort As System.Windows.Forms.TextBox
    Friend WithEvents lblConnectoOnPort As System.Windows.Forms.Label
    Friend WithEvents txtHostOnPort As System.Windows.Forms.TextBox
    Friend WithEvents lblHostOnPort As System.Windows.Forms.Label
    Friend WithEvents btnConsole As System.Windows.Forms.Button

End Class
