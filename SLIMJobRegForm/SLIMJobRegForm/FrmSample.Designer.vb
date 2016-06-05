<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSample
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
        Me.cmbSampleType = New System.Windows.Forms.ComboBox()
        Me.lblSampleType = New System.Windows.Forms.Label()
        Me.txbClientDesc = New System.Windows.Forms.TextBox()
        Me.txbID = New System.Windows.Forms.TextBox()
        Me.lblSGSDesc = New System.Windows.Forms.Label()
        Me.lblClientDesc = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbArticleNo = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbColor = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMaterial = New System.Windows.Forms.ComboBox()
        Me.txbRemark = New System.Windows.Forms.TextBox()
        Me.btnDelBF = New System.Windows.Forms.Button()
        Me.btnAddBF = New System.Windows.Forms.Button()
        Me.sbBiofield = New System.Windows.Forms.VScrollBar()
        Me.txbSGSDesc = New System.Windows.Forms.TextBox()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.LsvSample = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colClientDesc = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colSGSDesc = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colColor = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colFiberComp = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colMaterial = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colRemark = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.colArticle = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblLinkedIDText = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbProductCode = New System.Windows.Forms.ComboBox()
        Me.gpbSampleBiofield = New System.Windows.Forms.GroupBox()
        Me.btnCopyLastSam = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lsvSpecCompSample = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ubfCode1 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode3 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode5 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode7 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode20 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode19 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode18 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode9 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode16 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode17 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode14 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode11 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode12 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode15 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode10 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode13 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode8 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode2 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode6 = New SLIMJobRegForm.ucBiofield()
        Me.ubfCode4 = New SLIMJobRegForm.ucBiofield()
        Me.gpbSampleBiofield.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbSampleType
        '
        Me.cmbSampleType.FormattingEnabled = True
        Me.cmbSampleType.Items.AddRange(New Object() {"Original", "Specimen", "Composite"})
        Me.cmbSampleType.Location = New System.Drawing.Point(121, 18)
        Me.cmbSampleType.Name = "cmbSampleType"
        Me.cmbSampleType.Size = New System.Drawing.Size(210, 21)
        Me.cmbSampleType.TabIndex = 0
        '
        'lblSampleType
        '
        Me.lblSampleType.AllowDrop = True
        Me.lblSampleType.AutoSize = True
        Me.lblSampleType.Location = New System.Drawing.Point(16, 21)
        Me.lblSampleType.Name = "lblSampleType"
        Me.lblSampleType.Size = New System.Drawing.Size(69, 13)
        Me.lblSampleType.TabIndex = 38
        Me.lblSampleType.Text = "Sample Type"
        '
        'txbClientDesc
        '
        Me.txbClientDesc.Location = New System.Drawing.Point(480, 45)
        Me.txbClientDesc.Name = "txbClientDesc"
        Me.txbClientDesc.Size = New System.Drawing.Size(210, 20)
        Me.txbClientDesc.TabIndex = 3
        '
        'txbID
        '
        Me.txbID.Location = New System.Drawing.Point(480, 21)
        Me.txbID.Name = "txbID"
        Me.txbID.Size = New System.Drawing.Size(210, 20)
        Me.txbID.TabIndex = 1
        '
        'lblSGSDesc
        '
        Me.lblSGSDesc.AllowDrop = True
        Me.lblSGSDesc.AutoSize = True
        Me.lblSGSDesc.Location = New System.Drawing.Point(16, 45)
        Me.lblSGSDesc.Name = "lblSGSDesc"
        Me.lblSGSDesc.Size = New System.Drawing.Size(85, 13)
        Me.lblSGSDesc.TabIndex = 39
        Me.lblSGSDesc.Text = "SGS Description"
        '
        'lblClientDesc
        '
        Me.lblClientDesc.AllowDrop = True
        Me.lblClientDesc.AutoSize = True
        Me.lblClientDesc.Location = New System.Drawing.Point(361, 46)
        Me.lblClientDesc.Name = "lblClientDesc"
        Me.lblClientDesc.Size = New System.Drawing.Size(89, 13)
        Me.lblClientDesc.TabIndex = 39
        Me.lblClientDesc.Text = "Client Description"
        '
        'Label1
        '
        Me.Label1.AllowDrop = True
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(361, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Sample ID "
        '
        'Label2
        '
        Me.Label2.AllowDrop = True
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 39
        Me.Label2.Text = "Article No"
        '
        'cmbArticleNo
        '
        Me.cmbArticleNo.FormattingEnabled = True
        Me.cmbArticleNo.Location = New System.Drawing.Point(121, 69)
        Me.cmbArticleNo.Name = "cmbArticleNo"
        Me.cmbArticleNo.Size = New System.Drawing.Size(210, 21)
        Me.cmbArticleNo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AllowDrop = True
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(361, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Color"
        '
        'cmbColor
        '
        Me.cmbColor.BackColor = System.Drawing.SystemColors.Window
        Me.cmbColor.FormattingEnabled = True
        Me.cmbColor.Location = New System.Drawing.Point(480, 69)
        Me.cmbColor.Name = "cmbColor"
        Me.cmbColor.Size = New System.Drawing.Size(210, 21)
        Me.cmbColor.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AllowDrop = True
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 99)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "Material"
        '
        'Label5
        '
        Me.Label5.AllowDrop = True
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(361, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Remark"
        '
        'cmbMaterial
        '
        Me.cmbMaterial.FormattingEnabled = True
        Me.cmbMaterial.Location = New System.Drawing.Point(121, 96)
        Me.cmbMaterial.Name = "cmbMaterial"
        Me.cmbMaterial.Size = New System.Drawing.Size(210, 21)
        Me.cmbMaterial.TabIndex = 6
        '
        'txbRemark
        '
        Me.txbRemark.Location = New System.Drawing.Point(480, 96)
        Me.txbRemark.Name = "txbRemark"
        Me.txbRemark.Size = New System.Drawing.Size(210, 20)
        Me.txbRemark.TabIndex = 7
        '
        'btnDelBF
        '
        Me.btnDelBF.Location = New System.Drawing.Point(87, 19)
        Me.btnDelBF.Name = "btnDelBF"
        Me.btnDelBF.Size = New System.Drawing.Size(75, 23)
        Me.btnDelBF.TabIndex = 1
        Me.btnDelBF.Text = "Del BioField"
        Me.btnDelBF.UseVisualStyleBackColor = True
        '
        'btnAddBF
        '
        Me.btnAddBF.Location = New System.Drawing.Point(6, 19)
        Me.btnAddBF.Name = "btnAddBF"
        Me.btnAddBF.Size = New System.Drawing.Size(75, 23)
        Me.btnAddBF.TabIndex = 0
        Me.btnAddBF.Text = "Add BioField"
        Me.btnAddBF.UseVisualStyleBackColor = True
        '
        'sbBiofield
        '
        Me.sbBiofield.LargeChange = 1
        Me.sbBiofield.Location = New System.Drawing.Point(703, 48)
        Me.sbBiofield.Maximum = 10
        Me.sbBiofield.Name = "sbBiofield"
        Me.sbBiofield.Size = New System.Drawing.Size(15, 237)
        Me.sbBiofield.TabIndex = 22
        '
        'txbSGSDesc
        '
        Me.txbSGSDesc.Location = New System.Drawing.Point(121, 43)
        Me.txbSGSDesc.Name = "txbSGSDesc"
        Me.txbSGSDesc.Size = New System.Drawing.Size(210, 20)
        Me.txbSGSDesc.TabIndex = 2
        '
        'btnDone
        '
        Me.btnDone.Location = New System.Drawing.Point(661, 153)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(75, 23)
        Me.btnDone.TabIndex = 9
        Me.btnDone.Text = "Done"
        Me.btnDone.UseVisualStyleBackColor = True
        '
        'LsvSample
        '
        Me.LsvSample.AllowColumnReorder = True
        Me.LsvSample.BackColor = System.Drawing.SystemColors.Window
        Me.LsvSample.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colClientDesc, Me.colSGSDesc, Me.colColor, Me.colFiberComp, Me.colMaterial, Me.colRemark, Me.colArticle})
        Me.LsvSample.FullRowSelect = True
        Me.LsvSample.HideSelection = False
        Me.LsvSample.Location = New System.Drawing.Point(742, 37)
        Me.LsvSample.Name = "LsvSample"
        Me.LsvSample.Size = New System.Drawing.Size(400, 231)
        Me.LsvSample.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LsvSample.TabIndex = 11
        Me.LsvSample.UseCompatibleStateImageBehavior = False
        Me.LsvSample.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        '
        'colClientDesc
        '
        Me.colClientDesc.Text = "Client Desc"
        Me.colClientDesc.Width = 95
        '
        'colSGSDesc
        '
        Me.colSGSDesc.Text = "SGS Desc"
        Me.colSGSDesc.Width = 142
        '
        'colColor
        '
        Me.colColor.Text = "Color"
        '
        'colFiberComp
        '
        Me.colFiberComp.Text = "Fiber Composition"
        '
        'colMaterial
        '
        Me.colMaterial.Text = "Material"
        '
        'colRemark
        '
        Me.colRemark.Text = "Remark"
        '
        'colArticle
        '
        Me.colArticle.Text = "Article No"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(742, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 66
        Me.Label6.Text = "Linked ID"
        '
        'lblLinkedIDText
        '
        Me.lblLinkedIDText.AutoSize = True
        Me.lblLinkedIDText.Location = New System.Drawing.Point(802, 21)
        Me.lblLinkedIDText.Name = "lblLinkedIDText"
        Me.lblLinkedIDText.Size = New System.Drawing.Size(0, 13)
        Me.lblLinkedIDText.TabIndex = 67
        '
        'Label7
        '
        Me.Label7.AllowDrop = True
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Product Code"
        '
        'cmbProductCode
        '
        Me.cmbProductCode.FormattingEnabled = True
        Me.cmbProductCode.Location = New System.Drawing.Point(121, 123)
        Me.cmbProductCode.Name = "cmbProductCode"
        Me.cmbProductCode.Size = New System.Drawing.Size(210, 21)
        Me.cmbProductCode.TabIndex = 8
        '
        'gpbSampleBiofield
        '
        Me.gpbSampleBiofield.Controls.Add(Me.btnAddBF)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode1)
        Me.gpbSampleBiofield.Controls.Add(Me.btnDelBF)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode3)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode5)
        Me.gpbSampleBiofield.Controls.Add(Me.sbBiofield)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode7)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode20)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode19)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode18)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode9)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode16)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode17)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode14)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode11)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode12)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode15)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode10)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode13)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode8)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode2)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode6)
        Me.gpbSampleBiofield.Controls.Add(Me.ubfCode4)
        Me.gpbSampleBiofield.Location = New System.Drawing.Point(19, 192)
        Me.gpbSampleBiofield.Name = "gpbSampleBiofield"
        Me.gpbSampleBiofield.Size = New System.Drawing.Size(718, 285)
        Me.gpbSampleBiofield.TabIndex = 10
        Me.gpbSampleBiofield.TabStop = False
        Me.gpbSampleBiofield.Text = "Biofield"
        '
        'btnCopyLastSam
        '
        Me.btnCopyLastSam.Location = New System.Drawing.Point(19, 153)
        Me.btnCopyLastSam.Name = "btnCopyLastSam"
        Me.btnCopyLastSam.Size = New System.Drawing.Size(112, 23)
        Me.btnCopyLastSam.TabIndex = 68
        Me.btnCopyLastSam.Text = "Copy Last Sample"
        Me.btnCopyLastSam.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(739, 284)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(146, 13)
        Me.Label8.TabIndex = 66
        Me.Label8.Text = "Specimen/Composite Sample"
        '
        'lsvSpecCompSample
        '
        Me.lsvSpecCompSample.AllowColumnReorder = True
        Me.lsvSpecCompSample.BackColor = System.Drawing.SystemColors.Window
        Me.lsvSpecCompSample.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.lsvSpecCompSample.FullRowSelect = True
        Me.lsvSpecCompSample.HideSelection = False
        Me.lsvSpecCompSample.Location = New System.Drawing.Point(742, 300)
        Me.lsvSpecCompSample.Name = "lsvSpecCompSample"
        Me.lsvSpecCompSample.Size = New System.Drawing.Size(400, 177)
        Me.lsvSpecCompSample.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lsvSpecCompSample.TabIndex = 69
        Me.lsvSpecCompSample.UseCompatibleStateImageBehavior = False
        Me.lsvSpecCompSample.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Sample Type"
        Me.ColumnHeader9.Width = 94
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Client Desc"
        Me.ColumnHeader2.Width = 95
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "SGS Desc"
        Me.ColumnHeader3.Width = 142
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Color"
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Fiber Composition"
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Material"
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Remark"
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Article No"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1116, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 23)
        Me.Button1.TabIndex = 70
        Me.Button1.Text = "<"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1116, 483)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 23)
        Me.Button2.TabIndex = 70
        Me.Button2.Text = "<"
        Me.Button2.UseVisualStyleBackColor = True
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
        Me.ubfCode3.Location = New System.Drawing.Point(6, 70)
        Me.ubfCode3.Name = "ubfCode3"
        Me.ubfCode3.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode3.TabIndex = 4
        '
        'ubfCode5
        '
        Me.ubfCode5.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode5.Location = New System.Drawing.Point(6, 92)
        Me.ubfCode5.Name = "ubfCode5"
        Me.ubfCode5.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode5.TabIndex = 6
        '
        'ubfCode7
        '
        Me.ubfCode7.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode7.Location = New System.Drawing.Point(6, 116)
        Me.ubfCode7.Name = "ubfCode7"
        Me.ubfCode7.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode7.TabIndex = 8
        '
        'ubfCode20
        '
        Me.ubfCode20.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode20.Location = New System.Drawing.Point(358, 252)
        Me.ubfCode20.Name = "ubfCode20"
        Me.ubfCode20.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode20.TabIndex = 21
        '
        'ubfCode19
        '
        Me.ubfCode19.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode19.Location = New System.Drawing.Point(6, 252)
        Me.ubfCode19.Name = "ubfCode19"
        Me.ubfCode19.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode19.TabIndex = 20
        '
        'ubfCode18
        '
        Me.ubfCode18.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode18.Location = New System.Drawing.Point(358, 228)
        Me.ubfCode18.Name = "ubfCode18"
        Me.ubfCode18.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode18.TabIndex = 19
        '
        'ubfCode9
        '
        Me.ubfCode9.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode9.Location = New System.Drawing.Point(6, 139)
        Me.ubfCode9.Name = "ubfCode9"
        Me.ubfCode9.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode9.TabIndex = 10
        '
        'ubfCode16
        '
        Me.ubfCode16.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode16.Location = New System.Drawing.Point(358, 205)
        Me.ubfCode16.Name = "ubfCode16"
        Me.ubfCode16.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode16.TabIndex = 17
        '
        'ubfCode17
        '
        Me.ubfCode17.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode17.Location = New System.Drawing.Point(6, 228)
        Me.ubfCode17.Name = "ubfCode17"
        Me.ubfCode17.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode17.TabIndex = 18
        '
        'ubfCode14
        '
        Me.ubfCode14.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode14.Location = New System.Drawing.Point(358, 183)
        Me.ubfCode14.Name = "ubfCode14"
        Me.ubfCode14.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode14.TabIndex = 15
        '
        'ubfCode11
        '
        Me.ubfCode11.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode11.Location = New System.Drawing.Point(6, 161)
        Me.ubfCode11.Name = "ubfCode11"
        Me.ubfCode11.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode11.TabIndex = 12
        '
        'ubfCode12
        '
        Me.ubfCode12.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode12.Location = New System.Drawing.Point(358, 162)
        Me.ubfCode12.Name = "ubfCode12"
        Me.ubfCode12.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode12.TabIndex = 13
        '
        'ubfCode15
        '
        Me.ubfCode15.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode15.Location = New System.Drawing.Point(6, 204)
        Me.ubfCode15.Name = "ubfCode15"
        Me.ubfCode15.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode15.TabIndex = 16
        '
        'ubfCode10
        '
        Me.ubfCode10.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode10.Location = New System.Drawing.Point(358, 140)
        Me.ubfCode10.Name = "ubfCode10"
        Me.ubfCode10.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode10.TabIndex = 11
        '
        'ubfCode13
        '
        Me.ubfCode13.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode13.Location = New System.Drawing.Point(6, 182)
        Me.ubfCode13.Name = "ubfCode13"
        Me.ubfCode13.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode13.TabIndex = 14
        '
        'ubfCode8
        '
        Me.ubfCode8.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode8.Location = New System.Drawing.Point(358, 117)
        Me.ubfCode8.Name = "ubfCode8"
        Me.ubfCode8.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode8.TabIndex = 9
        '
        'ubfCode2
        '
        Me.ubfCode2.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode2.Location = New System.Drawing.Point(358, 48)
        Me.ubfCode2.Name = "ubfCode2"
        Me.ubfCode2.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode2.TabIndex = 3
        '
        'ubfCode6
        '
        Me.ubfCode6.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode6.Location = New System.Drawing.Point(358, 95)
        Me.ubfCode6.Name = "ubfCode6"
        Me.ubfCode6.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode6.TabIndex = 7
        '
        'ubfCode4
        '
        Me.ubfCode4.BackColor = System.Drawing.SystemColors.Control
        Me.ubfCode4.Location = New System.Drawing.Point(358, 72)
        Me.ubfCode4.Name = "ubfCode4"
        Me.ubfCode4.Size = New System.Drawing.Size(339, 27)
        Me.ubfCode4.TabIndex = 5
        '
        'FrmSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1153, 509)
        Me.Controls.Add(Me.LsvSample)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lsvSpecCompSample)
        Me.Controls.Add(Me.btnCopyLastSam)
        Me.Controls.Add(Me.gpbSampleBiofield)
        Me.Controls.Add(Me.lblLinkedIDText)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.cmbSampleType)
        Me.Controls.Add(Me.cmbProductCode)
        Me.Controls.Add(Me.cmbMaterial)
        Me.Controls.Add(Me.cmbColor)
        Me.Controls.Add(Me.cmbArticleNo)
        Me.Controls.Add(Me.lblSampleType)
        Me.Controls.Add(Me.txbRemark)
        Me.Controls.Add(Me.txbSGSDesc)
        Me.Controls.Add(Me.txbClientDesc)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txbID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblClientDesc)
        Me.Controls.Add(Me.lblSGSDesc)
        Me.MaximumSize = New System.Drawing.Size(1169, 547)
        Me.Name = "FrmSample"
        Me.Text = "Sample"
        Me.gpbSampleBiofield.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents cmbSampleType As System.Windows.Forms.ComboBox
    Friend WithEvents lblSampleType As System.Windows.Forms.Label
    Friend WithEvents txbClientDesc As System.Windows.Forms.TextBox
    Friend WithEvents txbID As System.Windows.Forms.TextBox
    Friend WithEvents lblSGSDesc As System.Windows.Forms.Label
    Friend WithEvents lblClientDesc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbArticleNo As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbColor As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMaterial As System.Windows.Forms.ComboBox
    Friend WithEvents txbRemark As System.Windows.Forms.TextBox
    Friend WithEvents btnDelBF As System.Windows.Forms.Button
    Friend WithEvents btnAddBF As System.Windows.Forms.Button
    Friend WithEvents sbBiofield As System.Windows.Forms.VScrollBar
    Friend WithEvents ubfCode19 As ucBiofield
    Friend WithEvents ubfCode17 As ucBiofield
    Friend WithEvents ubfCode15 As ucBiofield
    Friend WithEvents ubfCode13 As ucBiofield
    Friend WithEvents ubfCode11 As ucBiofield
    Friend WithEvents ubfCode9 As ucBiofield
    Friend WithEvents ubfCode7 As ucBiofield
    Friend WithEvents ubfCode5 As ucBiofield
    Friend WithEvents ubfCode3 As ucBiofield
    Friend WithEvents ubfCode20 As ucBiofield
    Friend WithEvents ubfCode18 As ucBiofield
    Friend WithEvents ubfCode16 As ucBiofield
    Friend WithEvents ubfCode14 As ucBiofield
    Friend WithEvents ubfCode12 As ucBiofield
    Friend WithEvents ubfCode10 As ucBiofield
    Friend WithEvents ubfCode8 As ucBiofield
    Friend WithEvents ubfCode6 As ucBiofield
    Friend WithEvents ubfCode4 As ucBiofield
    Friend WithEvents ubfCode2 As ucBiofield
    Friend WithEvents ubfCode1 As ucBiofield
    Friend WithEvents txbSGSDesc As System.Windows.Forms.TextBox
    Friend WithEvents btnDone As System.Windows.Forms.Button
    Friend WithEvents LsvSample As System.Windows.Forms.ListView
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colClientDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSGSDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblLinkedIDText As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbProductCode As System.Windows.Forms.ComboBox
    Friend WithEvents gpbSampleBiofield As System.Windows.Forms.GroupBox
    Friend WithEvents btnCopyLastSam As System.Windows.Forms.Button
    Friend WithEvents colColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFiberComp As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMaterial As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRemark As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArticle As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lsvSpecCompSample As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
