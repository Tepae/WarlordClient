<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupGameForm
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
        Me.btnLoadDeckExternal = New System.Windows.Forms.Button()
        Me.lBoxDeck = New System.Windows.Forms.ListBox()
        Me.openDeck = New System.Windows.Forms.OpenFileDialog()
        Me.cbWarlord = New System.Windows.Forms.ComboBox()
        Me.gBoxChooseWarlord = New System.Windows.Forms.GroupBox()
        Me.btnLoadDeckInternal = New System.Windows.Forms.Button()
        Me.fullCard = New WarlordClient.FullCard()
        Me.grid = New WarlordClient.CardGrid()
        Me.btnSubmit = New System.Windows.Forms.Button()
        Me.gbPlayerName = New System.Windows.Forms.GroupBox()
        Me.txtPlayerName = New System.Windows.Forms.TextBox()
        Me.gBoxChooseWarlord.SuspendLayout()
        Me.gbPlayerName.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLoadDeckExternal
        '
        Me.btnLoadDeckExternal.Location = New System.Drawing.Point(11, 11)
        Me.btnLoadDeckExternal.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLoadDeckExternal.Name = "btnLoadDeckExternal"
        Me.btnLoadDeckExternal.Size = New System.Drawing.Size(75, 50)
        Me.btnLoadDeckExternal.TabIndex = 22
        Me.btnLoadDeckExternal.Text = "Load deck (external)"
        Me.btnLoadDeckExternal.UseVisualStyleBackColor = True
        '
        'lBoxDeck
        '
        Me.lBoxDeck.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lBoxDeck.FormattingEnabled = True
        Me.lBoxDeck.Location = New System.Drawing.Point(11, 66)
        Me.lBoxDeck.Name = "deck"
        Me.lBoxDeck.Size = New System.Drawing.Size(162, 433)
        Me.lBoxDeck.TabIndex = 23
        '
        'openDeck
        '
        Me.openDeck.Filter = "Warlord decks|*.wdk"
        '
        'cbWarlord
        '
        Me.cbWarlord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbWarlord.FormattingEnabled = True
        Me.cbWarlord.Location = New System.Drawing.Point(6, 16)
        Me.cbWarlord.Name = "cbWarlord"
        Me.cbWarlord.Size = New System.Drawing.Size(109, 21)
        Me.cbWarlord.TabIndex = 24
        '
        'gBoxChooseWarlord
        '
        Me.gBoxChooseWarlord.Controls.Add(Me.cbWarlord)
        Me.gBoxChooseWarlord.Location = New System.Drawing.Point(179, 18)
        Me.gBoxChooseWarlord.Name = "gBoxChooseWarlord"
        Me.gBoxChooseWarlord.Size = New System.Drawing.Size(121, 43)
        Me.gBoxChooseWarlord.TabIndex = 26
        Me.gBoxChooseWarlord.TabStop = False
        Me.gBoxChooseWarlord.Text = "Choose a Warlord"
        '
        'btnLoadDeckInternal
        '
        Me.btnLoadDeckInternal.Location = New System.Drawing.Point(98, 11)
        Me.btnLoadDeckInternal.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLoadDeckInternal.Name = "btnLoadDeckInternal"
        Me.btnLoadDeckInternal.Size = New System.Drawing.Size(75, 50)
        Me.btnLoadDeckInternal.TabIndex = 28
        Me.btnLoadDeckInternal.Text = "Load deck (internal)"
        Me.btnLoadDeckInternal.UseVisualStyleBackColor = True
        '
        'fullCard
        '
        Me.fullCard.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.fullCard.Location = New System.Drawing.Point(854, 11)
        Me.fullCard.Name = "fullCard"
        Me.fullCard.Size = New System.Drawing.Size(390, 546)
        Me.fullCard.TabIndex = 27
        '
        'grid
        '
        Me.grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grid.BackColor = System.Drawing.Color.LightYellow
        Me.grid.DisplayStyle = WarlordClient.CardGrid.Display.LowestTopmost
        Me.grid.Location = New System.Drawing.Point(306, 11)
        Me.grid.Name = "grid"
        Me.grid.Size = New System.Drawing.Size(525, 546)
        Me.grid.TabIndex = 25
        '
        'btnSubmit
        '
        Me.btnSubmit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSubmit.Enabled = False
        Me.btnSubmit.Location = New System.Drawing.Point(11, 507)
        Me.btnSubmit.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSubmit.Name = "btnSubmit"
        Me.btnSubmit.Size = New System.Drawing.Size(75, 50)
        Me.btnSubmit.TabIndex = 29
        Me.btnSubmit.Text = "Submit deck"
        Me.btnSubmit.UseVisualStyleBackColor = True
        '
        'gbPlayerName
        '
        Me.gbPlayerName.Controls.Add(Me.txtPlayerName)
        Me.gbPlayerName.Location = New System.Drawing.Point(179, 67)
        Me.gbPlayerName.Name = "gbPlayerName"
        Me.gbPlayerName.Size = New System.Drawing.Size(121, 43)
        Me.gbPlayerName.TabIndex = 27
        Me.gbPlayerName.TabStop = False
        Me.gbPlayerName.Text = "Player name"
        '
        'txtPlayerName
        '
        Me.txtPlayerName.Location = New System.Drawing.Point(6, 17)
        Me.txtPlayerName.Name = "txtPlayerName"
        Me.txtPlayerName.Size = New System.Drawing.Size(109, 20)
        Me.txtPlayerName.TabIndex = 30
        '
        'SetupGameForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1256, 574)
        Me.Controls.Add(Me.gbPlayerName)
        Me.Controls.Add(Me.btnSubmit)
        Me.Controls.Add(Me.btnLoadDeckInternal)
        Me.Controls.Add(Me.fullCard)
        Me.Controls.Add(Me.gBoxChooseWarlord)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.lBoxDeck)
        Me.Controls.Add(Me.btnLoadDeckExternal)
        Me.Name = "SetupGameForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Choose deck and starting characters"
        Me.gBoxChooseWarlord.ResumeLayout(False)
        Me.gbPlayerName.ResumeLayout(False)
        Me.gbPlayerName.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoadDeckExternal As System.Windows.Forms.Button
    Friend WithEvents lBoxDeck As System.Windows.Forms.ListBox
    Friend WithEvents openDeck As System.Windows.Forms.OpenFileDialog
    Friend WithEvents cbWarlord As System.Windows.Forms.ComboBox
    Friend WithEvents grid As CardGrid
    Friend WithEvents gBoxChooseWarlord As System.Windows.Forms.GroupBox
    Friend WithEvents fullCard As FullCard
    Friend WithEvents btnLoadDeckInternal As System.Windows.Forms.Button
    Friend WithEvents btnSubmit As System.Windows.Forms.Button
    Friend WithEvents gbPlayerName As System.Windows.Forms.GroupBox
    Friend WithEvents txtPlayerName As System.Windows.Forms.TextBox
End Class
