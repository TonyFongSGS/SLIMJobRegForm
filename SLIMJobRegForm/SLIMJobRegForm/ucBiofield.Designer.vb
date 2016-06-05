<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucBiofield
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
        Me.txtFieldValue = New System.Windows.Forms.TextBox()
        Me.dtpFieldValue = New System.Windows.Forms.DateTimePicker()
        Me.cmbFieldValue = New System.Windows.Forms.ComboBox()
        Me.lblFieldName = New System.Windows.Forms.Label()
        Me.chkRepActive = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtFieldValue
        '
        Me.txtFieldValue.Location = New System.Drawing.Point(113, 3)
        Me.txtFieldValue.Name = "txtFieldValue"
        Me.txtFieldValue.Size = New System.Drawing.Size(200, 20)
        Me.txtFieldValue.TabIndex = 4
        '
        'dtpFieldValue
        '
        Me.dtpFieldValue.Location = New System.Drawing.Point(113, 3)
        Me.dtpFieldValue.Name = "dtpFieldValue"
        Me.dtpFieldValue.Size = New System.Drawing.Size(200, 20)
        Me.dtpFieldValue.TabIndex = 3
        '
        'cmbFieldValue
        '
        Me.cmbFieldValue.FormattingEnabled = True
        Me.cmbFieldValue.Location = New System.Drawing.Point(113, 3)
        Me.cmbFieldValue.Name = "cmbFieldValue"
        Me.cmbFieldValue.Size = New System.Drawing.Size(200, 21)
        Me.cmbFieldValue.TabIndex = 2
        '
        'lblFieldName
        '
        Me.lblFieldName.AutoSize = True
        Me.lblFieldName.Location = New System.Drawing.Point(3, 6)
        Me.lblFieldName.Name = "lblFieldName"
        Me.lblFieldName.Size = New System.Drawing.Size(39, 13)
        Me.lblFieldName.TabIndex = 1
        Me.lblFieldName.Text = "Label1"
        '
        'chkRepActive
        '
        Me.chkRepActive.AutoSize = True
        Me.chkRepActive.Location = New System.Drawing.Point(319, 6)
        Me.chkRepActive.Name = "chkRepActive"
        Me.chkRepActive.Size = New System.Drawing.Size(15, 14)
        Me.chkRepActive.TabIndex = 5
        Me.chkRepActive.UseVisualStyleBackColor = True
        '
        'ucBiofield
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.chkRepActive)
        Me.Controls.Add(Me.lblFieldName)
        Me.Controls.Add(Me.txtFieldValue)
        Me.Controls.Add(Me.cmbFieldValue)
        Me.Controls.Add(Me.dtpFieldValue)
        Me.Name = "ucBiofield"
        Me.Size = New System.Drawing.Size(339, 27)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFieldValue As System.Windows.Forms.TextBox
    Friend WithEvents dtpFieldValue As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbFieldValue As System.Windows.Forms.ComboBox
    Friend WithEvents lblFieldName As System.Windows.Forms.Label
    Friend WithEvents chkRepActive As System.Windows.Forms.CheckBox

End Class
