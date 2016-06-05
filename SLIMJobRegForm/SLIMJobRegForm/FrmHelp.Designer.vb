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
        Me.lnkUserDoc = New System.Windows.Forms.LinkLabel()
        Me.lnkSharepoint = New System.Windows.Forms.LinkLabel()
        Me.lnkChangeLog = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'lnkUserDoc
        '
        Me.lnkUserDoc.AutoSize = True
        Me.lnkUserDoc.ImageKey = "(none)"
        Me.lnkUserDoc.LinkVisited = True
        Me.lnkUserDoc.Location = New System.Drawing.Point(39, 47)
        Me.lnkUserDoc.Name = "lnkUserDoc"
        Me.lnkUserDoc.Size = New System.Drawing.Size(52, 13)
        Me.lnkUserDoc.TabIndex = 1
        Me.lnkUserDoc.TabStop = True
        Me.lnkUserDoc.Tag = ""
        Me.lnkUserDoc.Text = "User Doc"
        '
        'lnkSharepoint
        '
        Me.lnkSharepoint.AutoSize = True
        Me.lnkSharepoint.ImageKey = "(none)"
        Me.lnkSharepoint.LinkVisited = True
        Me.lnkSharepoint.Location = New System.Drawing.Point(27, 24)
        Me.lnkSharepoint.Name = "lnkSharepoint"
        Me.lnkSharepoint.Size = New System.Drawing.Size(179, 13)
        Me.lnkSharepoint.TabIndex = 1
        Me.lnkSharepoint.TabStop = True
        Me.lnkSharepoint.Tag = ""
        Me.lnkSharepoint.Text = "CTS SLIM Job Reg Form Sharepoint"
        '
        'lnkChangeLog
        '
        Me.lnkChangeLog.AutoSize = True
        Me.lnkChangeLog.ImageKey = "(none)"
        Me.lnkChangeLog.LinkVisited = True
        Me.lnkChangeLog.Location = New System.Drawing.Point(39, 60)
        Me.lnkChangeLog.Name = "lnkChangeLog"
        Me.lnkChangeLog.Size = New System.Drawing.Size(65, 13)
        Me.lnkChangeLog.TabIndex = 1
        Me.lnkChangeLog.TabStop = True
        Me.lnkChangeLog.Tag = ""
        Me.lnkChangeLog.Text = "Change Log"
        '
        'FrmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 96)
        Me.Controls.Add(Me.lnkChangeLog)
        Me.Controls.Add(Me.lnkSharepoint)
        Me.Controls.Add(Me.lnkUserDoc)
        Me.Name = "FrmHelp"
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lnkUserDoc As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSharepoint As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkChangeLog As System.Windows.Forms.LinkLabel
End Class
