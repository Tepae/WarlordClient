Namespace Setup
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
    Partial Class SelectDecksForLocalGameForm
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
            Me.btnSelectDeckForPlayer1 = New System.Windows.Forms.Button()
            Me.txtPlayer1DeckName = New System.Windows.Forms.TextBox()
            Me.lblPlayer1 = New System.Windows.Forms.Label()
            Me.btnSelectDeckForPlayer2 = New System.Windows.Forms.Button()
            Me.txtPlayer2DeckName = New System.Windows.Forms.TextBox()
            Me.lblPlayer2 = New System.Windows.Forms.Label()
            Me.btnOk = New System.Windows.Forms.Button()
            Me.SuspendLayout()
            '
            'btnSelectDeckForPlayer1
            '
            Me.btnSelectDeckForPlayer1.Location = New System.Drawing.Point(106, 11)
            Me.btnSelectDeckForPlayer1.Name = "btnSelectDeckForPlayer1"
            Me.btnSelectDeckForPlayer1.Size = New System.Drawing.Size(75, 25)
            Me.btnSelectDeckForPlayer1.TabIndex = 7
            Me.btnSelectDeckForPlayer1.Text = "Choose"
            Me.btnSelectDeckForPlayer1.UseVisualStyleBackColor = True
            '
            'txtPlayer1DeckName
            '
            Me.txtPlayer1DeckName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtPlayer1DeckName.Location = New System.Drawing.Point(195, 14)
            Me.txtPlayer1DeckName.Margin = New System.Windows.Forms.Padding(2)
            Me.txtPlayer1DeckName.Name = "txtPlayer1DeckName"
            Me.txtPlayer1DeckName.ReadOnly = True
            Me.txtPlayer1DeckName.Size = New System.Drawing.Size(215, 20)
            Me.txtPlayer1DeckName.TabIndex = 9
            '
            'lblPlayer1
            '
            Me.lblPlayer1.AutoSize = True
            Me.lblPlayer1.Location = New System.Drawing.Point(12, 14)
            Me.lblPlayer1.Name = "lblPlayer1"
            Me.lblPlayer1.Size = New System.Drawing.Size(88, 13)
            Me.lblPlayer1.TabIndex = 8
            Me.lblPlayer1.Text = "Deck for player 1"
            '
            'btnSelectDeckForPlayer2
            '
            Me.btnSelectDeckForPlayer2.Location = New System.Drawing.Point(106, 46)
            Me.btnSelectDeckForPlayer2.Name = "btnSelectDeckForPlayer2"
            Me.btnSelectDeckForPlayer2.Size = New System.Drawing.Size(75, 25)
            Me.btnSelectDeckForPlayer2.TabIndex = 10
            Me.btnSelectDeckForPlayer2.Text = "Choose"
            Me.btnSelectDeckForPlayer2.UseVisualStyleBackColor = True
            '
            'txtPlayer2DeckName
            '
            Me.txtPlayer2DeckName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                                                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtPlayer2DeckName.Location = New System.Drawing.Point(195, 49)
            Me.txtPlayer2DeckName.Margin = New System.Windows.Forms.Padding(2)
            Me.txtPlayer2DeckName.Name = "txtPlayer2DeckName"
            Me.txtPlayer2DeckName.ReadOnly = True
            Me.txtPlayer2DeckName.Size = New System.Drawing.Size(215, 20)
            Me.txtPlayer2DeckName.TabIndex = 12
            '
            'lblPlayer2
            '
            Me.lblPlayer2.AutoSize = True
            Me.lblPlayer2.Location = New System.Drawing.Point(12, 49)
            Me.lblPlayer2.Name = "lblPlayer2"
            Me.lblPlayer2.Size = New System.Drawing.Size(88, 13)
            Me.lblPlayer2.TabIndex = 11
            Me.lblPlayer2.Text = "Deck for player 2"
            '
            'btnOk
            '
            Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnOk.Enabled = False
            Me.btnOk.Location = New System.Drawing.Point(335, 77)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(75, 25)
            Me.btnOk.TabIndex = 13
            Me.btnOk.Text = "OK"
            Me.btnOk.UseVisualStyleBackColor = True
            '
            'SelectDecksForLocalGameForm
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(421, 111)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.btnSelectDeckForPlayer2)
            Me.Controls.Add(Me.txtPlayer2DeckName)
            Me.Controls.Add(Me.lblPlayer2)
            Me.Controls.Add(Me.btnSelectDeckForPlayer1)
            Me.Controls.Add(Me.txtPlayer1DeckName)
            Me.Controls.Add(Me.lblPlayer1)
            Me.Name = "SelectDecksForLocalGameForm"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Select decks"
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents btnSelectDeckForPlayer1 As System.Windows.Forms.Button
        Friend WithEvents txtPlayer1DeckName As System.Windows.Forms.TextBox
        Friend WithEvents lblPlayer1 As System.Windows.Forms.Label
        Friend WithEvents btnSelectDeckForPlayer2 As System.Windows.Forms.Button
        Friend WithEvents txtPlayer2DeckName As System.Windows.Forms.TextBox
        Friend WithEvents lblPlayer2 As System.Windows.Forms.Label
        Friend WithEvents btnOk As System.Windows.Forms.Button
    End Class
End Namespace