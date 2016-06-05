Public Class FrmSample
    Const BIOFIELDCOUNT As Integer = 20
    Private lsBiofield As List(Of Biofield)
    Private lsBiofieldOld As List(Of Biofield)
    Private lsSampleOrig As List(Of Windows.Forms.ListViewItem)
    Private lsSampleSpec As List(Of Windows.Forms.ListViewItem)
    Private lsSampleSpecComp As List(Of Windows.Forms.ListViewItem)
    Private xSheet As Excel.Worksheet
    Private xList As Excel.ListObject
    Private xListBF As Excel.ListObject
    Private bUpdate As Boolean

    Private cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)
    Private wsSLIM As New CCLAS.CCLASXMLServiceSoapClient
    Private sInitRes As String = ""

    Private bProductQueried As Boolean = False
    Public lRowID As Integer

    Private Sub FrmSample_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Windows.Forms.Keys.PageUp Then
            If sbBiofield.Maximum > 0 Then
                sbBiofield.Value -= 1
            End If
        ElseIf e.KeyCode = Windows.Forms.Keys.PageDown Then
            If sbBiofield.Maximum < sbBiofield.Value + 1 Then
                sbBiofield.Value += 1
            End If
        End If
    End Sub

    Private Sub FrmSample_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If IsNothing(xSheet) Then
            MsgBox("Error - Not SLIM Job Reg Workbook")
            Me.Close()
            Exit Sub
        Else
            xList = ThisAddIn.getList(xSheet, ThisAddIn.SAMLIST, False)
            xListBF = ThisAddIn.getList(xSheet, ThisAddIn.SAMLISTBF, False)
            If IsNothing(xList) Or IsNothing(xListBF) Then
                MsgBox("Error - Not SLIM Job Reg Workbook")
                Me.Close()
                Exit Sub
            End If
        End If

        'Avoid user in edit more before open this form
        'Tried this but not work ---------------------
        'If Not Globals.ThisAddIn.Application.Ready Then
        '    MsgBox("Not ready")
        'End If
        'Try
        '    If xList.AutoFilter.FilterMode Then
        '        'About will throw error if in edit more
        '        xList.AutoFilter.ShowAllData()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Please press ""Esc"" to exit edit mode before using Job Reg Form function.")
        '    Me.Close()
        '    Exit Sub
        'End Try
        'Try this ------------------------------------
        If ThisAddIn.IsExcelInEdit Then
            MsgBox("Please press ""Esc"" or  ""Enter"" to exit edit mode before using Job Reg Form function.")
            Me.Close()
            Exit Sub
        End If

        ThisAddIn.ManageSampleList()

        If lRowID <= 0 Then
            'Look for max ID
            GetID()
            lsBiofield = New List(Of Biofield)
            lsBiofieldOld = New List(Of Biofield)
            cmbSampleType.Text = cmbSampleType.Items(1)
            cmbProductCode.Text = ThisAddIn.GetJobValue("Product Code")
        Else
            bUpdate = True

            lblLinkedIDText.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Linked ID").Index).Value2
            txbID.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Sample ID").Index).Value2
            cmbSampleType.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Sample Type").Index).Value2
            cmbSampleType.Enabled = False
            txbSGSDesc.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("SGS Desc").Index).Value2
            txbClientDesc.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Client Desc").Index).Value2
            cmbArticleNo.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Article No").Index).Value2
            cmbColor.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Color").Index).Value2
            cmbMaterial.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Material").Index).Value2
            txbRemark.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Remark").Index).Value2
            cmbProductCode.Text = xList.Range.Cells(lRowID + 1, xList.ListColumns("Product Code").Index).Value2

            Dim oBiofield() As Biofield
            Dim lNo As Integer = -1
            'Remove duplicate BF per sample per biofield - move up to apply for both new or update sample process
            'Dim xCol(1) As Object
            'xCol.SetValue(1, 0)
            'xCol.SetValue(2, 1)
            'xSheet.Range(ThisAddIn.SAMLISTBF).RemoveDuplicates(xCol, Excel.XlYesNoGuess.xlYes)
            For lI As Integer = 1 To xListBF.ListRows.Count
                If xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Sample ID").Index).Value2 = txbID.Text Then
                    lNo += 1
                    ReDim Preserve oBiofield(lNo)

                    oBiofield(lNo) = New Biofield With {
                        .SampleIdent = txbID.Text, _
                        .Biofield = xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Biofield").Index).Value2, _
                        .BioValue = xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Value").Index).Value2, _
                        .ReportActive = Convert.ToInt32(xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Report Active").Index).Value2), _
                        .ListRowNo = lI _
                    }
                End If

            Next
            If oBiofield IsNot Nothing Then
                lsBiofield = oBiofield.ToList
                lsBiofieldOld = oBiofield.ToList
            Else
                lsBiofield = New List(Of Biofield)
                lsBiofieldOld = New List(Of Biofield)
            End If

            If lsBiofield.Count = 0 Then
                sbBiofield.Maximum = 0
            Else
                sbBiofield.Maximum = (Math.Ceiling(lsBiofield.Count / BIOFIELDCOUNT)) - 1
            End If
        End If
        RefreshSpecCompSampleList()
        RefreshBiofield()
        highlightSampleFields()
        If cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_SampleClientDescNumberDigit").Value.ToUpper.Equals("TRUE") Then
            ThisAddIn.fetchUserData(wsSLIM, "DESCRIPTION_6")
            RefreshDropDownFrUserData(cmbColor, "DESCRIPTION_6")
            ThisAddIn.fetchUserData(wsSLIM, "DESCRIPTION_3")
            RefreshDropDownFrUserData(cmbArticleNo, "DESCRIPTION_3")
            ThisAddIn.fetchUserData(wsSLIM, "DESCRIPTION_5")
            RefreshDropDownFrUserData(cmbMaterial, "DESCRIPTION_5")
        End If
    End Sub
    Public Sub RefreshDropDownFrUserData(ByRef cmbDropDown As System.Windows.Forms.ComboBox, sUD_DataField As String)
        Dim xSheet As Excel.Worksheet
        Dim xList As Excel.ListObject

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.UDSHEET, False, True)
        xList = ThisAddIn.getList(xSheet, ThisAddIn.UDLIST, False)

        For lI As Integer = 1 To xList.ListRows.Count
            If xList.Range.Cells(lI + 1, ThisAddIn.UD_DataField).value2.Equals(sUD_DataField) And xList.Range.Cells(lI + 1, ThisAddIn.UD_DataCode).value2 IsNot Nothing Then
                If xList.Range.Cells(lI + 1, ThisAddIn.UD_DataCode).value2.ToString.Length > 0 Then
                    cmbDropDown.Items.Add(xList.Range.Cells(lI + 1, ThisAddIn.UD_DataCode).value2)

                End If
            End If
        Next
    End Sub
    Public Sub RefreshBiofield(Optional lPage As Integer = 0)

        ThisAddIn.fetchUserData(wsSLIM, "BIOFIELDS")
        If lPage < 0 Then
            Exit Sub
        End If
        Dim lThisPageItemNo As Integer
        If lsBiofield Is Nothing Then
            lThisPageItemNo = 0
        Else
            lThisPageItemNo = lsBiofield.Count - lPage * BIOFIELDCOUNT
        End If
        If lThisPageItemNo >= 1 Then
            ubfCode1.SetField(lsBiofield(lPage * BIOFIELDCOUNT).Biofield, lsBiofield(lPage * BIOFIELDCOUNT).BioValue, lsBiofield(lPage * BIOFIELDCOUNT).ReportActive)
        Else
            ubfCode1.SetField("")
        End If
        If lThisPageItemNo >= 2 Then
            ubfCode2.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 1).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 1).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 1).ReportActive)
        Else
            ubfCode2.SetField("")
        End If
        If lThisPageItemNo >= 3 Then
            ubfCode3.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 2).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 2).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 2).ReportActive)
        Else
            ubfCode3.SetField("")
        End If
        If lThisPageItemNo >= 4 Then
            ubfCode4.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 3).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 3).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 3).ReportActive)
        Else
            ubfCode4.SetField("")
        End If
        If lThisPageItemNo >= 5 Then
            ubfCode5.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 4).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 4).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 4).ReportActive)
        Else
            ubfCode5.SetField("")
        End If
        If lThisPageItemNo >= 6 Then
            ubfCode6.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 5).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 5).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 5).ReportActive)
        Else
            ubfCode6.SetField("")
        End If
        If lThisPageItemNo >= 7 Then
            ubfCode7.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 6).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 6).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 6).ReportActive)
        Else
            ubfCode7.SetField("")
        End If
        If lThisPageItemNo >= 8 Then
            ubfCode8.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 7).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 7).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 7).ReportActive)
        Else
            ubfCode8.SetField("")
        End If
        If lThisPageItemNo >= 9 Then
            ubfCode9.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 8).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 8).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 8).ReportActive)
        Else
            ubfCode9.SetField("")
        End If
        If lThisPageItemNo >= 10 Then
            ubfCode10.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 9).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 9).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 9).ReportActive)
        Else
            ubfCode10.SetField("")
        End If
        If lThisPageItemNo >= 11 Then
            ubfCode11.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 10).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 10).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 10).ReportActive)
        Else
            ubfCode11.SetField("")
        End If
        If lThisPageItemNo >= 12 Then
            ubfCode12.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 11).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 11).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 11).ReportActive)
        Else
            ubfCode12.SetField("")
        End If
        If lThisPageItemNo >= 13 Then
            ubfCode13.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 12).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 12).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 12).ReportActive)
        Else
            ubfCode13.SetField("")
        End If
        If lThisPageItemNo >= 14 Then
            ubfCode14.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 13).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 13).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 13).ReportActive)
        Else
            ubfCode14.SetField("")
        End If
        If lThisPageItemNo >= 15 Then
            ubfCode15.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 14).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 14).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 14).ReportActive)
        Else
            ubfCode15.SetField("")
        End If
        If lThisPageItemNo >= 16 Then
            ubfCode16.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 15).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 15).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 15).ReportActive)
        Else
            ubfCode16.SetField("")
        End If
        If lThisPageItemNo >= 17 Then
            ubfCode17.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 16).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 16).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 16).ReportActive)
        Else
            ubfCode17.SetField("")
        End If
        If lThisPageItemNo >= 18 Then
            ubfCode18.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 17).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 17).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 17).ReportActive)
        Else
            ubfCode18.SetField("")
        End If
        If lThisPageItemNo >= 19 Then
            ubfCode19.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 18).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 18).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 18).ReportActive)
        Else
            ubfCode19.SetField("")
        End If
        If lThisPageItemNo >= 20 Then
            ubfCode20.SetField(lsBiofield(lPage * BIOFIELDCOUNT + 19).Biofield, lsBiofield(lPage * BIOFIELDCOUNT + 19).BioValue, lsBiofield(lPage * BIOFIELDCOUNT + 19).ReportActive)
        Else
            ubfCode20.SetField("")
        End If
        'highlightSampleBioFieldFields()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click

        Dim xListRow As Excel.ListRow
        'Dim xFilter As Excel.Filter
        Globals.ThisAddIn.Application.ScreenUpdating = False

        Try
            If xList.AutoFilter.FilterMode Then
                xList.AutoFilter.ShowAllData()
            End If
            If xListBF.AutoFilter.FilterMode Then
                'xFilter = xListBF.AutoFilter.Filters
                xListBF.AutoFilter.ShowAllData()
            End If
            If lRowID > 0 Then
                'Update current row of Sample
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Sample ID").Index) = txbID.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Sample Type").Index) = cmbSampleType.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Linked ID").Index) = lblLinkedIDText.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("SGS Desc").Index) = txbSGSDesc.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Client Desc").Index) = txbClientDesc.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Article No").Index) = cmbArticleNo.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Color").Index) = cmbColor.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Material").Index) = cmbMaterial.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Remark").Index) = txbRemark.Text
                xList.Range.Cells(lRowID + 1, xList.ListColumns("Product Code").Index) = cmbProductCode.Text

                If lsBiofield.Count > lsBiofieldOld.Count Then
                    'Update and Add from List Top
                    'Update 
                    For lI As Integer = 0 To lsBiofieldOld.Count - 1
                        If lsBiofield(lI).Biofield.Trim <> "" Then
                            'If lsBiofield(lI).Biofield <> lsBiofieldOld(lI).Biofield Or _
                            '   lsBiofield(lI).BioValue <> lsBiofieldOld(lI).BioValue Or _
                            '   lsBiofield(lI).ReportActive <> lsBiofieldOld(lI).ReportActive Then
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Sample ID").Index) = lsBiofield(lI).SampleIdent
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                            'End If
                        End If
                    Next
                    'Add
                    For lI As Integer = lsBiofieldOld.Count To lsBiofield.Count - 1
                        xListRow = xListBF.ListRows.AddEx
                        xListRow.Range.Cells(1, xListBF.ListColumns("Sample ID").Index) = lsBiofield(lI).SampleIdent
                        xListRow.Range.Cells(1, xListBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                        xListRow.Range.Cells(1, xListBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                        xListRow.Range.Cells(1, xListBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                    Next
                Else
                    'Delete and Update from List bottom
                    If lsBiofieldOld.Count = lsBiofield.Count Then
                    Else
                        For lI As Integer = lsBiofieldOld.Count To lsBiofield.Count + 1 Step -1
                            xListBF.ListRows(lsBiofieldOld(lI - 1).ListRowNo).Delete()
                        Next
                    End If
                    If lsBiofield.Count > 0 Then
                        For lI As Integer = 0 To lsBiofield.Count - 1
                            'If lsBiofield(lI).Biofield <> lsBiofieldOld(lI).Biofield Or _
                            '   lsBiofield(lI).BioValue <> lsBiofieldOld(lI).BioValue Or _
                            '   lsBiofield(lI).ReportActive <> lsBiofieldOld(lI).ReportActive Then
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Sample ID").Index) = lsBiofield(lI).SampleIdent
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                            xListBF.Range.Cells(lsBiofieldOld(lI).ListRowNo + 1, xListBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                            'End If
                        Next
                    End If
                End If
            Else
                'Add new row of Sample
                If lblLinkedIDText.Text.Length = 0 And cmbSampleType.Text.Equals("Specimen") Then
                    Throw New Exception("No linkage to original for this specimen sample.")
                ElseIf lblLinkedIDText.Text.Length = 0 And cmbSampleType.Text.Equals("Composite") Then
                    Throw New Exception("No linkage to specimen for this composite sample.")
                Else
                    xListRow = xList.ListRows.AddEx
                    xListRow.Range.Cells(1, xList.ListColumns("Sample ID").Index) = txbID.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Sample Type").Index) = cmbSampleType.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Linked ID").Index) = lblLinkedIDText.Text
                    xListRow.Range.Cells(1, xList.ListColumns("SGS Desc").Index) = txbSGSDesc.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Client Desc").Index) = txbClientDesc.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Article No").Index) = cmbArticleNo.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Color").Index) = cmbColor.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Material").Index) = cmbMaterial.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Remark").Index) = txbRemark.Text
                    xListRow.Range.Cells(1, xList.ListColumns("Product Code").Index) = cmbProductCode.Text

                    If lsBiofield.Count > 0 Then
                        For lI As Integer = 0 To lsBiofield.Count - 1
                            xListRow = xListBF.ListRows.AddEx()
                            xListRow.Range.Cells(1, xListBF.ListColumns("Sample ID").Index) = txbID.Text
                            xListRow.Range.Cells(1, xListBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                            xListRow.Range.Cells(1, xListBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                            xListRow.Range.Cells(1, xListBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                        Next
                    End If
                End If

            End If
            lRowID = 0
            GetID()

            If bUpdate Then
                Me.Close()
            ElseIf MsgBox("More?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                'Refresh client description when sample type = specimen
                If cmbSampleType.Text = "Specimen" Then
                    'A1 for Original A
                    txbClientDesc.Text = LsvSample.SelectedItems(0).SubItems(1).Text & GetNextIndex(LsvSample.SelectedItems(0).SubItems(1).Text).ToString(New String("0", cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_SampleClientDescNumberDigit").Value))
                End If
                RefreshSpecCompSampleList()
            Else
                Me.Close()
            End If
        Catch ex As Exception
            'MsgBox("Error - " & ex.Message & vbCrLf & "Please inform SLIM support.")
            MsgBox("Error - " & ex.Message)
        End Try
        Globals.ThisAddIn.Application.ScreenUpdating = True

    End Sub

    Private Sub btnAddBF_Click(sender As Object, e As EventArgs) Handles btnAddBF.Click
        Dim oBF As Biofield
        Dim aBF() As String
        aBF = GetNewBiofield().Split(",")
        If aBF(0).Length > 0 Then
            For lI As Integer = 0 To aBF.Count - 1
                If aBF(lI).Trim.Length > 0 Then
                    oBF = New Biofield(txbID.Text, aBF(lI))
                    lsBiofield.Add(oBF)
                End If

            Next
        End If
        sbBiofield.Maximum = (Math.Ceiling(lsBiofield.Count / BIOFIELDCOUNT)) - 1
        If sbBiofield.Value = sbBiofield.Maximum Then
            RefreshBiofield(sbBiofield.Value)
        Else
            sbBiofield.Value = sbBiofield.Maximum
        End If

    End Sub
    Private Function GetNewBiofield() As String
        GetNewBiofield = InputBox("Please input Biofield")
        If GetNewBiofield.ToUpper.Equals("VF") Then
            Select Case cmbSampleType.Text
                Case "Original"
                    GetNewBiofield = "ECV.apptrcolorItemOid,ECV.apptrcolorItemNo,ECV.apptrcolorItemName,ECV.apptrcolorItemDescription,ECV.apptrcolorItemFiberContent,ECV.apptrcolorColorCode,ECV.apptrcolorColorName,ECV.apptrcolorColorSubDate,ECV.apptrcolorPatternNo,ECV.apptrcolorSampleTrimSize,ECV.apptrcolorItemColorOrSize,ECV.apptrcolorVendorRemark,ECV.apptrcolorItemStyleNo"
                Case "Specimen"
                    GetNewBiofield = "field1,field2,field3"
                Case "Composite"
                    GetNewBiofield = "field1,field2,field3"
                Case Else
                    GetNewBiofield = "field1,field2,field3"
            End Select

        End If
    End Function

    Private Sub btnDelBF_Click(sender As Object, e As EventArgs) Handles btnDelBF.Click
        Dim lCurrPage As Integer
        lCurrPage = sbBiofield.Value

        If ubfCode20.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 19)
        End If
        If ubfCode19.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 18)
        End If
        If ubfCode18.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 17)
        End If
        If ubfCode17.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 16)
        End If
        If ubfCode16.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 15)
        End If
        If ubfCode15.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 14)
        End If
        If ubfCode14.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 13)
        End If
        If ubfCode13.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 12)
        End If
        If ubfCode12.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 11)
        End If
        If ubfCode11.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 10)
        End If
        If ubfCode10.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 9)
        End If
        If ubfCode9.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 8)
        End If
        If ubfCode8.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 7)
        End If
        If ubfCode7.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 6)
        End If
        If ubfCode6.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 5)
        End If
        If ubfCode5.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 4)
        End If
        If ubfCode4.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 3)
        End If
        If ubfCode3.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 2)
        End If
        If ubfCode2.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT + 1)
        End If
        If ubfCode1.BackColor = System.Drawing.SystemColors.Highlight Then
            lsBiofield.RemoveAt(lCurrPage * BIOFIELDCOUNT)
        End If
        RefreshBiofield(lCurrPage)
    End Sub

    Private Sub sbBiofield_ValueChanged(sender As Object, e As EventArgs) Handles sbBiofield.ValueChanged
        RefreshBiofield(sbBiofield.Value)
    End Sub

    Private Sub ubfCode_txtFieldValueTextChanged(sender As Object, e As EventArgs) Handles ubfCode1.txtFieldValueTextChanged, ubfCode2.txtFieldValueTextChanged, ubfCode3.txtFieldValueTextChanged, ubfCode4.txtFieldValueTextChanged, ubfCode5.txtFieldValueTextChanged, ubfCode6.txtFieldValueTextChanged, ubfCode7.txtFieldValueTextChanged, ubfCode8.txtFieldValueTextChanged, ubfCode9.txtFieldValueTextChanged, ubfCode10.txtFieldValueTextChanged, _
                                                                                            ubfCode11.txtFieldValueTextChanged, ubfCode12.txtFieldValueTextChanged, ubfCode13.txtFieldValueTextChanged, ubfCode14.txtFieldValueTextChanged, ubfCode15.txtFieldValueTextChanged, ubfCode16.txtFieldValueTextChanged, ubfCode17.txtFieldValueTextChanged, ubfCode18.txtFieldValueTextChanged, ubfCode19.txtFieldValueTextChanged, ubfCode20.txtFieldValueTextChanged
        Dim lIndex As Integer
        lIndex = (sbBiofield.Value * BIOFIELDCOUNT) + Convert.ToInt32(sender.Parent.Name.ToString.Substring("ubfCode".Length)) - 1
        UpdateBioFieldValue(lIndex, sender.Text)
    End Sub


    Private Sub ubfCode_chkRepActiveCheckedChanged(sender As Object, e As EventArgs) Handles ubfCode1.chkRepActiveCheckedChanged, ubfCode2.chkRepActiveCheckedChanged, ubfCode3.chkRepActiveCheckedChanged, ubfCode4.chkRepActiveCheckedChanged, ubfCode5.chkRepActiveCheckedChanged, ubfCode6.chkRepActiveCheckedChanged, ubfCode7.chkRepActiveCheckedChanged, ubfCode8.chkRepActiveCheckedChanged, ubfCode9.chkRepActiveCheckedChanged, ubfCode10.chkRepActiveCheckedChanged, _
                                                                                            ubfCode11.chkRepActiveCheckedChanged, ubfCode12.chkRepActiveCheckedChanged, ubfCode13.chkRepActiveCheckedChanged, ubfCode14.chkRepActiveCheckedChanged, ubfCode15.chkRepActiveCheckedChanged, ubfCode16.chkRepActiveCheckedChanged, ubfCode17.chkRepActiveCheckedChanged, ubfCode18.chkRepActiveCheckedChanged, ubfCode19.chkRepActiveCheckedChanged, ubfCode20.chkRepActiveCheckedChanged
        Dim lIndex As Integer
        lIndex = (sbBiofield.Value * BIOFIELDCOUNT) + Convert.ToInt32(sender.Parent.Name.ToString.Substring("ubfCode".Length)) - 1
        UpdateBioFieldReportActive(lIndex, sender.Checked)
    End Sub

    Private Sub ubfCode_cmbFieldValueSelectedIndexChanged(sender As Object, e As EventArgs) Handles ubfCode1.cmbFieldValueSelectedIndexChanged, ubfCode2.cmbFieldValueSelectedIndexChanged, ubfCode3.cmbFieldValueSelectedIndexChanged, ubfCode4.cmbFieldValueSelectedIndexChanged, ubfCode5.cmbFieldValueSelectedIndexChanged, ubfCode6.cmbFieldValueSelectedIndexChanged, ubfCode7.cmbFieldValueSelectedIndexChanged, ubfCode8.cmbFieldValueSelectedIndexChanged, ubfCode9.cmbFieldValueSelectedIndexChanged, ubfCode10.cmbFieldValueSelectedIndexChanged, _
                                                                                            ubfCode11.cmbFieldValueSelectedIndexChanged, ubfCode12.cmbFieldValueSelectedIndexChanged, ubfCode13.cmbFieldValueSelectedIndexChanged, ubfCode14.cmbFieldValueSelectedIndexChanged, ubfCode15.cmbFieldValueSelectedIndexChanged, ubfCode16.cmbFieldValueSelectedIndexChanged, ubfCode17.cmbFieldValueSelectedIndexChanged, ubfCode18.cmbFieldValueSelectedIndexChanged, ubfCode19.cmbFieldValueSelectedIndexChanged, ubfCode20.cmbFieldValueSelectedIndexChanged
        Dim lIndex As Integer
        lIndex = (sbBiofield.Value * BIOFIELDCOUNT) + Convert.ToInt32(sender.Parent.Name.ToString.Substring("ubfCode".Length)) - 1
        UpdateBioFieldValue(lIndex, sender.Text)
    End Sub
    Private Sub ubfCode_cmbFieldValueTextChanged(sender As Object, e As EventArgs) Handles ubfCode1.cmbFieldValueTextChanged, ubfCode2.cmbFieldValueTextChanged, ubfCode3.cmbFieldValueTextChanged, ubfCode4.cmbFieldValueTextChanged, ubfCode5.cmbFieldValueTextChanged, ubfCode6.cmbFieldValueTextChanged, ubfCode7.cmbFieldValueTextChanged, ubfCode8.cmbFieldValueTextChanged, ubfCode9.cmbFieldValueTextChanged, ubfCode10.cmbFieldValueTextChanged, _
                                                                                        ubfCode11.cmbFieldValueTextChanged, ubfCode12.cmbFieldValueTextChanged, ubfCode13.cmbFieldValueTextChanged, ubfCode14.cmbFieldValueTextChanged, ubfCode15.cmbFieldValueTextChanged, ubfCode16.cmbFieldValueTextChanged, ubfCode17.cmbFieldValueTextChanged, ubfCode18.cmbFieldValueTextChanged, ubfCode19.cmbFieldValueTextChanged, ubfCode20.cmbFieldValueTextChanged
        Dim lIndex As Integer
        lIndex = (sbBiofield.Value * BIOFIELDCOUNT) + Convert.ToInt32(sender.Parent.Name.ToString.Substring("ubfCode".Length)) - 1
        UpdateBioFieldValue(lIndex, sender.Text)
    End Sub
    'Private Sub cmbFieldValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFieldValue.SelectedIndexChanged
    '    RaiseEvent cmbFieldValueSelectedIndexChanged(sender, e)
    'End Sub

    'Private Sub dtpFieldValue_ValueChanged(sender As Object, e As EventArgs) Handles dtpFieldValue.ValueChanged
    '    RaiseEvent dtpFieldValueValueChanged(sender, e)
    'End Sub


    Private Sub UpdateBioFieldReportActive(lBiofieldItemNo As Integer, bChecked As Boolean)
        lsBiofield(lBiofieldItemNo).IsActive = bChecked
    End Sub
    Private Sub UpdateBioFieldValue(lBiofieldItemNo As Integer, sFieldValue As String)

        lsBiofield(lBiofieldItemNo).BioValue = sFieldValue
        If lsBiofield(lBiofieldItemNo).Biofield = "itx.correctionFactor" Then
            UpdateSGSClientDesc()
            If lsBiofield(lBiofieldItemNo).BioValue = "1" Then
                txbClientDesc.Text = ConvCTPSampleClientDesc(txbClientDesc.Text)
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbSampleType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSampleType.SelectedIndexChanged
        'If cmbSampleType.Text = "Original" Then
        'Else
        'Specimen or Composite
        RefreshSampleList()

        'To clear biofield if sample type is changed
        If lsBiofield IsNot Nothing Then
            lsBiofield.Clear()
        End If
        RefreshBiofield()

        'End If
    End Sub
    Private Sub RefreshSampleList()
        If cmbSampleType.Text = "Original" Then
            LsvSample.Items.Clear()
            LsvSample.Enabled = False
        ElseIf cmbSampleType.Text = "Specimen" Then
            LsvSample.Enabled = True
            LsvSample.MultiSelect = False
            LsvSample.Items.Clear()

            If lsSampleOrig Is Nothing Then
                lsSampleOrig = New List(Of Windows.Forms.ListViewItem)

                For lI As Integer = 1 To xList.ListRows.Count

                    If xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2 = "Original" Then
                        Dim sSamID As String = xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).Value2
                        lsSampleOrig.Add(New Windows.Forms.ListViewItem(New String() {sSamID, _
                                                                                      xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).Value2, _
                                                                                      xList.Range.Cells(lI + 1, xList.ListColumns("SGS Desc").Index).Value2, _
                                                                                      xList.Range.Cells(lI + 1, xList.ListColumns("Color").Index).Value2, _
                                                                          ThisAddIn.GetSampleBFValue(sSamID, "FIBER COMPOSITION"), _
                                                                          xList.Range.Cells(lI + 1, xList.ListColumns("Material").Index).Value2, _
                                                                          xList.Range.Cells(lI + 1, xList.ListColumns("Remark").Index).Value2, _
                                                                          xList.Range.Cells(lI + 1, xList.ListColumns("Article No").Index).Value2}))


                    End If
                Next
            End If
            LsvSample.Items.AddRange(lsSampleOrig.ToArray)
            For lI As Integer = 1 To LsvSample.Items.Count
                Dim sLinkedID As String = "," & lblLinkedIDText.Text & ","
                Dim sSampleID As String = "," & LsvSample.Items(lI - 1).Text & ","
                If sLinkedID.Contains(sSampleID) Then
                    LsvSample.Items(lI - 1).Selected = True
                End If
            Next
            SortSampleList(1)
        ElseIf cmbSampleType.Text = "Composite" Then
            LsvSample.Enabled = True
            LsvSample.MultiSelect = True
            LsvSample.Items.Clear()

            If lsSampleSpec Is Nothing Then
                lsSampleSpec = New List(Of Windows.Forms.ListViewItem)

                For lI As Integer = 1 To xList.ListRows.Count
                    If xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2 = "Specimen" Then
                        Dim sSamID As String = xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).Value2
                        lsSampleSpec.Add(New Windows.Forms.ListViewItem(New String() {sSamID, _
                                                                                      xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).Value2, _
                                                                                      xList.Range.Cells(lI + 1, xList.ListColumns("SGS Desc").Index).Value2, _
                                                                                       xList.Range.Cells(lI + 1, xList.ListColumns("Color").Index).Value2, _
                                                                          ThisAddIn.GetSampleBFValue(sSamID, "FIBER COMPOSITION"), _
                                                                          xList.Range.Cells(lI + 1, xList.ListColumns("Material").Index).Value2, _
                                                                          xList.Range.Cells(lI + 1, xList.ListColumns("Remark").Index).Value2, _
                                                                          xList.Range.Cells(lI + 1, xList.ListColumns("Article No").Index).Value2}))

                    End If
                Next
            End If
            LsvSample.Items.AddRange(lsSampleSpec.ToArray)

            RemoveHandler LsvSample.SelectedIndexChanged, AddressOf lsvSample_SelectedIndexChanged
            For lI As Integer = 1 To LsvSample.Items.Count
                Dim sLinkedID As String = "," & lblLinkedIDText.Text & ","
                Dim sSampleID As String = "," & LsvSample.Items(lI - 1).Text & ","
                If sLinkedID.Contains(sSampleID) Then
                    LsvSample.Items(lI - 1).Selected = True
                End If
            Next
            AddHandler LsvSample.SelectedIndexChanged, AddressOf lsvSample_SelectedIndexChanged
            SortSampleList(1)
        Else
            LsvSample.MultiSelect = False
        End If
    End Sub
    Private Sub RefreshSpecCompSampleList()
        lsvSpecCompSample.Items.Clear()

        'If lsSampleSpecComp Is Nothing Then
        lsSampleSpecComp = New List(Of Windows.Forms.ListViewItem)

        For lI As Integer = 1 To xList.ListRows.Count

            If xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2 = "Specimen" Or xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2 = "Composite" Then
                Dim sSamID As String = xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).Value2
                lsSampleSpecComp.Add(New Windows.Forms.ListViewItem(New String() {sSamID, _
                                                                            xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2, _
                                                                              xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).Value2, _
                                                                              xList.Range.Cells(lI + 1, xList.ListColumns("SGS Desc").Index).Value2, _
                                                                                  xList.Range.Cells(lI + 1, xList.ListColumns("Color").Index).Value2, _
                                                                  ThisAddIn.GetSampleBFValue(sSamID, "FIBER COMPOSITION"), _
                                                                  xList.Range.Cells(lI + 1, xList.ListColumns("Material").Index).Value2, _
                                                                  xList.Range.Cells(lI + 1, xList.ListColumns("Remark").Index).Value2, _
                                                                  xList.Range.Cells(lI + 1, xList.ListColumns("Article No").Index).Value2}))


            End If
        Next
        'End If
        lsvSpecCompSample.Items.AddRange(lsSampleSpecComp.ToArray)
        SortSpecCompSampleList(2)
    End Sub

    Private Sub lsvSample_ColumnClick(sender As Object, e As Windows.Forms.ColumnClickEventArgs) Handles LsvSample.ColumnClick
        SortSampleList(e.Column)
    End Sub

    Private Sub LsvSample_MouseHover(sender As Object, e As EventArgs) Handles LsvSample.MouseHover

    End Sub


    Private Sub lsvSample_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LsvSample.SelectedIndexChanged
        'RemoveHandler lsvSample.SelectedIndexChanged, AddressOf lsvSample_SelectedIndexChanged

        Dim sLinkedID As String
        sLinkedID = ""
        If LsvSample.SelectedItems.Count > 0 Then
            For lI As Integer = 1 To LsvSample.SelectedItems.Count
                sLinkedID = sLinkedID & LsvSample.SelectedItems(lI - 1).Text & ","
            Next

            If sLinkedID.Length > 0 Then
                lblLinkedIDText.Text = sLinkedID.TrimEnd(",")
            End If
            If cmbSampleType.Text = "Specimen" Then
                'A1 for Original A
                txbClientDesc.Text = LsvSample.SelectedItems(0).SubItems(1).Text & GetNextIndex(LsvSample.SelectedItems(0).SubItems(1).Text).ToString(New String("0", cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_SampleClientDescNumberDigit").Value))
            ElseIf cmbSampleType.Text = "Composite" Then
                'A1+B1+C1 for Specimen A1, B1 and C1 is selected
                txbClientDesc.Text = "+"
                txbSGSDesc.Text = "+"
                UpdateSGSClientDesc()

                'BF correction factor = 1

                If lsBiofield.Count > 0 Then
                    Dim lNum As Integer
                    For lI As Integer = 0 To lsBiofield.Count - 1
                        If lsBiofield(lI).Biofield = "itx.correctionFactor" Then
                            If Integer.TryParse(lsBiofield(lI).BioValue, lNum) Then
                            Else
                                lNum = -1
                            End If
                        End If
                    Next

                    If lNum = 1 Then
                        'convert A1+B1+C1 => (A+B+C)1
                        txbClientDesc.Text = ConvCTPSampleClientDesc(txbClientDesc.Text)
                    End If
                End If

                txbSGSDesc.Text = txbSGSDesc.Text.Trim("+")
            End If

            'Handling Biofield level 
            If cmbSampleType.Text = "Specimen" Then
                'Add/Update VF biofield
                'Dim sItemOid As String = GetBioValue(lblLinkedIDText.Text, "ECV.apptrcolorItemOid")
                'Dim sItemNo As String = GetBioValue(lblLinkedIDText.Text, "ECV.apptrcolorItemNo")
                'Dim sColorCode As String = GetBioValue(lblLinkedIDText.Text, "ECV.apptrcolorColorCode")
                'Dim bItemOid As Boolean = True
                'Dim bItemNo As Boolean = True
                'Dim bColorCode As Boolean = True
                'Dim bComposition As Boolean = True

                'Check biofield exists or not, if yes, update the value from GetBioValue above
                '=======================================================================================
                ' Old code before AddBiofield support "modify" action
                '=======================================================================================
                'If lsBiofield Is Nothing Then
                'ElseIf lsBiofield.Count > 0 Then
                '    For lI As Integer = 1 To lsBiofield.Count
                '        'ECV.apptrcolorItemOid()
                '        If lsBiofield(lI - 1).Biofield = "ECV.apptrcolorItemOid" Then
                '            lsBiofield(lI - 1).BioValue = sItemOid
                '            bItemOid = False
                '        End If
                '        'ECV.apptrcolorItemNo()
                '        If lsBiofield(lI - 1).Biofield = "ECV.apptrcolorItemNo" Then
                '            lsBiofield(lI - 1).BioValue = sItemNo
                '            bItemNo = False
                '        End If
                '        'ECV.apptrcolorColorCode()
                '        If lsBiofield(lI - 1).Biofield = "ECV.apptrcolorColorCode" Then
                '            lsBiofield(lI - 1).BioValue = sColorCode
                '            bColorCode = False
                '        End If
                '        'Composition()
                '        If lsBiofield(lI - 1).Biofield = "Composition" Then
                '            bComposition = False
                '        End If
                '    Next
                'End If
                'If bComposition Then
                '    AddBiofield("Composition", "", True, 0)
                'End If
                'If bColorCode Then
                '    AddBiofield("ECV.apptrcolorColorCode", sColorCode, True, 0)
                'End If
                'If bItemNo Then
                '    AddBiofield("ECV.apptrcolorItemNo", sItemNo, True, 0)
                'End If
                'If bItemOid Then
                '    AddBiofield("ECV.apptrcolorItemOid", sItemOid, 0)
                'End If
                '=======================================================================================
                AddBiofield("SPECIMEN REMARK", "", True, 0)
                AddBiofield("FIBER COMPOSITION", "", True, 0)
                AddBiofield("Composition", "", True, 0)
                AddBiofield("ECV.apptrcolorColorCode", GetBioValue(lblLinkedIDText.Text, "ECV.apptrcolorColorCode"), True, 0)
                AddBiofield("ECV.apptrcolorItemNo", GetBioValue(lblLinkedIDText.Text, "ECV.apptrcolorItemNo"), True, 0)
                AddBiofield("ECV.apptrcolorItemOid", GetBioValue(lblLinkedIDText.Text, "ECV.apptrcolorItemOid"), 0)

                'RefreshBiofield()
            ElseIf cmbSampleType.Text = "Composite" Then
                '=======================================================================================
                ' Old code before AddBiofield support "modify" action
                '=======================================================================================
                'Dim bCorrFactor As Boolean = True
                'If lsBiofield Is Nothing Then
                'ElseIf lsBiofield.Count > 0 Then
                '    For lI As Integer = 1 To lsBiofield.Count
                '        'Composition()
                '        If lsBiofield(lI - 1).Biofield = "itx.correctionFactor" Then
                '            bCorrFactor = False
                '        End If
                '    Next
                'End If
                'If bCorrFactor Then
                '    AddBiofield("itx.correctionFactor", IIf(MsgBox("Common Test Part?", vbYesNo) = vbYes, "1", ""), False, 0)
                'End If
                '=======================================================================================
                'Follow code will ask user everytime click on specimen for composite creation
                AddBiofield("itx.correctionFactor", "", False, 0)
            End If
            RefreshBiofield()
        End If

        'AddHandler lsvSample.SelectedIndexChanged, AddressOf lsvSample_SelectedIndexChanged
    End Sub
    Private Sub SortSampleList(ByRef lCol As Integer)
        LsvSample.ListViewItemSorter = New ListViewItemComparer(lCol)
        LsvSample.Sort()
    End Sub

    Private Sub SortSpecCompSampleList(ByRef lCol As Integer)
        lsvSpecCompSample.ListViewItemSorter = New ListViewItemComparer(lCol)
        lsvSpecCompSample.Sort()
    End Sub
    Private Function GetNextIndex(ByVal sPrefix) As Integer
        Dim lMax As Integer = 0
        For lI As Integer = 1 To xList.ListRows.Count
            If xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).value2 Is Nothing Then
            ElseIf String.IsNullOrEmpty(xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).Value2.ToString) Then
            Else
                If xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).Value2.ToString.Trim.StartsWith(sPrefix) Then
                    Dim lValue As Integer = 0
                    If Integer.TryParse(xList.Range.Cells(lI + 1, xList.ListColumns("Client Desc").Index).Value2.ToString.Substring(sPrefix.length), lValue) Then
                        If lValue > lMax Then
                            lMax = lValue
                        End If
                    End If
                End If
            End If
        Next
        GetNextIndex = lMax + 1
    End Function
    Private Sub AddBiofield(ByVal sField As String, ByVal sValue As String, ByVal lPosition As Integer)
        AddBiofield(sField, sValue, False, lPosition)
    End Sub

    Private Sub AddBiofield(ByVal sField As String, ByVal sValue As String, ByVal bActive As Boolean, ByVal lPosition As Integer)
        'Support both add or update
        Dim bNew As Boolean = True
        If lsBiofield Is Nothing Then
            lsBiofield = New List(Of Biofield)
        End If

        'Check if exists, only update, not add
        For lI As Integer = 1 To lsBiofield.Count
            If lsBiofield(lI - 1).Biofield = sField Then
                lsBiofield(lI - 1).BioValue = sValue
                bNew = False
                Exit For
            End If
        Next
        If bNew Then
            Dim oBF As Biofield = New Biofield With {.SampleIdent = txbID.Text, .Biofield = sField, .BioValue = sValue, .IsActive = bActive}
            lsBiofield.Insert(lPosition, oBF)
        End If


    End Sub

    Private Function GetBioValue(sSampleId As String, sBiofield As String) As String
        For lI As Integer = 1 To xListBF.ListRows.Count
            If xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Sample ID").Index).Value2 = sSampleId And _
                xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Biofield").Index).Value2 = sBiofield Then
                Return xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Value").Index).Value2
            End If
        Next
        GetBioValue = ""
    End Function

    Private Sub GetID()
        Dim lMax As Integer = 0
        Dim sThis As String
        Dim lThis As Integer
        For lI As Integer = 1 To xList.ListRows.Count
            sThis = xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).Value2
            If Integer.TryParse(sThis, lThis) Then
                If lThis > lMax Then
                    lMax = lThis
                End If
            Else
                'do something? delete it or assign a new value
            End If
        Next
        lMax += 1
        txbID.Text = lMax.ToString
        'lsBiofield = New List(Of Biofield)
        'lsBiofieldOld = New List(Of Biofield)
    End Sub
    Sub UpdateSGSClientDesc()
        txbClientDesc.Text = ""
        txbSGSDesc.Text = "+"
        For lI As Integer = 0 To LsvSample.SelectedItems.Count - 1
            txbClientDesc.Text = txbClientDesc.Text & LsvSample.SelectedItems(lI).SubItems(1).Text & "+"
            If txbSGSDesc.Text.IndexOf("+" & LsvSample.SelectedItems(lI).SubItems(2).Text & "+") >= 0 Then
            Else
                txbSGSDesc.Text = txbSGSDesc.Text & LsvSample.SelectedItems(lI).SubItems(2).Text & "+"

            End If
        Next
        txbClientDesc.Text = txbClientDesc.Text.Trim("+")
        txbSGSDesc.Text = txbSGSDesc.Text.Trim("+")
    End Sub
    Function ConvCTPSampleClientDesc(sClientDesc As String) As String
        'Simplified formula expression
        'A1+B1+C1 => (A/B/C)1
        'A1+B1+B2 => (A/B)1+B2 -- Not support by this function yet
        'A1+A2+B1+B2 => (A/B)1+(A/B)2  -- Not support by this function yet


        Dim cCharList() As Char
        Dim sVar() As String


        cCharList = New Char() {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"}
        sVar = sClientDesc.Split("+")

        If sVar.Length > 1 Then
            Dim sNum As String
            Dim lNum As Integer
            Dim lPos As Integer
            lPos = sVar(0).LastIndexOfAny(cCharList) + 1
            sNum = sVar(0).Substring(lPos)
            If Integer.TryParse(sNum, lNum) Then
                Dim sCD As String
                sCD = sVar(0).Substring(0, lPos)
                For lI As Integer = 1 To sVar.Length - 1
                    lPos = sVar(lI).LastIndexOfAny(cCharList) + 1
                    If sVar(lI).Substring(lPos).Equals(sNum) Then
                        sCD = sCD & "/" & sVar(lI).Substring(0, lPos)
                    Else
                        sCD = sClientDesc
                        Exit For
                    End If
                Next
                If Not (sCD.Equals(sClientDesc)) Then
                    ConvCTPSampleClientDesc = "(" & sCD & ")" & sNum
                Else
                    ConvCTPSampleClientDesc = sClientDesc
                End If
            Else
                ConvCTPSampleClientDesc = sClientDesc
            End If


        Else
            ConvCTPSampleClientDesc = sClientDesc
        End If
    End Function


    Private Sub cmbProductCode_DropDown(sender As Object, e As EventArgs) Handles cmbProductCode.DropDown
        Dim xmlNode As Xml.XmlNode
        If Not cmbProductCode.Text.Contains("%") And bProductQueried Then
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            If wsSLIM.Endpoint.Address Is Nothing Or Not sInitRes.Equals("0") Then
                wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))

                sInitRes = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
            End If

            If Not sInitRes.Equals("0") Then
                MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
            Else
                xmlNode = wsSLIM.ProductDataFromLIMS(IIf(cmbProductCode.Text.Contains("%"), cmbProductCode.Text, "%"), "PRODUCTCODE,DESCRIPTION", "")
                If cmbProductCode.Text.Contains("%") Then
                    cmbProductCode.Text = ""
                End If
                cmbProductCode.Items.Clear()
                For Each xeProduct As Xml.XmlElement In xmlNode.SelectNodes("/row")
                    cmbProductCode.Items.Add(xeProduct.Item("PRODUCTCODE").InnerXml)
                Next
                bProductQueried = True
            End If
        Catch ex As Exception
        End Try
        Me.Cursor = Me.DefaultCursor
    End Sub


    Private Sub btnCopyLastSam_Click(sender As Object, e As EventArgs) Handles btnCopyLastSam.Click
        Dim lIndex As Integer
        lIndex = ThisAddIn.GetSampleLastIndex("Sample Type", cmbSampleType.Text)
        If lIndex > 0 Then
            txbSGSDesc.Text = xList.Range.Cells(lIndex + 1, xList.ListColumns("SGS Desc").Index).value2
            cmbArticleNo.Text = xList.Range.Cells(lIndex + 1, xList.ListColumns("Article No").Index).value2
            cmbColor.Text = xList.Range.Cells(lIndex + 1, xList.ListColumns("Color").Index).value2
            cmbMaterial.Text = xList.Range.Cells(lIndex + 1, xList.ListColumns("Material").Index).value2
            txbRemark.Text = xList.Range.Cells(lIndex + 1, xList.ListColumns("Remark").Index).value2
            cmbProductCode.Text = xList.Range.Cells(lIndex + 1, xList.ListColumns("Product Code").Index).value2
        End If
    End Sub

    Private Sub lsvSpecCompSample_ColumnClick(sender As Object, e As Windows.Forms.ColumnClickEventArgs) Handles lsvSpecCompSample.ColumnClick
        SortSpecCompSampleList(e.Column)
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If Button1.Text = "<" Then
            Me.LsvSample.Location = New System.Drawing.Point(19, 37)
            Me.LsvSample.Size = New System.Drawing.Size(1123, 440)
            Me.LsvSample.BringToFront()
            Button1.Text = ">"
        Else
            Me.LsvSample.Location = New System.Drawing.Point(742, 37)
            Me.LsvSample.Size = New System.Drawing.Size(400, 231)
            Button1.Text = "<"
        End If
    End Sub

    Private Sub lsvSpecCompSample_MouseHover(sender As Object, e As EventArgs) Handles lsvSpecCompSample.MouseHover
        'If lsvSpecCompSample.Location.X = 742 Then
        '    Me.lsvSpecCompSample.Location = New System.Drawing.Point(12, 18)
        '    Me.lsvSpecCompSample.Size = New System.Drawing.Size(1130, 459)
        '    Me.lsvSpecCompSample.BringToFront()
        'End If

    End Sub

    Private Sub lsvSpecCompSample_MouseLeave(sender As Object, e As EventArgs) Handles lsvSpecCompSample.MouseLeave
        'If lsvSpecCompSample.Location.X = 12 Then

        '    Me.lsvSpecCompSample.Location = New System.Drawing.Point(742, 300)
        '    Me.lsvSpecCompSample.Size = New System.Drawing.Size(400, 177)
        'End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Button2.Text = "<" Then
            Me.lsvSpecCompSample.Location = New System.Drawing.Point(12, 18)
            Me.lsvSpecCompSample.Size = New System.Drawing.Size(1130, 459)
            Me.lsvSpecCompSample.BringToFront()
            Button2.Text = ">"
        Else
            Me.lsvSpecCompSample.Location = New System.Drawing.Point(742, 300)
            Me.lsvSpecCompSample.Size = New System.Drawing.Size(400, 177)
            Button2.Text = "<"
        End If
    End Sub

    Private Sub highlightSampleFields()
        Dim sFields As String = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_SampleFieldHighlight").Value()
        sFields = C(sFields.ToUpper)

        'SampleType()
        If sFields.Contains(C("SampleType".ToUpper)) Then
            cmbSampleType.BackColor = System.Drawing.Color.LightPink
        End If
        'SGSDescription()
        If sFields.Contains(C("SGSDescription".ToUpper)) Then
            txbSGSDesc.BackColor = System.Drawing.Color.LightPink
        End If
        'ArticleNo()
        If sFields.Contains(C("ArticleNo".ToUpper)) Then
            cmbArticleNo.BackColor = System.Drawing.Color.LightPink
        End If
        'Material()
        If sFields.Contains(C("Material".ToUpper)) Then
            cmbMaterial.BackColor = System.Drawing.Color.LightPink
        End If
        'ProductCode()
        If sFields.Contains(C("ProductCode".ToUpper)) Then
            cmbProductCode.BackColor = System.Drawing.Color.LightPink
        End If
        'SampleID()
        If sFields.Contains(C("SampleID".ToUpper)) Then
            txbID.BackColor = System.Drawing.Color.LightPink
        End If
        'Color()
        If sFields.Contains(C("Color".ToUpper)) Then
            cmbColor.BackColor = System.Drawing.Color.LightPink
        End If
        'ClientDescription()
        If sFields.Contains(C("ClientDescription".ToUpper)) Then
            txbClientDesc.BackColor = System.Drawing.Color.LightPink
        End If
        'Remark()
        If sFields.Contains(C("Remark".ToUpper)) Then
            txbRemark.BackColor = System.Drawing.Color.LightPink
        End If
        'LinkedID()
        'SpecimenCompositeSample()
    End Sub
    Private Sub highlightSampleBioFieldFields()
        'Will be obsoleted to support within ucBiofield
        Dim sFields As String = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_SampleBioFieldFieldHighlight").Value()
        sFields = C(sFields.ToUpper)

        If sFields.Contains(C(ubfCode1.lblFieldName.Text.ToUpper)) Then
            ubfCode1.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode1.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode1.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode2.lblFieldName.Text.ToUpper)) Then
            ubfCode2.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode2.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode2.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode3.lblFieldName.Text.ToUpper)) Then
            ubfCode3.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode3.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode3.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode4.lblFieldName.Text.ToUpper)) Then
            ubfCode4.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode4.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode4.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode5.lblFieldName.Text.ToUpper)) Then
            ubfCode5.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode5.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode5.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If

        If sFields.Contains(C(ubfCode6.lblFieldName.Text.ToUpper)) Then
            ubfCode6.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode6.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode6.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode7.lblFieldName.Text.ToUpper)) Then
            ubfCode7.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode7.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode7.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode8.lblFieldName.Text.ToUpper)) Then
            ubfCode8.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode8.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode8.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode9.lblFieldName.Text.ToUpper)) Then
            ubfCode9.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode9.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode9.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode10.lblFieldName.Text.ToUpper)) Then
            ubfCode10.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode10.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode10.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode11.lblFieldName.Text.ToUpper)) Then
            ubfCode11.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode11.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode11.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode12.lblFieldName.Text.ToUpper)) Then
            ubfCode12.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode12.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode12.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode13.lblFieldName.Text.ToUpper)) Then
            ubfCode13.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode13.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode13.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode14.lblFieldName.Text.ToUpper)) Then
            ubfCode14.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode14.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode14.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode15.lblFieldName.Text.ToUpper)) Then
            ubfCode15.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode15.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode15.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode16.lblFieldName.Text.ToUpper)) Then
            ubfCode16.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode16.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode16.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode17.lblFieldName.Text.ToUpper)) Then
            ubfCode17.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode17.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode17.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode18.lblFieldName.Text.ToUpper)) Then
            ubfCode18.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode18.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode18.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode19.lblFieldName.Text.ToUpper)) Then
            ubfCode19.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode19.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode19.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
        If sFields.Contains(C(ubfCode20.lblFieldName.Text.ToUpper)) Then
            ubfCode20.txtFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode20.cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            ubfCode20.dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        End If
    End Sub
    Private Function C(sValue As String) As String
        C = "," & sValue & ","
    End Function

    Private Sub cmbColor_DropDown(sender As Object, e As EventArgs) Handles cmbColor.DropDown
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        ThisAddIn.fetchUserData(wsSLIM, "DESCRIPTION_6")
        RefreshDropDownFrUserData(cmbColor, "DESCRIPTION_6")
        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub cmbArticleNo_DropDown(sender As Object, e As EventArgs) Handles cmbArticleNo.DropDown
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        ThisAddIn.fetchUserData(wsSLIM, "DESCRIPTION_3")
        RefreshDropDownFrUserData(cmbArticleNo, "DESCRIPTION_3")
        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub cmbMaterial_DropDown(sender As Object, e As EventArgs) Handles cmbMaterial.DropDown
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        ThisAddIn.fetchUserData(wsSLIM, "DESCRIPTION_5")
        RefreshDropDownFrUserData(cmbMaterial, "DESCRIPTION_5")
        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub ubfCode1_Load(sender As Object, e As EventArgs) Handles ubfCode1.Load

    End Sub
End Class
