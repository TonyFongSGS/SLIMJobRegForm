Imports Microsoft.Office.Tools.Ribbon

Public Class Ribbon1

    Private Sub Ribbon1_Load(ByVal sender As System.Object, ByVal e As RibbonUIEventArgs) Handles MyBase.Load
        Dim cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)
        Dim sLabcodes() As String = cfgSLIM.AppSettings.Settings("Labcodes").Value.Split(",")
        cmbLabcode.Items.Clear()
        Dim rdiNew As RibbonDropDownItem
        If sLabcodes.Length > 1 Then
            For li As Integer = 0 To sLabcodes.Length - 1
                If sLabcodes(li).Trim.Length > 0 Then
                    rdiNew = Globals.Factory.GetRibbonFactory.CreateRibbonDropDownItem
                    rdiNew.Label = sLabcodes(li).Trim
                    cmbLabcode.Items.Add(rdiNew)
                End If
            Next
        ElseIf sLabcodes(0).Trim.Length > 0 Then
            rdiNew = Globals.Factory.GetRibbonFactory.CreateRibbonDropDownItem
            rdiNew.Label = sLabcodes(0)
            cmbLabcode.Items.Add(rdiNew)
        End If

        If cfgSLIM.AppSettings.Settings("ActiveLabcode").Value.Length > 0 Then
            cmbLabcode.Text = cfgSLIM.AppSettings.Settings("ActiveLabcode").Value
        End If
    End Sub

    Private Sub btnNewJob_Click(sender As Object, e As RibbonControlEventArgs) Handles btnNewJob.Click
        Call ThisAddIn.setSLIMWorkBook()

        'Call ThisAddIn.procECVXML()
    End Sub

    Private Sub btnOpenXML_Click(sender As Object, e As RibbonControlEventArgs) Handles btnECVOpenXML.Click
        Call ThisAddIn.convECVXML(OpenFileDialog1)
        'MsgBox("Converted")
    End Sub

    Private Sub btnJob_Click(sender As Object, e As RibbonControlEventArgs) Handles btnJob.Click
        Call ThisAddIn.AddJob()

    End Sub

    Private Sub btnOpenSLIMXML_Click(sender As Object, e As RibbonControlEventArgs) Handles btnOpenSLIMXML.Click
        'Dim fJob As New frmJob
        'fJob.Show()
        OpenFileDialog1.Filter = "XML (*.xml)|*.xml"
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Call ThisAddIn.openSLIMXML(OpenFileDialog1.FileName())
        End If
    End Sub

    Private Sub btnSample_Click(sender As Object, e As RibbonControlEventArgs)
        Call ThisAddIn.AddSample()
    End Sub

    Private Sub btnScheme_Click(sender As Object, e As RibbonControlEventArgs) Handles btnScheme.Click
        Call ThisAddIn.AddSchemeBySample()
    End Sub

    Private Sub btnExport_Click(sender As Object, e As RibbonControlEventArgs) Handles btnExport.Click
        Call ThisAddIn.ExportSLIMXML()

    End Sub


    Private Sub btnAbout_Click(sender As Object, e As RibbonControlEventArgs) Handles btnAbout.Click
        MsgBox("SLIM Job Reg Form (Version 1.3.2, 2016/6/3, CTS SL)")
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As RibbonControlEventArgs) Handles btnHelp.Click
        Dim frmHelp As New FrmHelp

        frmHelp.ShowDialog()

    End Sub


    Private Sub cmbLabcode_TextChanged(sender As Object, e As RibbonControlEventArgs) Handles cmbLabcode.TextChanged
        Dim cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)

        cfgSLIM.AppSettings.Settings("ActiveLabcode").Value = cmbLabcode.Text

        cfgSLIM.Save(Configuration.ConfigurationSaveMode.Modified)
        Configuration.ConfigurationManager.RefreshSection("appSettings")
    End Sub

    Private Sub btnConfig_Click(sender As Object, e As RibbonControlEventArgs) Handles btnConfig.Click
        'Fail - built by ConfigurationSectionDesigner
        'Dim cfgLabcode As SLIMJobRegFormConfig.Labcodes
        'cfgLabcode = Configuration.ConfigurationManager.GetSection("labcodes")
        'MsgBox(SLIMJobRegFormConfig.Labcodes.Instance.Labcode.name)

        'Fail (error in section handler) - Ref to Microsoft but still fail 
        'Dim config As SLIMJobRegFormConfig2.PageAppearanceSection = _
        'CType(System.Configuration.ConfigurationManager.GetSection( _
        '  "pageAppearanceGroup/pageAppearance"),  _
        'SLIMJobRegFormConfig2.PageAppearanceSection)

        Call ThisAddIn.ConfigLabcodes()
    End Sub


    Private Sub grySample_Click(sender As Object, e As RibbonControlEventArgs) Handles grySample.Click

        'If sender.SelectedItem.ToString.Equals("Add") Then
        '    Call ThisAddIn.AddSample()
        'ElseIf sender.SelectedItem.ToString.Equals("Delete") Then
        '    Call ThisAddIn.DeleteSample()
        'End If

    End Sub

    Private Sub btnGrySampleAdd_Click(sender As Object, e As RibbonControlEventArgs) Handles btnGrySampleAdd.Click
        Call ThisAddIn.AddSample()
    End Sub

    Private Sub btnGrySampleDelete_Click(sender As Object, e As RibbonControlEventArgs) Handles btnGrySampleDelete.Click
        Call ThisAddIn.DeleteSample()
    End Sub
End Class
