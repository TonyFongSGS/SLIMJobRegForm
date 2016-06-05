<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmJob
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
        Me.sbBiofield = New System.Windows.Forms.VScrollBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSearchClient = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbProject = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbClientContact = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txbOrder = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txbClientOrder = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbProductCode = New System.Windows.Forms.ComboBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.btnAddBF = New System.Windows.Forms.Button()
        Me.btnDelBF = New System.Windows.Forms.Button()
        Me.cmbClient = New System.Windows.Forms.ComboBox()
        Me.lblClientName = New System.Windows.Forms.Label()
        Me.grpJobBiofield = New System.Windows.Forms.GroupBox()
        Me.ubfCode1 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode3 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode5 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode7 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode9 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode11 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode13 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode15 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode17 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode19 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode2 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode4 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode6 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode8 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode10 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode20 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode12 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode18 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode14 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode16 = New SLIMJobRegForm.ucBiofield()
        Me.lblClientContactName = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txbReportTemplate = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbCostCode = New System.Windows.Forms.ComboBox()
        Me.dtpRequired = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpJobBiofield.SuspendLayout()
        Me.SuspendLayout()
        '
        'sbBiofield
        '
        Me.sbBiofield.LargeChange = 1
        Me.sbBiofield.Location = New System.Drawing.Point(703, 48)
        Me.sbBiofield.Maximum = 10
        Me.sbBiofield.Name = "sbBiofield"
        Me.sbBiofield.Size = New System.Drawing.Size(17, 231)
        Me.sbBiofield.TabIndex = 22
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 13)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "Client"
        '
        'btnSearchClient
        '
        Me.btnSearchClient.Location = New System.Drawing.Point(334, 10)
        Me.btnSearchClient.Name = "btnSearchClient"
        Me.btnSearchClient.Size = New System.Drawing.Size(33, 23)
        Me.btnSearchClient.TabIndex = 1
        Me.btnSearchClient.Text = ">>"
        Me.btnSearchClient.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "Project"
        '
        'cmbProject
        '
        Me.cmbProject.FormattingEnabled = True
        Me.cmbProject.Location = New System.Drawing.Point(118, 63)
        Me.cmbProject.Name = "cmbProject"
        Me.cmbProject.Size = New System.Drawing.Size(210, 21)
        Me.cmbProject.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AllowDrop = True
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "Client Contact"
        '
        'cmbClientContact
        '
        Me.cmbClientContact.FormattingEnabled = True
        Me.cmbClientContact.Location = New System.Drawing.Point(118, 39)
        Me.cmbClientContact.Name = "cmbClientContact"
        Me.cmbClientContact.Size = New System.Drawing.Size(210, 21)
        Me.cmbClientContact.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AllowDrop = True
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(373, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Order"
        '
        'txbOrder
        '
        Me.txbOrder.Location = New System.Drawing.Point(478, 69)
        Me.txbOrder.Name = "txbOrder"
        Me.txbOrder.Size = New System.Drawing.Size(210, 20)
        Me.txbOrder.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AllowDrop = True
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(373, 93)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 13)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Client Order"
        '
        'txbClientOrder
        '
        Me.txbClientOrder.Location = New System.Drawing.Point(478, 93)
        Me.txbClientOrder.Name = "txbClientOrder"
        Me.txbClientOrder.Size = New System.Drawing.Size(210, 20)
        Me.txbClientOrder.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AllowDrop = True
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 93)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Product Code"
        '
        'cmbProductCode
        '
        Me.cmbProductCode.FormattingEnabled = True
        Me.cmbProductCode.Location = New System.Drawing.Point(118, 90)
        Me.cmbProductCode.Name = "cmbProductCode"
        Me.cmbProductCode.Size = New System.Drawing.Size(210, 21)
        Me.cmbProductCode.TabIndex = 5
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(655, 145)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(75, 23)
        Me.btnDone.TabIndex = 10
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'btnAddBF
        '
        Me.btnAddBF.Location = New System.Drawing.Point(10, 19)
        Me.btnAddBF.Name = "btnAddBF"
        Me.btnAddBF.Size = New System.Drawing.Size(75, 23)
        Me.btnAddBF.TabIndex = 0
        Me.btnAddBF.Text = "Add BioField"
        Me.btnAddBF.UseVisualStyleBackColor = True
        '
        'btnDelBF
        '
        Me.btnDelBF.Location = New System.Drawing.Point(91, 19)
        Me.btnDelBF.Name = "btnDelBF"
        Me.btnDelBF.Size = New System.Drawing.Size(75, 23)
        Me.btnDelBF.TabIndex = 1
        Me.btnDelBF.Text = "Del BioField"
        Me.btnDelBF.UseVisualStyleBackColor = True
        '
        'cmbClient
        '
        Me.cmbClient.FormattingEnabled = True
        Me.cmbClient.Location = New System.Drawing.Point(118, 12)
        Me.cmbClient.Name = "cmbClient"
        Me.cmbClient.Size = New System.Drawing.Size(210, 21)
        Me.cmbClient.TabIndex = 0
        '
        'lblClientName
        '
        Me.lblClientName.AutoSize = True
        Me.lblClientName.Location = New System.Drawing.Point(373, 13)
        Me.lblClientName.Name = "lblClientName"
        Me.lblClientName.Size = New System.Drawing.Size(62, 13)
        Me.lblClientName.TabIndex = 38
        Me.lblClientName.Text = "Client name"
        '
        'grpJobBiofield
        '
        Me.grpJobBiofield.Controls.Add(Me.btnDelBF)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode1)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode3)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode5)
        Me.grpJobBiofield.Controls.Add(Me.btnAddBF)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode7)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode9)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode11)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode13)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode15)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode17)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode19)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode2)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode4)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode6)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode8)
        Me.grpJobBiofield.Controls.Add(Me.sbBiofield)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode10)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode20)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode12)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode18)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode14)
        Me.grpJobBiofield.Controls.Add(Me.ubfCode16)
        Me.grpJobBiofield.Location = New System.Drawing.Point(10, 174)
        Me.grpJobBiofield.Name = "grpJobBiofield"
        Me.grpJobBiofield.Size = New System.Drawing.Size(720, 292)
        Me.grpJobBiofield.TabIndex = 11
        Me.grpJobBiofield.TabStop = False
        Me.grpJobBiofield.Text = "Biofield"
        '
        'ubfCode1
        '
        Me.ubfCode1.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode1.Location = New System.Drawing.Point(6, 48)
        Me.ubfCode1.Name = "ubfCode1"
        Me.ubfCode1.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode1.TabIndex = 2
        '
        'ubfCode3
        '
        Me.ubfCode3.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode3.Location = New System.Drawing.Point(6, 72)
        Me.ubfCode3.Name = "ubfCode3"
        Me.ubfCode3.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode3.TabIndex = 4
        '
        'ubfCode5
        '
        Me.ubfCode5.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode5.Location = New System.Drawing.Point(6, 95)
        Me.ubfCode5.Name = "ubfCode5"
        Me.ubfCode5.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode5.TabIndex = 6
        '
        'ubfCode7
        '
        Me.ubfCode7.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode7.Location = New System.Drawing.Point(6, 117)
        Me.ubfCode7.Name = "ubfCode7"
        Me.ubfCode7.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode7.TabIndex = 8
        '
        'ubfCode9
        '
        Me.ubfCode9.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode9.Location = New System.Drawing.Point(6, 140)
        Me.ubfCode9.Name = "ubfCode9"
        Me.ubfCode9.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode9.TabIndex = 10
        '
        'ubfCode11
        '
        Me.ubfCode11.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode11.Location = New System.Drawing.Point(6, 162)
        Me.ubfCode11.Name = "ubfCode11"
        Me.ubfCode11.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode11.TabIndex = 12
        '
        'ubfCode13
        '
        Me.ubfCode13.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode13.Location = New System.Drawing.Point(6, 183)
        Me.ubfCode13.Name = "ubfCode13"
        Me.ubfCode13.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode13.TabIndex = 14
        '
        'ubfCode15
        '
        Me.ubfCode15.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode15.Location = New System.Drawing.Point(6, 205)
        Me.ubfCode15.Name = "ubfCode15"
        Me.ubfCode15.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode15.TabIndex = 16
        '
        'ubfCode17
        '
        Me.ubfCode17.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode17.Location = New System.Drawing.Point(6, 228)
        Me.ubfCode17.Name = "ubfCode17"
        Me.ubfCode17.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode17.TabIndex = 18
        '
        'ubfCode19
        '
        Me.ubfCode19.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode19.Location = New System.Drawing.Point(6, 252)
        Me.ubfCode19.Name = "ubfCode19"
        Me.ubfCode19.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode19.TabIndex = 20
        '
        'ubfCode2
        '
        Me.ubfCode2.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode2.Location = New System.Drawing.Point(363, 48)
        Me.ubfCode2.Name = "ubfCode2"
        Me.ubfCode2.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode2.TabIndex = 3
        '
        'ubfCode4
        '
        Me.ubfCode4.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode4.Location = New System.Drawing.Point(363, 72)
        Me.ubfCode4.Name = "ubfCode4"
        Me.ubfCode4.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode4.TabIndex = 5
        '
        'ubfCode6
        '
        Me.ubfCode6.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode6.Location = New System.Drawing.Point(363, 95)
        Me.ubfCode6.Name = "ubfCode6"
        Me.ubfCode6.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode6.TabIndex = 7
        '
        'ubfCode8
        '
        Me.ubfCode8.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode8.Location = New System.Drawing.Point(363, 117)
        Me.ubfCode8.Name = "ubfCode8"
        Me.ubfCode8.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode8.TabIndex = 9
        '
        'ubfCode10
        '
        Me.ubfCode10.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode10.Location = New System.Drawing.Point(363, 140)
        Me.ubfCode10.Name = "ubfCode10"
        Me.ubfCode10.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode10.TabIndex = 11
        '
        'ubfCode20
        '
        Me.ubfCode20.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode20.Location = New System.Drawing.Point(363, 252)
        Me.ubfCode20.Name = "ubfCode20"
        Me.ubfCode20.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode20.TabIndex = 21
        '
        'ubfCode12
        '
        Me.ubfCode12.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode12.Location = New System.Drawing.Point(363, 162)
        Me.ubfCode12.Name = "ubfCode12"
        Me.ubfCode12.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode12.TabIndex = 13
        '
        'ubfCode18
        '
        Me.ubfCode18.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode18.Location = New System.Drawing.Point(363, 228)
        Me.ubfCode18.Name = "ubfCode18"
        Me.ubfCode18.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode18.TabIndex = 19
        '
        'ubfCode14
        '
        Me.ubfCode14.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode14.Location = New System.Drawing.Point(363, 183)
        Me.ubfCode14.Name = "ubfCode14"
        Me.ubfCode14.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode14.TabIndex = 15
        '
        'ubfCode16
        '
        Me.ubfCode16.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode16.Location = New System.Drawing.Point(363, 205)
        Me.ubfCode16.Name = "ubfCode16"
        Me.ubfCode16.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode16.TabIndex = 17
        '
        'lblClientContactName
        '
        Me.lblClientContactName.AutoSize = True
        Me.lblClientContactName.Location = New System.Drawing.Point(373, 39)
        Me.lblClientContactName.Name = "lblClientContactName"
        Me.lblClientContactName.Size = New System.Drawing.Size(101, 13)
        Me.lblClientContactName.TabIndex = 38
        Me.lblClientContactName.Text = "Client contact name"
        '
        'Label8
        '
        Me.Label8.AllowDrop = True
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(373, 119)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 36
        Me.Label8.Text = "Report Template"
        '
        'txbReportTemplate
        '
        Me.txbReportTemplate.Location = New System.Drawing.Point(478, 119)
        Me.txbReportTemplate.Name = "txbReportTemplate"
        Me.txbReportTemplate.Size = New System.Drawing.Size(210, 20)
        Me.txbReportTemplate.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AllowDrop = True
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 13)
        Me.Label7.TabIndex = 34
        Me.Label7.Text = "Cost Code"
        '
        'cmbCostCode
        '
        Me.cmbCostCode.FormattingEnabled = True
        Me.cmbCostCode.Location = New System.Drawing.Point(118, 119)
        Me.cmbCostCode.Name = "cmbCostCode"
        Me.cmbCostCode.Size = New System.Drawing.Size(210, 21)
        Me.cmbCostCode.TabIndex = 7
        '
        'dtpRequired
        '
        Me.dtpRequired.CustomFormat = "MM/dd/yyyy HH:mm"
        Me.dtpRequired.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRequired.Location = New System.Drawing.Point(118, 147)
        Me.dtpRequired.Name = "dtpRequired"
        Me.dtpRequired.Size = New System.Drawing.Size(210, 20)
        Me.dtpRequired.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AllowDrop = True
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 150)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(76, 13)
        Me.Label9.TabIndex = 34
        Me.Label9.Text = "Required Date"
        '
        'frmJob
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(744, 475)
        Me.Controls.Add(Me.dtpRequired)
        Me.Controls.Add(Me.grpJobBiofield)
        Me.Controls.Add(Me.lblClientContactName)
        Me.Controls.Add(Me.lblClientName)
        Me.Controls.Add(Me.cmbClient)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.cmbClientContact)
        Me.Controls.Add(Me.cmbCostCode)
        Me.Controls.Add(Me.cmbProductCode)
        Me.Controls.Add(Me.cmbProject)
        Me.Controls.Add(Me.btnSearchClient)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txbReportTemplate)
        Me.Controls.Add(Me.txbClientOrder)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txbOrder)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmJob"
        Me.Text = "Job"
        Me.grpJobBiofield.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ubfCode1 As ucBiofield
    Friend WithEvents ubfCode3 As ucBiofield
    Friend WithEvents sbBiofield As System.Windows.Forms.VScrollBar
    Friend WithEvents ubfCode2 As ucBiofield
    Friend WithEvents ubfCode4 As ucBiofield
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearchClient As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbProject As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbClientContact As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txbOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txbClientOrder As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbProductCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents btnAddBF As System.Windows.Forms.Button
    Friend WithEvents btnDelBF As System.Windows.Forms.Button
    Friend WithEvents ubfCode6 As ucBiofield
    Friend WithEvents ubfCode5 As ucBiofield
    Friend WithEvents ubfCode8 As ucBiofield
    Friend WithEvents ubfCode7 As ucBiofield
    Friend WithEvents ubfCode10 As ucBiofield
    Friend WithEvents ubfCode9 As ucBiofield
    Friend WithEvents ubfCode12 As ucBiofield
    Friend WithEvents ubfCode11 As ucBiofield
    Friend WithEvents ubfCode14 As ucBiofield
    Friend WithEvents ubfCode13 As ucBiofield
    Friend WithEvents ubfCode16 As ucBiofield
    Friend WithEvents ubfCode15 As ucBiofield
    Friend WithEvents ubfCode18 As ucBiofield
    Friend WithEvents ubfCode17 As ucBiofield
    Friend WithEvents ubfCode20 As ucBiofield
    Friend WithEvents ubfCode19 As ucBiofield
    Friend WithEvents cmbClient As System.Windows.Forms.ComboBox
    Friend WithEvents lblClientName As System.Windows.Forms.Label
    Friend WithEvents grpJobBiofield As System.Windows.Forms.GroupBox
    Friend WithEvents lblClientContactName As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txbReportTemplate As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbCostCode As System.Windows.Forms.ComboBox
    Friend WithEvents dtpRequired As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
End Class
