Partial Class Ribbon1
    Inherits Microsoft.Office.Tools.Ribbon.RibbonBase

    <System.Diagnostics.DebuggerNonUserCode()> _
   Public Sub New(ByVal container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        If (container IsNot Nothing) Then
            container.Add(Me)
        End If

    End Sub

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New(Globals.Factory.GetRibbonFactory())

        'This call is required by the Component Designer.
        InitializeComponent()

    End Sub

    'Component overrides dispose to clean up the component list.
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

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TabSGSSLIM = Me.Factory.CreateRibbonTab
        Me.grpSLIM = Me.Factory.CreateRibbonGroup
        Me.grpReg = Me.Factory.CreateRibbonGroup
        Me.grpECV = Me.Factory.CreateRibbonGroup
        Me.grpAbout = Me.Factory.CreateRibbonGroup
        Me.cmbLabcode = Me.Factory.CreateRibbonComboBox
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenSLIMXML = Me.Factory.CreateRibbonButton
        Me.btnNewJob = Me.Factory.CreateRibbonButton
        Me.btnExport = Me.Factory.CreateRibbonButton
        Me.btnJob = Me.Factory.CreateRibbonButton
        Me.grySample = Me.Factory.CreateRibbonGallery
        Me.btnGrySampleAdd = Me.Factory.CreateRibbonButton
        Me.btnGrySampleDelete = Me.Factory.CreateRibbonButton
        Me.btnScheme = Me.Factory.CreateRibbonButton
        Me.btnSchemeView = Me.Factory.CreateRibbonButton
        Me.btnECVOpenXML = Me.Factory.CreateRibbonButton
        Me.btnConfig = Me.Factory.CreateRibbonButton
        Me.btnAbout = Me.Factory.CreateRibbonButton
        Me.btnHelp = Me.Factory.CreateRibbonButton
        Me.TabSGSSLIM.SuspendLayout()
        Me.grpSLIM.SuspendLayout()
        Me.grpReg.SuspendLayout()
        Me.grpECV.SuspendLayout()
        Me.grpAbout.SuspendLayout()
        '
        'TabSGSSLIM
        '
        Me.TabSGSSLIM.Groups.Add(Me.grpSLIM)
        Me.TabSGSSLIM.Groups.Add(Me.grpReg)
        Me.TabSGSSLIM.Groups.Add(Me.grpECV)
        Me.TabSGSSLIM.Groups.Add(Me.grpAbout)
        Me.TabSGSSLIM.Label = "SGS SLIM"
        Me.TabSGSSLIM.Name = "TabSGSSLIM"
        '
        'grpSLIM
        '
        Me.grpSLIM.Items.Add(Me.btnOpenSLIMXML)
        Me.grpSLIM.Items.Add(Me.btnNewJob)
        Me.grpSLIM.Items.Add(Me.btnExport)
        Me.grpSLIM.Label = "SLIM Workbook"
        Me.grpSLIM.Name = "grpSLIM"
        '
        'grpReg
        '
        Me.grpReg.Items.Add(Me.btnJob)
        Me.grpReg.Items.Add(Me.grySample)
        Me.grpReg.Items.Add(Me.btnScheme)
        Me.grpReg.Items.Add(Me.btnSchemeView)
        Me.grpReg.Label = "Register"
        Me.grpReg.Name = "grpReg"
        '
        'grpECV
        '
        Me.grpECV.Items.Add(Me.btnECVOpenXML)
        Me.grpECV.Label = "ecVision"
        Me.grpECV.Name = "grpECV"
        '
        'grpAbout
        '
        Me.grpAbout.Items.Add(Me.btnConfig)
        Me.grpAbout.Items.Add(Me.cmbLabcode)
        Me.grpAbout.Items.Add(Me.btnAbout)
        Me.grpAbout.Items.Add(Me.btnHelp)
        Me.grpAbout.Label = "Support"
        Me.grpAbout.Name = "grpAbout"
        '
        'cmbLabcode
        '
        Me.cmbLabcode.Label = "Labcode"
        Me.cmbLabcode.Name = "cmbLabcode"
        Me.cmbLabcode.Text = Nothing
        '
        'btnOpenSLIMXML
        '
        Me.btnOpenSLIMXML.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnOpenSLIMXML.Label = "Open XML"
        Me.btnOpenSLIMXML.Name = "btnOpenSLIMXML"
        Me.btnOpenSLIMXML.OfficeImageId = "ExportExcel"
        Me.btnOpenSLIMXML.ShowImage = True
        '
        'btnNewJob
        '
        Me.btnNewJob.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnNewJob.Label = "New"
        Me.btnNewJob.Name = "btnNewJob"
        Me.btnNewJob.OfficeImageId = "WindowNew"
        Me.btnNewJob.ShowImage = True
        '
        'btnExport
        '
        Me.btnExport.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnExport.Label = "Export XML"
        Me.btnExport.Name = "btnExport"
        Me.btnExport.OfficeImageId = "ExportTextFile"
        Me.btnExport.ShowImage = True
        '
        'btnJob
        '
        Me.btnJob.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnJob.Label = "Job"
        Me.btnJob.Name = "btnJob"
        Me.btnJob.OfficeImageId = "ContactPictureMenu"
        Me.btnJob.ShowImage = True
        '
        'grySample
        '
        Me.grySample.Buttons.Add(Me.btnGrySampleAdd)
        Me.grySample.Buttons.Add(Me.btnGrySampleDelete)
        Me.grySample.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.grySample.Label = "Sample"
        Me.grySample.Name = "grySample"
        Me.grySample.OfficeImageId = "ClipArtInsert"
        Me.grySample.ShowImage = True
        '
        'btnGrySampleAdd
        '
        Me.btnGrySampleAdd.Label = "Add"
        Me.btnGrySampleAdd.Name = "btnGrySampleAdd"
        Me.btnGrySampleAdd.OfficeImageId = "TableRowsInsertWord"
        Me.btnGrySampleAdd.ShowImage = True
        '
        'btnGrySampleDelete
        '
        Me.btnGrySampleDelete.Label = "Delete"
        Me.btnGrySampleDelete.Name = "btnGrySampleDelete"
        Me.btnGrySampleDelete.OfficeImageId = "TableRowsDelete"
        Me.btnGrySampleDelete.ShowImage = True
        '
        'btnScheme
        '
        Me.btnScheme.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnScheme.Label = "Scheme Add"
        Me.btnScheme.Name = "btnScheme"
        Me.btnScheme.OfficeImageId = "ModuleInsert"
        Me.btnScheme.ShowImage = True
        '
        'btnSchemeView
        '
        Me.btnSchemeView.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnSchemeView.Enabled = False
        Me.btnSchemeView.Label = "Scheme View"
        Me.btnSchemeView.Name = "btnSchemeView"
        Me.btnSchemeView.OfficeImageId = "VisualBasic"
        Me.btnSchemeView.ShowImage = True
        '
        'btnECVOpenXML
        '
        Me.btnECVOpenXML.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnECVOpenXML.Label = "Open XML"
        Me.btnECVOpenXML.Name = "btnECVOpenXML"
        Me.btnECVOpenXML.OfficeImageId = "ImportSavedImports"
        Me.btnECVOpenXML.ShowImage = True
        '
        'btnConfig
        '
        Me.btnConfig.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge
        Me.btnConfig.Label = "Lab Config"
        Me.btnConfig.Name = "btnConfig"
        Me.btnConfig.OfficeImageId = "PageMenu"
        Me.btnConfig.ShowImage = True
        '
        'btnAbout
        '
        Me.btnAbout.Label = "About"
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.OfficeImageId = "CreateMap"
        Me.btnAbout.ShowImage = True
        '
        'btnHelp
        '
        Me.btnHelp.Label = "Help"
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.OfficeImageId = "FunctionsLogicalInsertGallery"
        Me.btnHelp.ShowImage = True
        '
        'Ribbon1
        '
        Me.Name = "Ribbon1"
        Me.RibbonType = "Microsoft.Excel.Workbook"
        Me.Tabs.Add(Me.TabSGSSLIM)
        Me.TabSGSSLIM.ResumeLayout(False)
        Me.TabSGSSLIM.PerformLayout()
        Me.grpSLIM.ResumeLayout(False)
        Me.grpSLIM.PerformLayout()
        Me.grpReg.ResumeLayout(False)
        Me.grpReg.PerformLayout()
        Me.grpECV.ResumeLayout(False)
        Me.grpECV.PerformLayout()
        Me.grpAbout.ResumeLayout(False)
        Me.grpAbout.PerformLayout()

    End Sub

    Friend WithEvents TabSGSSLIM As Microsoft.Office.Tools.Ribbon.RibbonTab
    Friend WithEvents grpSLIM As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnOpenSLIMXML As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnNewJob As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpECV As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnECVOpenXML As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpReg As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnJob As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnScheme As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnExport As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grpAbout As Microsoft.Office.Tools.Ribbon.RibbonGroup
    Friend WithEvents btnAbout As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnHelp As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnSchemeView As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents cmbLabcode As Microsoft.Office.Tools.Ribbon.RibbonComboBox
    Friend WithEvents btnConfig As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents grySample As Microsoft.Office.Tools.Ribbon.RibbonGallery
    Friend WithEvents btnGrySampleAdd As Microsoft.Office.Tools.Ribbon.RibbonButton
    Friend WithEvents btnGrySampleDelete As Microsoft.Office.Tools.Ribbon.RibbonButton
End Class

Partial Class ThisRibbonCollection

    <System.Diagnostics.DebuggerNonUserCode()> _
    Friend ReadOnly Property Ribbon1() As Ribbon1
        Get
            Return Me.GetRibbon(Of Ribbon1)()
        End Get
    End Property
End Class
