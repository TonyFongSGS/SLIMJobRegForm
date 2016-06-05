<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSchemeSearch
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txbProcedureDesc = New System.Windows.Forms.TextBox()
        Me.txbProcedureNote = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbProcedureGroup = New System.Windows.Forms.ComboBox()
        Me.cmbProcedureSubGroup = New System.Windows.Forms.ComboBox()
        Me.lsvSearchProcScheme = New System.Windows.Forms.ListView()
        Me.colProcedureCode = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProcedureDesc = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProcedureGroup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProcedureSubGroup = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.colProcedureNote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.txbProcedureCode = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClearResult = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.ckbProcNoteEmpty = New System.Windows.Forms.CheckBox()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Procedure Group"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Procedure Sub Group"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(393, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Procedure Description"
        '
        'txbProcedureDesc
        '
        Me.txbProcedureDesc.Location = New System.Drawing.Point(508, 40)
        Me.txbProcedureDesc.Name = "txbProcedureDesc"
        Me.txbProcedureDesc.Size = New System.Drawing.Size(229, 20)
        Me.txbProcedureDesc.TabIndex = 3
        '
        'txbProcedureNote
        '
        Me.txbProcedureNote.Location = New System.Drawing.Point(128, 63)
        Me.txbProcedureNote.Name = "txbProcedureNote"
        Me.txbProcedureNote.Size = New System.Drawing.Size(229, 20)
        Me.txbProcedureNote.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Proc Note (Package)"
        '
        'cmbProcedureGroup
        '
        Me.cmbProcedureGroup.FormattingEnabled = True
        Me.cmbProcedureGroup.Location = New System.Drawing.Point(128, 13)
        Me.cmbProcedureGroup.Name = "cmbProcedureGroup"
        Me.cmbProcedureGroup.Size = New System.Drawing.Size(229, 21)
        Me.cmbProcedureGroup.TabIndex = 0
        '
        'cmbProcedureSubGroup
        '
        Me.cmbProcedureSubGroup.FormattingEnabled = True
        Me.cmbProcedureSubGroup.Location = New System.Drawing.Point(128, 38)
        Me.cmbProcedureSubGroup.Name = "cmbProcedureSubGroup"
        Me.cmbProcedureSubGroup.Size = New System.Drawing.Size(229, 21)
        Me.cmbProcedureSubGroup.TabIndex = 2
        '
        'lsvSearchProcScheme
        '
        Me.lsvSearchProcScheme.CheckBoxes = True
        Me.lsvSearchProcScheme.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colProcedureCode, Me.colProcedureDesc, Me.colProcedureGroup, Me.colProcedureSubGroup, Me.colProcedureNote})
        Me.lsvSearchProcScheme.HideSelection = False
        Me.lsvSearchProcScheme.LabelWrap = False
        Me.lsvSearchProcScheme.Location = New System.Drawing.Point(15, 133)
        Me.lsvSearchProcScheme.Name = "lsvSearchProcScheme"
        Me.lsvSearchProcScheme.Size = New System.Drawing.Size(722, 300)
        Me.lsvSearchProcScheme.TabIndex = 7
        Me.lsvSearchProcScheme.UseCompatibleStateImageBehavior = False
        Me.lsvSearchProcScheme.View = System.Windows.Forms.View.Details
        '
        'colProcedureCode
        '
        Me.colProcedureCode.Text = "Procedure Code"
        Me.colProcedureCode.Width = 145
        '
        'colProcedureDesc
        '
        Me.colProcedureDesc.Text = "Description"
        Me.colProcedureDesc.Width = 145
        '
        'colProcedureGroup
        '
        Me.colProcedureGroup.Text = "Group"
        Me.colProcedureGroup.Width = 90
        '
        'colProcedureSubGroup
        '
        Me.colProcedureSubGroup.Text = "Sub Group"
        Me.colProcedureSubGroup.Width = 110
        '
        'colProcedureNote
        '
        Me.colProcedureNote.Text = "Note (Package)"
        Me.colProcedureNote.Width = 207
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(642, 439)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(95, 23)
        Me.btnAdd.TabIndex = 8
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(662, 104)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txbProcedureCode
        '
        Me.txbProcedureCode.Location = New System.Drawing.Point(508, 14)
        Me.txbProcedureCode.Name = "txbProcedureCode"
        Me.txbProcedureCode.Size = New System.Drawing.Size(229, 20)
        Me.txbProcedureCode.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(393, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Procedure Code"
        '
        'btnClearResult
        '
        Me.btnClearResult.Location = New System.Drawing.Point(582, 104)
        Me.btnClearResult.Name = "btnClearResult"
        Me.btnClearResult.Size = New System.Drawing.Size(75, 23)
        Me.btnClearResult.TabIndex = 9
        Me.btnClearResult.Text = "Clear Result"
        Me.btnClearResult.UseVisualStyleBackColor = True
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(15, 104)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(75, 23)
        Me.btnSelectAll.TabIndex = 10
        Me.btnSelectAll.Text = "Select All"
        Me.btnSelectAll.UseVisualStyleBackColor = True
        '
        'ckbProcNoteEmpty
        '
        Me.ckbProcNoteEmpty.AutoSize = True
        Me.ckbProcNoteEmpty.Location = New System.Drawing.Point(364, 65)
        Me.ckbProcNoteEmpty.Name = "ckbProcNoteEmpty"
        Me.ckbProcNoteEmpty.Size = New System.Drawing.Size(15, 14)
        Me.ckbProcNoteEmpty.TabIndex = 11
        Me.ckbProcNoteEmpty.UseVisualStyleBackColor = True
        '
        'btnClearAll
        '
        Me.btnClearAll.ContextMenuStrip = Me.ContextMenuStrip1
        Me.btnClearAll.Location = New System.Drawing.Point(96, 104)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(75, 23)
        Me.btnClearAll.TabIndex = 10
        Me.btnClearAll.Text = "Clear All"
        Me.btnClearAll.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.ClearAllToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(121, 48)
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ClearToolStripMenuItem.Text = "Select all"
        '
        'ClearAllToolStripMenuItem
        '
        Me.ClearAllToolStripMenuItem.Name = "ClearAllToolStripMenuItem"
        Me.ClearAllToolStripMenuItem.Size = New System.Drawing.Size(120, 22)
        Me.ClearAllToolStripMenuItem.Text = "Clear all"
        '
        'FrmSchemeSearch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(749, 474)
        Me.Controls.Add(Me.ckbProcNoteEmpty)
        Me.Controls.Add(Me.btnClearAll)
        Me.Controls.Add(Me.btnSelectAll)
        Me.Controls.Add(Me.btnClearResult)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.lsvSearchProcScheme)
        Me.Controls.Add(Me.cmbProcedureSubGroup)
        Me.Controls.Add(Me.cmbProcedureGroup)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txbProcedureCode)
        Me.Controls.Add(Me.txbProcedureDesc)
        Me.Controls.Add(Me.txbProcedureNote)
        Me.Name = "FrmSchemeSearch"
        Me.Text = "Procedure Search"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbProcedureDesc As System.Windows.Forms.TextBox
    Friend WithEvents txbProcedureNote As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbProcedureGroup As System.Windows.Forms.ComboBox
    Friend WithEvents cmbProcedureSubGroup As System.Windows.Forms.ComboBox
    Friend WithEvents lsvSearchProcScheme As System.Windows.Forms.ListView
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents colProcedureCode As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProcedureDesc As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProcedureGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProcedureSubGroup As System.Windows.Forms.ColumnHeader
    Friend WithEvents colProcedureNote As System.Windows.Forms.ColumnHeader
    Friend WithEvents txbProcedureCode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnClearResult As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents ckbProcNoteEmpty As System.Windows.Forms.CheckBox
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClearAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
