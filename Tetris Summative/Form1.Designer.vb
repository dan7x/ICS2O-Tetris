<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTetris
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
        Me.components = New System.ComponentModel.Container()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.tmrGame = New System.Windows.Forms.Timer(Me.components)
        Me.lblScore = New System.Windows.Forms.Label()
        Me.tmrCountDwn = New System.Windows.Forms.Timer(Me.components)
        Me.lblCount = New System.Windows.Forms.Label()
        Me.gbxMode = New System.Windows.Forms.GroupBox()
        Me.radEndless = New System.Windows.Forms.RadioButton()
        Me.radSurvival = New System.Windows.Forms.RadioButton()
        Me.radSprint = New System.Windows.Forms.RadioButton()
        Me.radMarathon = New System.Windows.Forms.RadioButton()
        Me.radClassic = New System.Windows.Forms.RadioButton()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnResume = New System.Windows.Forms.Button()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.gbxStats = New System.Windows.Forms.GroupBox()
        Me.lblMode = New System.Windows.Forms.Label()
        Me.lblModeText = New System.Windows.Forms.Label()
        Me.lblLevel = New System.Windows.Forms.Label()
        Me.lblGoal = New System.Windows.Forms.Label()
        Me.lblGoalText = New System.Windows.Forms.Label()
        Me.lblScoreText = New System.Windows.Forms.Label()
        Me.lblLevelText = New System.Windows.Forms.Label()
        Me.tmrOver = New System.Windows.Forms.Timer(Me.components)
        Me.tmrSprint = New System.Windows.Forms.Timer(Me.components)
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HowToPlayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.gbxMode.SuspendLayout()
        Me.gbxStats.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnStart.Location = New System.Drawing.Point(187, 172)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(188, 81)
        Me.btnStart.TabIndex = 0
        Me.btnStart.TabStop = False
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'tmrGame
        '
        Me.tmrGame.Interval = 500
        '
        'lblScore
        '
        Me.lblScore.AutoSize = True
        Me.lblScore.Font = New System.Drawing.Font("OCR A Extended", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScore.Location = New System.Drawing.Point(38, 46)
        Me.lblScore.Name = "lblScore"
        Me.lblScore.Size = New System.Drawing.Size(0, 25)
        Me.lblScore.TabIndex = 2
        '
        'tmrCountDwn
        '
        Me.tmrCountDwn.Interval = 1000
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.BackColor = System.Drawing.Color.LightGray
        Me.lblCount.Font = New System.Drawing.Font("Ravie", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCount.ForeColor = System.Drawing.Color.Black
        Me.lblCount.Location = New System.Drawing.Point(73, 140)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(0, 63)
        Me.lblCount.TabIndex = 3
        '
        'gbxMode
        '
        Me.gbxMode.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.gbxMode.Controls.Add(Me.radEndless)
        Me.gbxMode.Controls.Add(Me.radSurvival)
        Me.gbxMode.Controls.Add(Me.radSprint)
        Me.gbxMode.Controls.Add(Me.radMarathon)
        Me.gbxMode.Controls.Add(Me.radClassic)
        Me.gbxMode.Location = New System.Drawing.Point(304, 273)
        Me.gbxMode.Name = "gbxMode"
        Me.gbxMode.Size = New System.Drawing.Size(188, 142)
        Me.gbxMode.TabIndex = 6
        Me.gbxMode.TabStop = False
        Me.gbxMode.Text = "Gamemode"
        '
        'radEndless
        '
        Me.radEndless.AutoSize = True
        Me.radEndless.Location = New System.Drawing.Point(6, 42)
        Me.radEndless.Name = "radEndless"
        Me.radEndless.Size = New System.Drawing.Size(62, 17)
        Me.radEndless.TabIndex = 9
        Me.radEndless.Text = "Endless"
        Me.radEndless.UseVisualStyleBackColor = True
        '
        'radSurvival
        '
        Me.radSurvival.AutoSize = True
        Me.radSurvival.Location = New System.Drawing.Point(6, 111)
        Me.radSurvival.Name = "radSurvival"
        Me.radSurvival.Size = New System.Drawing.Size(63, 17)
        Me.radSurvival.TabIndex = 3
        Me.radSurvival.Text = "Survival"
        Me.radSurvival.UseVisualStyleBackColor = True
        '
        'radSprint
        '
        Me.radSprint.AutoSize = True
        Me.radSprint.Location = New System.Drawing.Point(6, 88)
        Me.radSprint.Name = "radSprint"
        Me.radSprint.Size = New System.Drawing.Size(52, 17)
        Me.radSprint.TabIndex = 2
        Me.radSprint.Text = "Sprint"
        Me.radSprint.UseVisualStyleBackColor = True
        '
        'radMarathon
        '
        Me.radMarathon.AutoSize = True
        Me.radMarathon.Checked = True
        Me.radMarathon.Location = New System.Drawing.Point(6, 19)
        Me.radMarathon.Name = "radMarathon"
        Me.radMarathon.Size = New System.Drawing.Size(70, 17)
        Me.radMarathon.TabIndex = 1
        Me.radMarathon.TabStop = True
        Me.radMarathon.Text = "Marathon"
        Me.radMarathon.UseVisualStyleBackColor = True
        '
        'radClassic
        '
        Me.radClassic.AutoSize = True
        Me.radClassic.Location = New System.Drawing.Point(6, 65)
        Me.radClassic.Name = "radClassic"
        Me.radClassic.Size = New System.Drawing.Size(58, 17)
        Me.radClassic.TabIndex = 0
        Me.radClassic.Text = "Classic"
        Me.radClassic.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(144, 273)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 10
        Me.btnExit.Text = "Exit Tetris"
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.Visible = False
        '
        'btnResume
        '
        Me.btnResume.Location = New System.Drawing.Point(0, 273)
        Me.btnResume.Name = "btnResume"
        Me.btnResume.Size = New System.Drawing.Size(75, 23)
        Me.btnResume.TabIndex = 10
        Me.btnResume.Text = "Resume"
        Me.btnResume.UseVisualStyleBackColor = True
        Me.btnResume.Visible = False
        '
        'btnQuit
        '
        Me.btnQuit.Location = New System.Drawing.Point(72, 273)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(75, 23)
        Me.btnQuit.TabIndex = 9
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        Me.btnQuit.Visible = False
        '
        'gbxStats
        '
        Me.gbxStats.Controls.Add(Me.btnExit)
        Me.gbxStats.Controls.Add(Me.lblMode)
        Me.gbxStats.Controls.Add(Me.btnQuit)
        Me.gbxStats.Controls.Add(Me.lblModeText)
        Me.gbxStats.Controls.Add(Me.btnResume)
        Me.gbxStats.Controls.Add(Me.lblLevel)
        Me.gbxStats.Controls.Add(Me.lblGoal)
        Me.gbxStats.Controls.Add(Me.lblGoalText)
        Me.gbxStats.Controls.Add(Me.lblScoreText)
        Me.gbxStats.Controls.Add(Me.lblLevelText)
        Me.gbxStats.Controls.Add(Me.lblScore)
        Me.gbxStats.Location = New System.Drawing.Point(453, 122)
        Me.gbxStats.Name = "gbxStats"
        Me.gbxStats.Size = New System.Drawing.Size(219, 302)
        Me.gbxStats.TabIndex = 8
        Me.gbxStats.TabStop = False
        Me.gbxStats.Visible = False
        '
        'lblMode
        '
        Me.lblMode.AutoSize = True
        Me.lblMode.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMode.Location = New System.Drawing.Point(39, 212)
        Me.lblMode.Name = "lblMode"
        Me.lblMode.Size = New System.Drawing.Size(0, 12)
        Me.lblMode.TabIndex = 8
        '
        'lblModeText
        '
        Me.lblModeText.AutoSize = True
        Me.lblModeText.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModeText.Location = New System.Drawing.Point(24, 187)
        Me.lblModeText.Name = "lblModeText"
        Me.lblModeText.Size = New System.Drawing.Size(75, 12)
        Me.lblModeText.TabIndex = 7
        Me.lblModeText.Text = "Game Mode:"
        '
        'lblLevel
        '
        Me.lblLevel.AutoSize = True
        Me.lblLevel.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevel.Location = New System.Drawing.Point(39, 111)
        Me.lblLevel.Name = "lblLevel"
        Me.lblLevel.Size = New System.Drawing.Size(0, 12)
        Me.lblLevel.TabIndex = 6
        '
        'lblGoal
        '
        Me.lblGoal.AutoSize = True
        Me.lblGoal.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoal.Location = New System.Drawing.Point(39, 161)
        Me.lblGoal.Name = "lblGoal"
        Me.lblGoal.Size = New System.Drawing.Size(0, 12)
        Me.lblGoal.TabIndex = 5
        '
        'lblGoalText
        '
        Me.lblGoalText.AutoSize = True
        Me.lblGoalText.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGoalText.Location = New System.Drawing.Point(24, 136)
        Me.lblGoalText.Name = "lblGoalText"
        Me.lblGoalText.Size = New System.Drawing.Size(40, 12)
        Me.lblGoalText.TabIndex = 4
        Me.lblGoalText.Text = "Goal:"
        '
        'lblScoreText
        '
        Me.lblScoreText.AutoSize = True
        Me.lblScoreText.Font = New System.Drawing.Font("OCR A Extended", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblScoreText.Location = New System.Drawing.Point(21, 16)
        Me.lblScoreText.Name = "lblScoreText"
        Me.lblScoreText.Size = New System.Drawing.Size(102, 25)
        Me.lblScoreText.TabIndex = 3
        Me.lblScoreText.Text = "Score:"
        '
        'lblLevelText
        '
        Me.lblLevelText.AutoSize = True
        Me.lblLevelText.Font = New System.Drawing.Font("OCR A Extended", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLevelText.Location = New System.Drawing.Point(24, 84)
        Me.lblLevelText.Name = "lblLevelText"
        Me.lblLevelText.Size = New System.Drawing.Size(47, 12)
        Me.lblLevelText.TabIndex = 0
        Me.lblLevelText.Text = "Level:"
        '
        'tmrOver
        '
        Me.tmrOver.Interval = 1000
        '
        'tmrSprint
        '
        Me.tmrSprint.Interval = 2
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnHelp.Location = New System.Drawing.Point(398, 172)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(188, 81)
        Me.btnHelp.TabIndex = 9
        Me.btnHelp.TabStop = False
        Me.btnHelp.Text = "How To Play"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTitle.Font = New System.Drawing.Font("Castellar", 48.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.DarkTurquoise
        Me.lblTitle.Location = New System.Drawing.Point(248, 59)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(276, 83)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "TETRIS"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(743, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RetryToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'RetryToolStripMenuItem
        '
        Me.RetryToolStripMenuItem.Name = "RetryToolStripMenuItem"
        Me.RetryToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.RetryToolStripMenuItem.Text = "Restart"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(110, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HowToPlayToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'HowToPlayToolStripMenuItem
        '
        Me.HowToPlayToolStripMenuItem.Name = "HowToPlayToolStripMenuItem"
        Me.HowToPlayToolStripMenuItem.Size = New System.Drawing.Size(138, 22)
        Me.HowToPlayToolStripMenuItem.Text = "How to Play"
        '
        'frmTetris
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Tetris_Summative.My.Resources.Resources.origina
        Me.ClientSize = New System.Drawing.Size(743, 490)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.gbxStats)
        Me.Controls.Add(Me.gbxMode)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(763, 533)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(763, 533)
        Me.Name = "frmTetris"
        Me.Text = "TETRIS (ISC2O)"
        Me.gbxMode.ResumeLayout(False)
        Me.gbxMode.PerformLayout()
        Me.gbxStats.ResumeLayout(False)
        Me.gbxStats.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnStart As Button
    Friend WithEvents tmrGame As Timer
    Friend WithEvents lblScore As Label
    Friend WithEvents tmrCountDwn As Timer
    Friend WithEvents lblCount As Label
    Friend WithEvents gbxMode As GroupBox
    Friend WithEvents radEndless As RadioButton
    Friend WithEvents radSurvival As RadioButton
    Friend WithEvents radSprint As RadioButton
    Friend WithEvents radMarathon As RadioButton
    Friend WithEvents radClassic As RadioButton
    Friend WithEvents gbxStats As GroupBox
    Friend WithEvents lblLevel As Label
    Friend WithEvents lblGoal As Label
    Friend WithEvents lblGoalText As Label
    Friend WithEvents lblScoreText As Label
    Friend WithEvents lblLevelText As Label
    Friend WithEvents tmrOver As Timer
    Friend WithEvents tmrSprint As Timer
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnResume As Button
    Friend WithEvents btnExit As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents lblMode As Label
    Friend WithEvents lblModeText As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RetryToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HowToPlayToolStripMenuItem As ToolStripMenuItem
End Class
