<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHelp
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
        Me.btnMarathon = New System.Windows.Forms.Button()
        Me.btnEndless = New System.Windows.Forms.Button()
        Me.btnSprint = New System.Windows.Forms.Button()
        Me.btnClassic = New System.Windows.Forms.Button()
        Me.btnSurvival = New System.Windows.Forms.Button()
        Me.btnControls = New System.Windows.Forms.Button()
        Me.lblHelp = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnMarathon
        '
        Me.btnMarathon.BackColor = System.Drawing.Color.DarkViolet
        Me.btnMarathon.Location = New System.Drawing.Point(170, 160)
        Me.btnMarathon.Name = "btnMarathon"
        Me.btnMarathon.Size = New System.Drawing.Size(103, 41)
        Me.btnMarathon.TabIndex = 0
        Me.btnMarathon.Text = "Marathon"
        Me.btnMarathon.UseVisualStyleBackColor = False
        '
        'btnEndless
        '
        Me.btnEndless.BackColor = System.Drawing.Color.Gold
        Me.btnEndless.Location = New System.Drawing.Point(170, 207)
        Me.btnEndless.Name = "btnEndless"
        Me.btnEndless.Size = New System.Drawing.Size(103, 41)
        Me.btnEndless.TabIndex = 1
        Me.btnEndless.Text = "Endless"
        Me.btnEndless.UseVisualStyleBackColor = False
        '
        'btnSprint
        '
        Me.btnSprint.BackColor = System.Drawing.Color.Lime
        Me.btnSprint.Location = New System.Drawing.Point(170, 301)
        Me.btnSprint.Name = "btnSprint"
        Me.btnSprint.Size = New System.Drawing.Size(103, 41)
        Me.btnSprint.TabIndex = 3
        Me.btnSprint.Text = "Sprint"
        Me.btnSprint.UseVisualStyleBackColor = False
        '
        'btnClassic
        '
        Me.btnClassic.BackColor = System.Drawing.Color.Red
        Me.btnClassic.Location = New System.Drawing.Point(170, 254)
        Me.btnClassic.Name = "btnClassic"
        Me.btnClassic.Size = New System.Drawing.Size(103, 41)
        Me.btnClassic.TabIndex = 2
        Me.btnClassic.Text = "Classic"
        Me.btnClassic.UseVisualStyleBackColor = False
        '
        'btnSurvival
        '
        Me.btnSurvival.BackColor = System.Drawing.Color.Blue
        Me.btnSurvival.Location = New System.Drawing.Point(170, 348)
        Me.btnSurvival.Name = "btnSurvival"
        Me.btnSurvival.Size = New System.Drawing.Size(103, 41)
        Me.btnSurvival.TabIndex = 4
        Me.btnSurvival.Text = "Survival"
        Me.btnSurvival.UseVisualStyleBackColor = False
        '
        'btnControls
        '
        Me.btnControls.BackColor = System.Drawing.Color.Aqua
        Me.btnControls.Location = New System.Drawing.Point(170, 113)
        Me.btnControls.Name = "btnControls"
        Me.btnControls.Size = New System.Drawing.Size(103, 41)
        Me.btnControls.TabIndex = 5
        Me.btnControls.Text = "Controls"
        Me.btnControls.UseVisualStyleBackColor = False
        '
        'lblHelp
        '
        Me.lblHelp.AutoSize = True
        Me.lblHelp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblHelp.Font = New System.Drawing.Font("Palatino Linotype", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelp.Location = New System.Drawing.Point(74, 41)
        Me.lblHelp.Name = "lblHelp"
        Me.lblHelp.Size = New System.Drawing.Size(299, 52)
        Me.lblHelp.TabIndex = 6
        Me.lblHelp.Text = "Select for details."
        '
        'FrmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Tetris_Summative.My.Resources.Resources.earth
        Me.ClientSize = New System.Drawing.Size(442, 450)
        Me.Controls.Add(Me.lblHelp)
        Me.Controls.Add(Me.btnControls)
        Me.Controls.Add(Me.btnSurvival)
        Me.Controls.Add(Me.btnSprint)
        Me.Controls.Add(Me.btnClassic)
        Me.Controls.Add(Me.btnEndless)
        Me.Controls.Add(Me.btnMarathon)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "FrmHelp"
        Me.Text = "FrmHelp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnMarathon As Button
    Friend WithEvents btnEndless As Button
    Friend WithEvents btnSprint As Button
    Friend WithEvents btnClassic As Button
    Friend WithEvents btnSurvival As Button
    Friend WithEvents btnControls As Button
    Friend WithEvents lblHelp As Label
End Class
