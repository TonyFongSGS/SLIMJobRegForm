<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSchemeAdd
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
        Me.lvSample = New System.Windows.Forms.ListView()
        Me.colID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSampleType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colClientDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colSGSDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colColor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colFiberComp = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colMaterial = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colRemark = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colArticle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.TrvScheme = New System.Windows.Forms.TreeView()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnMoreScheme = New System.Windows.Forms.Button()
        Me.btnLoadScheme = New System.Windows.Forms.Button()
        Me.lblSchemeMethod = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnMoreSample = New System.Windows.Forms.Button()
        Me.txbField1 = New System.Windows.Forms.TextBox()
        Me.txbField2 = New System.Windows.Forms.TextBox()
        Me.txbField3 = New System.Windows.Forms.TextBox()
        Me.lblField1 = New System.Windows.Forms.Label()
        Me.lblField2 = New System.Windows.Forms.Label()
        Me.lblField3 = New System.Windows.Forms.Label()
        Me.btnSwapProcDescCode = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lvSample
        '
        Me.lvSample.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colID, Me.colSampleType, Me.colClientDesc, Me.colSGSDesc, Me.colColor, Me.colFiberComp, Me.colMaterial, Me.colRemark, Me.colArticle})
        Me.lvSample.FullRowSelect = True
        Me.lvSample.HideSelection = False
        Me.lvSample.Location = New System.Drawing.Point(304, 29)
        Me.lvSample.Name = "lvSample"
        Me.lvSample.Size = New System.Drawing.Size(655, 360)
        Me.lvSample.TabIndex = 1
        Me.lvSample.UseCompatibleStateImageBehavior = False
        Me.lvSample.View = System.Windows.Forms.View.Details
        '
        'colID
        '
        Me.colID.Text = "ID"
        Me.colID.Width = 37
        '
        'colSampleType
        '
        Me.colSampleType.Text = "SampleType"
        Me.colSampleType.Width = 79
        '
        'colClientDesc
        '
        Me.colClientDesc.Text = "ClientDesc"
        Me.colClientDesc.Width = 107
        '
        'colSGSDesc
        '
        Me.colSGSDesc.Text = "SGS Desc"
        Me.colSGSDesc.Width = 164
        '
        'colColor
        '
        Me.colColor.Text = "Color"
        Me.colColor.Width = 101
        '
        'colFiberComp
        '
        Me.colFiberComp.Text = "Fiber Composition"
        Me.colFiberComp.Width = 109
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
        'TrvScheme
        '
        Me.TrvScheme.CheckBoxes = True
        Me.TrvScheme.Location = New System.Drawing.Point(23, 29)
        Me.TrvScheme.Name = "TrvScheme"
        Me.TrvScheme.ShowNodeToolTips = True
        Me.TrvScheme.Size = New System.Drawing.Size(256, 360)
        Me.TrvScheme.TabIndex = 0
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(850, 482)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(109, 23)
        Me.btnAdd.TabIndex = 4
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnMoreScheme
        '
        Me.btnMoreScheme.Location = New System.Drawing.Point(189, 482)
        Me.btnMoreScheme.Name = "btnMoreScheme"
        Me.btnMoreScheme.Size = New System.Drawing.Size(90, 23)
        Me.btnMoreScheme.TabIndex = 3
        Me.btnMoreScheme.Text = "More Scheme"
        Me.btnMoreScheme.UseVisualStyleBackColor = True
        '
        'btnLoadScheme
        '
        Me.btnLoadScheme.Location = New System.Drawing.Point(23, 482)
        Me.btnLoadScheme.Name = "btnLoadScheme"
        Me.btnLoadScheme.Size = New System.Drawing.Size(113, 23)
        Me.btnLoadScheme.TabIndex = 2
        Me.btnLoadScheme.Text = "Map Client Package"
        Me.btnLoadScheme.UseVisualStyleBackColor = True
        '
        'lblSchemeMethod
        '
        Me.lblSchemeMethod.AutoSize = True
        Me.lblSchemeMethod.Location = New System.Drawing.Point(410, 482)
        Me.lblSchemeMethod.Name = "lblSchemeMethod"
        Me.lblSchemeMethod.Size = New System.Drawing.Size(116, 13)
        Me.lblSchemeMethod.TabIndex = 5
        Me.lblSchemeMethod.Text = "No scheme selected... "
        Me.lblSchemeMethod.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "SCHEME"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(301, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "SAMPLE"
        '
        'btnMoreSample
        '
        Me.btnMoreSample.Location = New System.Drawing.Point(859, 5)
        Me.btnMoreSample.Name = "btnMoreSample"
        Me.btnMoreSample.Size = New System.Drawing.Size(100, 23)
        Me.btnMoreSample.TabIndex = 7
        Me.btnMoreSample.Text = "More Sample"
        Me.btnMoreSample.UseVisualStyleBackColor = True
        '
        'txbField1
        '
        Me.txbField1.Location = New System.Drawing.Point(23, 421)
        Me.txbField1.Multiline = True
        Me.txbField1.Name = "txbField1"
        Me.txbField1.ReadOnly = True
        Me.txbField1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txbField1.Size = New System.Drawing.Size(312, 55)
        Me.txbField1.TabIndex = 8
        '
        'txbField2
        '
        Me.txbField2.Location = New System.Drawing.Point(344, 421)
        Me.txbField2.Multiline = True
        Me.txbField2.Name = "txbField2"
        Me.txbField2.ReadOnly = True
        Me.txbField2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txbField2.Size = New System.Drawing.Size(305, 55)
        Me.txbField2.TabIndex = 8
        '
        'txbField3
        '
        Me.txbField3.Location = New System.Drawing.Point(652, 421)
        Me.txbField3.Multiline = True
        Me.txbField3.Name = "txbField3"
        Me.txbField3.ReadOnly = True
        Me.txbField3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txbField3.Size = New System.Drawing.Size(307, 55)
        Me.txbField3.TabIndex = 8
        '
        'lblField1
        '
        Me.lblField1.AutoSize = True
        Me.lblField1.Location = New System.Drawing.Point(23, 400)
        Me.lblField1.Name = "lblField1"
        Me.lblField1.Size = New System.Drawing.Size(162, 13)
        Me.lblField1.TabIndex = 9
        Me.lblField1.Text = "Scheme Desc / Procedure Desc"
        '
        'lblField2
        '
        Me.lblField2.AutoSize = True
        Me.lblField2.Location = New System.Drawing.Point(341, 400)
        Me.lblField2.Name = "lblField2"
        Me.lblField2.Size = New System.Drawing.Size(77, 13)
        Me.lblField2.TabIndex = 9
        Me.lblField2.Text = "Scheme Name"
        '
        'lblField3
        '
        Me.lblField3.AutoSize = True
        Me.lblField3.Location = New System.Drawing.Point(649, 400)
        Me.lblField3.Name = "lblField3"
        Me.lblField3.Size = New System.Drawing.Size(43, 13)
        Me.lblField3.TabIndex = 9
        Me.lblField3.Text = "Method"
        '
        'btnSwapProcDescCode
        '
        Me.btnSwapProcDescCode.Image = Global.SLIMJobRegForm.My.Resources.Resources.refresh_16xLG
        Me.btnSwapProcDescCode.Location = New System.Drawing.Point(251, 4)
        Me.btnSwapProcDescCode.Name = "btnSwapProcDescCode"
        Me.btnSwapProcDescCode.Size = New System.Drawing.Size(27, 23)
        Me.btnSwapProcDescCode.TabIndex = 10
        Me.btnSwapProcDescCode.Tag = "Swap Procedure Description and Code"
        Me.btnSwapProcDescCode.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSwapProcDescCode.UseVisualStyleBackColor = True
        '
        'frmSchemeAdd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 517)
        Me.Controls.Add(Me.btnSwapProcDescCode)
        Me.Controls.Add(Me.lblField3)
        Me.Controls.Add(Me.lblField2)
        Me.Controls.Add(Me.lblField1)
        Me.Controls.Add(Me.txbField3)
        Me.Controls.Add(Me.txbField2)
        Me.Controls.Add(Me.txbField1)
        Me.Controls.Add(Me.btnMoreSample)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblSchemeMethod)
        Me.Controls.Add(Me.btnLoadScheme)
        Me.Controls.Add(Me.btnMoreScheme)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.TrvScheme)
        Me.Controls.Add(Me.lvSample)
        Me.Name = "frmSchemeAdd"
        Me.Text = "Scheme - Add"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lvSample As System.Windows.Forms.ListView
    Friend WithEvents TrvScheme As System.Windows.Forms.TreeView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents colID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSampleType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colClientDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSGSDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnMoreScheme As System.Windows.Forms.Button
    Friend WithEvents btnLoadScheme As System.Windows.Forms.Button
    Friend WithEvents lblSchemeMethod As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnMoreSample As System.Windows.Forms.Button
    Friend WithEvents txbField1 As System.Windows.Forms.TextBox
    Friend WithEvents txbField2 As System.Windows.Forms.TextBox
    Friend WithEvents txbField3 As System.Windows.Forms.TextBox
    Friend WithEvents lblField1 As System.Windows.Forms.Label
    Friend WithEvents lblField2 As System.Windows.Forms.Label
    Friend WithEvents lblField3 As System.Windows.Forms.Label
    Friend WithEvents colFiberComp As System.Windows.Forms.ColumnHeader
    Friend WithEvents colMaterial As System.Windows.Forms.ColumnHeader
    Friend WithEvents colRemark As System.Windows.Forms.ColumnHeader
    Friend WithEvents colArticle As System.Windows.Forms.ColumnHeader
    Friend WithEvents colColor As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnSwapProcDescCode As System.Windows.Forms.Button
End Class
