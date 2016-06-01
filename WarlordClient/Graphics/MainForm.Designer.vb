Namespace Graphics
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class MainForm
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
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
            Me.mainPanel = New System.Windows.Forms.Panel()
            Me.splitContainer = New System.Windows.Forms.SplitContainer()
            Me.cgTop = New WarlordClient.CardGrid()
            Me.cgBottom = New WarlordClient.CardGrid()
            Me.btnOK = New System.Windows.Forms.Button()
            Me.btnCancel = New System.Windows.Forms.Button()
            Me.txtBoxPrompt = New System.Windows.Forms.TextBox()
            Me.rtxtLog = New System.Windows.Forms.RichTextBox()
            Me.txtSendMessage = New System.Windows.Forms.TextBox()
            Me.btnDone = New System.Windows.Forms.Button()
            Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
            Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.DebugToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.ConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
            Me.displayCard = New WarlordClient.DisplayCard()
            Me.txtBoxFeedback = New System.Windows.Forms.TextBox()
            Me.mainPanel.SuspendLayout()
            CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.splitContainer.Panel1.SuspendLayout()
            Me.splitContainer.Panel2.SuspendLayout()
            Me.splitContainer.SuspendLayout()
            Me.MenuStrip1.SuspendLayout()
            Me.SuspendLayout()
            '
            'mainPanel
            '
            Me.mainPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                          Or System.Windows.Forms.AnchorStyles.Left) _
                                         Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.mainPanel.Controls.Add(Me.splitContainer)
            Me.mainPanel.Location = New System.Drawing.Point(231, 2)
            Me.mainPanel.Name = "mainPanel"
            Me.mainPanel.Size = New System.Drawing.Size(1354, 865)
            Me.mainPanel.TabIndex = 0
            '
            'splitContainer
            '
            Me.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me.splitContainer.Location = New System.Drawing.Point(0, 0)
            Me.splitContainer.Name = "splitContainer"
            Me.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'splitContainer.Panel1
            '
            Me.splitContainer.Panel1.AutoScroll = True
            Me.splitContainer.Panel1.Controls.Add(Me.cgTop)
            '
            'splitContainer.Panel2
            '
            Me.splitContainer.Panel2.AutoScroll = True
            Me.splitContainer.Panel2.Controls.Add(Me.cgBottom)
            Me.splitContainer.Size = New System.Drawing.Size(1354, 865)
            Me.splitContainer.SplitterDistance = 437
            Me.splitContainer.TabIndex = 0
            '
            'cgTop
            '
            Me.cgTop.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                      Or System.Windows.Forms.AnchorStyles.Left) _
                                     Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cgTop.AutoScroll = True
            Me.cgTop.BackColor = System.Drawing.Color.LightYellow
            Me.cgTop.DisplayStyle = WarlordClient.CardGrid.Display.HighestTopmost
            Me.cgTop.Location = New System.Drawing.Point(0, -562)
            Me.cgTop.Name = "cgTop"
            Me.cgTop.Owner = New System.Guid("00000000-0000-0000-0000-000000000000")
            Me.cgTop.Size = New System.Drawing.Size(1520, 1000)
            Me.cgTop.TabIndex = 0
            '
            'cgBottom
            '
            Me.cgBottom.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                         Or System.Windows.Forms.AnchorStyles.Left) _
                                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cgBottom.AutoScroll = True
            Me.cgBottom.BackColor = System.Drawing.Color.PaleGreen
            Me.cgBottom.DisplayStyle = WarlordClient.CardGrid.Display.LowestTopmost
            Me.cgBottom.Location = New System.Drawing.Point(0, 3)
            Me.cgBottom.Name = "cgBottom"
            Me.cgBottom.Owner = New System.Guid("00000000-0000-0000-0000-000000000000")
            Me.cgBottom.Size = New System.Drawing.Size(1520, 1000)
            Me.cgBottom.TabIndex = 1
            '
            'btnOK
            '
            Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnOK.Location = New System.Drawing.Point(12, 442)
            Me.btnOK.Name = "btnOK"
            Me.btnOK.Size = New System.Drawing.Size(60, 23)
            Me.btnOK.TabIndex = 2
            Me.btnOK.Text = "OK"
            Me.btnOK.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnCancel.Location = New System.Drawing.Point(78, 442)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(60, 23)
            Me.btnCancel.TabIndex = 3
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'txtBoxPrompt
            '
            Me.txtBoxPrompt.Location = New System.Drawing.Point(12, 303)
            Me.txtBoxPrompt.Multiline = True
            Me.txtBoxPrompt.Name = "txtBoxPrompt"
            Me.txtBoxPrompt.ReadOnly = True
            Me.txtBoxPrompt.Size = New System.Drawing.Size(213, 63)
            Me.txtBoxPrompt.TabIndex = 2
            '
            'rtxtLog
            '
            Me.rtxtLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.rtxtLog.Location = New System.Drawing.Point(12, 471)
            Me.rtxtLog.Name = "rtxtLog"
            Me.rtxtLog.Size = New System.Drawing.Size(213, 370)
            Me.rtxtLog.TabIndex = 1
            Me.rtxtLog.Text = ""
            '
            'txtSendMessage
            '
            Me.txtSendMessage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.txtSendMessage.Location = New System.Drawing.Point(12, 847)
            Me.txtSendMessage.Name = "txtSendMessage"
            Me.txtSendMessage.Size = New System.Drawing.Size(213, 20)
            Me.txtSendMessage.TabIndex = 2
            '
            'btnDone
            '
            Me.btnDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.btnDone.Location = New System.Drawing.Point(143, 442)
            Me.btnDone.Name = "btnDone"
            Me.btnDone.Size = New System.Drawing.Size(60, 23)
            Me.btnDone.TabIndex = 4
            Me.btnDone.Text = "Done"
            Me.btnDone.UseVisualStyleBackColor = True
            '
            'MenuStrip1
            '
            Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.DebugToolStripMenuItem})
            Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.Size = New System.Drawing.Size(1584, 24)
            Me.MenuStrip1.TabIndex = 5
            Me.MenuStrip1.Text = "MenuStrip1"
            '
            'FileToolStripMenuItem
            '
            Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
            Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
            Me.FileToolStripMenuItem.Text = "File"
            '
            'DebugToolStripMenuItem
            '
            Me.DebugToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ConsoleToolStripMenuItem})
            Me.DebugToolStripMenuItem.Name = "DebugToolStripMenuItem"
            Me.DebugToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
            Me.DebugToolStripMenuItem.Text = "Debug"
            '
            'ConsoleToolStripMenuItem
            '
            Me.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem"
            Me.ConsoleToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
            Me.ConsoleToolStripMenuItem.Text = "Console"
            '
            'displayCard
            '
            Me.displayCard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.displayCard.Location = New System.Drawing.Point(12, 28)
            Me.displayCard.Name = "displayCard"
            Me.displayCard.Size = New System.Drawing.Size(191, 269)
            Me.displayCard.TabIndex = 1
            '
            'txtBoxFeedback
            '
            Me.txtBoxFeedback.Location = New System.Drawing.Point(12, 372)
            Me.txtBoxFeedback.Multiline = True
            Me.txtBoxFeedback.Name = "txtBoxFeedback"
            Me.txtBoxFeedback.ReadOnly = True
            Me.txtBoxFeedback.Size = New System.Drawing.Size(213, 63)
            Me.txtBoxFeedback.TabIndex = 6
            '
            'MainForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(1584, 867)
            Me.Controls.Add(Me.txtBoxFeedback)
            Me.Controls.Add(Me.MenuStrip1)
            Me.Controls.Add(Me.btnDone)
            Me.Controls.Add(Me.txtSendMessage)
            Me.Controls.Add(Me.rtxtLog)
            Me.Controls.Add(Me.txtBoxPrompt)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnOK)
            Me.Controls.Add(Me.displayCard)
            Me.Controls.Add(Me.mainPanel)
            Me.MainMenuStrip = Me.MenuStrip1
            Me.Name = "MainForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Warlord BETA"
            Me.mainPanel.ResumeLayout(False)
            Me.splitContainer.Panel1.ResumeLayout(False)
            Me.splitContainer.Panel2.ResumeLayout(False)
            CType(Me.splitContainer, System.ComponentModel.ISupportInitialize).EndInit()
            Me.splitContainer.ResumeLayout(False)
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout()
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents mainPanel As System.Windows.Forms.Panel
        Friend WithEvents splitContainer As System.Windows.Forms.SplitContainer
        Friend WithEvents cgTop As WarlordClient.CardGrid
        Friend WithEvents cgBottom As WarlordClient.CardGrid
        Friend WithEvents displayCard As DisplayCard
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents txtBoxPrompt As System.Windows.Forms.TextBox
        Friend WithEvents rtxtLog As System.Windows.Forms.RichTextBox
        Friend WithEvents txtSendMessage As System.Windows.Forms.TextBox
        Friend WithEvents btnDone As System.Windows.Forms.Button
        Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
        Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents DebugToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents ConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents txtBoxFeedback As System.Windows.Forms.TextBox
    End Class
End Namespace