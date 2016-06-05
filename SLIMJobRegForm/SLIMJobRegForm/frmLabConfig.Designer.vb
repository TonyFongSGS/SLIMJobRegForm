<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLabConfig
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
        Me.lsbLabcodes = New System.Windows.Forms.ListBox()
        Me.lsvSettings = New System.Windows.Forms.ListView()
        Me.Key = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Value = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lsbLabcodes
        '
        Me.lsbLabcodes.FormattingEnabled = True
        Me.lsbLabcodes.Location = New System.Drawing.Point(12, 12)
        Me.lsbLabcodes.Name = "lsbLabcodes"
        Me.lsbLabcodes.Size = New System.Drawing.Size(106, 277)
        Me.lsbLabcodes.TabIndex = 0
        '
        'lsvSettings
        '
        Me.lsvSettings.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Key, Me.Value})
        Me.lsvSettings.Location = New System.Drawing.Point(124, 12)
        Me.lsvSettings.Name = "lsvSettings"
        Me.lsvSettings.Size = New System.Drawing.Size(360, 277)
        Me.lsvSettings.TabIndex = 1
        Me.lsvSettings.UseCompatibleStateImageBehavior = False
        Me.lsvSettings.View = System.Windows.Forms.View.Details
        '
        'Key
        '
        Me.Key.Text = "Key"
        Me.Key.Width = 137
        '
        'Value
        '
        Me.Value.Text = "Value"
        Me.Value.Width = 221
        '
        'frmLabConfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 302)
        Me.Controls.Add(Me.lsvSettings)
        Me.Controls.Add(Me.lsbLabcodes)
        Me.Name = "frmLabConfig"
        Me.Text = "Lab Configure"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lsbLabcodes As System.Windows.Forms.ListBox
    Friend WithEvents lsvSettings As System.Windows.Forms.ListView
    Friend WithEvents Key As System.Windows.Forms.ColumnHeader
    Friend WithEvents Value As System.Windows.Forms.ColumnHeader
End Class
