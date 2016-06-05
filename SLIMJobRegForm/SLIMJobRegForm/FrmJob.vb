Public Class frmJob
    Const BIOFIELDCOUNT As Integer = 20
    Private lsBiofield As List(Of Biofield)
    'Private lsBioFieldControl As List(Of ucBiofield)
    Private xSheet As Excel.Worksheet
    Private xList As Excel.ListObject
    Private xlistBF As Excel.ListObject

    Private sCurrClient As String
    Private sCurrClientCont As String
    Private lsClient As List(Of CCLAS.Client)
    'Private lsClientContact As List(Of String)

    Private cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)
    Private wsSLIM As New CCLAS.CCLASXMLServiceSoapClient
    Private sInitRes As String = ""

    Private bProductQueried As Boolean = False
    Public bNew As Boolean

    'Private Property ucBiofield As Object


    Private Sub DataGridView1_CellClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs)
        If e.ColumnIndex = 2 Then
            MsgBox("Here is column 2")
        End If
        'http://stackoverflow.com/questions/7412398/how-to-remove-objects-from-listof-myclass-by-object-value
        'Persons.Add(New Person With {.Name = "Jamie", .Age = 99})
        'Persons.RemoveAll(Function(person) person.Name = "Jamie")
        'Persons.Remove(Persons.Single(Function(person) person.Name = "Jamie"))

    End Sub

    Private Sub frmJob_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub frmJob_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim lI As Integer

        'Lock the Excel **********************************

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.JOBSHEET, False)
        If IsNothing(xSheet) Then
            MsgBox("Error - Not SLIM Job Reg Workbook")
            Me.Close()
            Exit Sub
        Else
            xList = ThisAddIn.getList(xSheet, ThisAddIn.JOBLIST, False)
            xlistBF = ThisAddIn.getList(xSheet, ThisAddIn.JOBLISTBF, False)
            If IsNothing(xList) Or IsNothing(xlistBF) Then
                MsgBox("Error - Not SLIM Job Reg Workbook")
                Me.Close()
                Exit Sub
            End If
        End If

        Dim oBiofield(xlistBF.ListRows.Count - 1) As Biofield
        For lI As Integer = 0 To xlistBF.ListRows.Count - 1
            oBiofield(lI) = New Biofield With {
                .Biofield = xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Biofield").Index).Value2, _
                .BioValue = xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Value").Index).Value2, _
                .ReportActive = Convert.ToInt32(xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Report Active").Index).Value2) _
            }
        Next
        lsBiofield = oBiofield.ToList

        If lsBiofield.Count = 0 Then
            sbBiofield.Maximum = 0
        Else
            sbBiofield.Maximum = (Math.Ceiling(lsBiofield.Count / BIOFIELDCOUNT)) - 1
        End If
        RefreshBiofield()

        sCurrClient = xList.Range.Cells(2, xList.ListColumns("Client").Index).Value2
        cmbClient.Text = sCurrClient
        lblClientName.Text = ""
        lblClientContactName.Text = ""
        sCurrClientCont = xList.Range.Cells(2, xList.ListColumns("Client Contact").Index).Value2
        cmbClientContact.Text = sCurrClientCont
        cmbProject.Text = xList.Range.Cells(2, xList.ListColumns("Project").Index).Value2
        txbOrder.Text = xList.Range.Cells(2, xList.ListColumns("Order").Index).Value2
        txbClientOrder.Text = xList.Range.Cells(2, xList.ListColumns("Client Order").Index).Value2
        cmbProductCode.Text = xList.Range.Cells(2, xList.ListColumns("Product Code").Index).Value2
        txbReportTemplate.Text = xList.Range.Cells(2, xList.ListColumns("Report Template").Index).Value2
        dtpRequired.Text = xList.Range.Cells(2, xList.ListColumns("Required Date").Index).Value2
        If cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_CostCode").Value.Trim.Length > 0 Then
            Dim sCC() As String = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_CostCode").Value.Split(",")
            cmbCostCode.Items.Clear()
            For lI As Integer = 0 To sCC.Length - 1
                cmbCostCode.Items.Add(sCC(lI))
            Next
        End If
        cmbCostCode.Text = xList.Range.Cells(2, xList.ListColumns("Cost Code").Index).Value2

    End Sub

    Public Sub RefreshBiofield(Optional lPage As Integer = 0)
        If lPage < 0 Then
            Exit Sub
        End If
        Dim lThisPageItemNo As Integer
        lThisPageItemNo = lsBiofield.Count - lPage * BIOFIELDCOUNT
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

    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click
        Dim xListRow As Excel.ListRow
        Dim lRowCnt As Integer

        Globals.ThisAddIn.Application.ScreenUpdating = False
        Try


            If bNew Then
                'xListRow = xList.ListRows.AddEx
                'With xListRow.Range
                '    .Cells(1, 1) = cmbClient.Text

                'End With

                'For lI As Integer = 1 To UBound(oBiofield)
                '    xListRow = xlistBF.ListRows.AddEx
                '    With xListRow.Range
                '        .Cells(1, 1) = oBiofield(lI).Biofield
                '        .Cells(1, 2) = oBiofield(lI).BioValue
                '    End With
                'Next
            Else
                'Modify existing row
                xList.Range.Cells(2, xList.ListColumns("Client").Index) = cmbClient.Text
                xList.Range.Cells(2, xList.ListColumns("Client Contact").Index) = cmbClientContact.Text
                xList.Range.Cells(2, xList.ListColumns("Project").Index) = cmbProject.Text
                xList.Range.Cells(2, xList.ListColumns("Order").Index) = txbOrder.Text
                xList.Range.Cells(2, xList.ListColumns("Client Order").Index) = txbClientOrder.Text
                xList.Range.Cells(2, xList.ListColumns("Product Code").Index) = cmbProductCode.Text
                xList.Range.Cells(2, xList.ListColumns("Report Template").Index) = txbReportTemplate.Text
                xList.Range.Cells(2, xList.ListColumns("Cost Code").Index) = cmbCostCode.Text
                xList.Range.Cells(2, xList.ListColumns("Required Date").Index) = dtpRequired.Text

            End If

            'Row count except header 
            lRowCnt = xlistBF.ListRows.Count
            If lRowCnt < lsBiofield.Count Then
                'Update + Add New Row
                For lI As Integer = 0 To lRowCnt - 1
                    'Update Row
                    'If lsBiofield(lI).Biofield <> xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Biofield").Index).Value2.ToString Then
                    xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                    'End If
                    'If lsBiofield(lI).BioValue <> xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Value").Index).Value2.ToString Then
                    xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                    'End If
                    'If lsBiofield(lI).ReportActive <> xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Report Active").Index).Value2.ToString Then
                    xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                    'End If
                Next
                For lI As Integer = lRowCnt To lsBiofield.Count - 1
                    'Add New Row
                    xListRow = xlistBF.ListRows.AddEx
                    xListRow.Range.Cells(1, xlistBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                    xListRow.Range.Cells(1, xlistBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                    xListRow.Range.Cells(1, xlistBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                Next
            Else
                'Update + Delete Row
                If lRowCnt = lsBiofield.Count Then
                Else
                    For lI As Integer = lRowCnt To lsBiofield.Count + 1 Step -1
                        xlistBF.ListRows(lI).Delete()
                    Next
                End If

                If lsBiofield.Count > 0 Then
                    For lI As Integer = 0 To lsBiofield.Count - 1
                        'Update Row
                        'If lsBiofield(lI).Biofield <> xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Biofield").Index).Value2 Then
                        xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Biofield").Index) = lsBiofield(lI).Biofield
                        'End If
                        'If lsBiofield(lI).BioValue <> xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Value").Index).Value2 Then
                        xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Value").Index) = lsBiofield(lI).BioValue
                        'End If
                        'If lsBiofield(lI).ReportActive <> xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Report Active").Index).Value2 Then
                        xlistBF.Range.Cells(lI + 2, xlistBF.ListColumns("Report Active").Index) = lsBiofield(lI).ReportActive
                        'End If
                    Next
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        Globals.ThisAddIn.Application.ScreenUpdating = True
        Me.Close()
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

    Private Sub UpdateBioFieldReportActive(lBiofieldItemNo As Integer, bChecked As Boolean)
        lsBiofield(lBiofieldItemNo).IsActive = bChecked
    End Sub
    Private Sub UpdateBioFieldValue(lBiofieldItemNo As Integer, sFieldValue As String)
        lsBiofield(lBiofieldItemNo).BioValue = sFieldValue
    End Sub

    Private Sub sbBiofield_ValueChanged(sender As Object, e As EventArgs) Handles sbBiofield.ValueChanged
        RefreshBiofield(sbBiofield.Value)
    End Sub

    Private Sub btnAddBF_Click(sender As Object, e As EventArgs) Handles btnAddBF.Click
        Dim oBF As Biofield
        Dim aBF() As String
        aBF = GetNewBiofield().Split(",")
        If aBF(0).Length > 0 Then
            For lI As Integer = 0 To aBF.Count - 1
                oBF = New Biofield(aBF(lI))
                lsBiofield.Add(oBF)
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
            GetNewBiofield = "ECV.apptrVersNo,ECV.apptrVersDate,ECV.apptrIBuyerName,ECV.apptrNo,ECV.apptrName,ECV.apptrTestCompanyName,ECV.apptrTestComBranchCountry,ECV.apptrTestComBranchCity,ECV.apptrTestComBranchAddress,ECV.apptrTestComBranchTel,ECV.apptrTestComBranchCode,ECV.apptrType,ECV.apptrRetest,ECV.apptrReTestCount,ECV.apptrPONo,ECV.apptrPreviousTestReportNo,ECV.apptrPreRslReportNo,ECV.apptrMasterTrNo,ECV.apptrVendorBrandRemark,ECV.apptrServiceRequired,ECV.apptrRequestDate,ECV.apptrApplicantCode,ECV.apptrApplicantName,ECV.apptrApplicantAddress,ECV.apptrApplicantTel,ECV.apptrApplicantFax,ECV.apptrApplicantEmail,ECV.apptrApplicantContactPerson,ECV.apptrApplicantCodeOnRpt,ECV.apptrReportApplicantName,ECV.apptrApplicantReportAddress,ECV.apptrApplicantReportTel,ECV.apptrApplicantReportFax,ECV.apptrApplicantRptEmail,ECV.apptrApplicantReportContactPerson,ECV.apptrBillToName,ECV.apptrBillToAddress,ECV.apptrBillToTel,ECV.apptrBillToFax,ECV.apptrBillToEmail,ECV.apptrBillToContactPerson,ECV.apptrTestCompanyLogin,ECV.apptrItemNo,ECV.apptrItemName,ECV.apptrItemLineType,ECV.apptrItemCtyOrigin,ECV.apptrItemExportTo,ECV.apptrAddItemEndUse,ECV.apptrItemAgeGrading,ECV.apptrItemArticleNo,ECV.apptrItemSKUNo,ECV.apptrItemUPCNo,ECV.apptrItemSeason,ECV.apptrSupplierCode,ECV.apptrSupplierName,ECV.apptrSupplierCtyOrigin,ECV.apptrSupplierAddress,ECV.apptrSupplierTel,ECV.apptrSupplierFax,ECV.apptrSupplierEmail,ECV.apptrSupplierContactPerson,ECV.apptrSupplierIDExternal,ECV.apptrStatus,ECV.apptrProductCategory,ECV.apptrProductGroup,ECV.apptrProductType,ECV.apptrProductSubtype,ECV.apptrMaterialType,ECV.apptrMaterialSubtype,ECV.apptrTestStage,ECV.apptrReportHardcopy,ECV.apptrShipDate,ECV.apptrPreviousTestRequestNo,ECV.apptrBrandEmail,ECV.apptrBrandContactPerson,ECV.apptrVendorName,ECV.apptrFinishingMillName,ECV.apptrFinishingDescription,ECV.apptrItemTypeFromInfo,ECV.apptrCareInstrnComments,ECV.apptrWash,ECV.apptrBleach,ECV.apptrDry,ECV.apptrIron,ECV.apptrDryClean,ECV.apptrEstTestSampleSubDate,ECV.apptrbrandSourcingOffice,ECV.apptrSurfaceFinish,ECV.appvftrFinishDesc,ECV.apptrOtherFinishiDesc,ECV.apptrFuncClaim,ECV.apptrDyePrint,ECV.apptrCurrency,ECV.apptrCCEmailReport,ECV.apptrFactoryName,ECV.apptrSampleSubmitted,ECV.apptrFabricConstruct,ECV.apptrReqSpecificNo,ECV.apptrWeight,ECV.apptrCareInstrnPkg,ECV.apptrSubQty,ECV.apptrApplicantEmail1,ECV.apptrApplicantEmail2,ECV.apptrApplicantEmail3,ECV.apptrCuttableWidth,ECV.apptrLabRefNo,ECV.apptrReturnSample,ECV.apptrSupplierArticleNo,ECV.apptrThreadCount,ECV.apptrTrimSize,ECV.apptrYarnSpecification,ECV.apptrbrandRegion,ECV.apptrItemBrandName"
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
    Private Sub cmbClient_DropDown(sender As Object, e As EventArgs) Handles cmbClient.DropDown
        'Service References version (Change to global)
        'Dim wsSLIM As New CCLAS.CCLASXMLServiceSoapClient

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'Web Reference version
        'Dim wsSLIM As New SLIMJobRegForm.CCLAS.CCLASXMLService
        'Dim cc As System.Net.CookieContainer = New System.Net.CookieContainer
        'wsSLIM.CookieContainer = cc

        Dim xmlNode As Xml.XmlNode
        'wsSLIM.Endpoint.Address =""

        If cmbClient.Text.Trim("%").Length < 3 Then
            'Not search if not over 3 character exclude leading or trailing %, following is valid
            'e.g. ABC
            '     ABC%
            '     %ABC%
            '     A%C
            MsgBox("Please input client name with 3 character or more (support % as wild card) for quick search.")
        ElseIf IsClientListed() Then
        Else

            Try
                If wsSLIM.Endpoint.Address Is Nothing Or Not sInitRes.Equals("0") Then
                    wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))
                    sInitRes = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
                End If

                If Not sInitRes.Equals("0") Then
                    MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
                Else
                    'xmlNode = wsSLIM.ClientDataFromLIMS("BOSS_NO_ORDER", "CLI_CODE,CLI_NAME", "CLI_CODE like '" & cmbClient.Text & "'")
                    'xmlNode = wsSLIM.ClientDataFromLIMS("BOSS_NO_ORDER", "", "")
                    'The following will not return client contact
                    'xmlNode = wsSLIM.ClientDataFromLIMS("%", "LABCODE,CLI_CODE,CLI_NAME", "CLI_CODE like '" & cmbClient.Text & "' or CLI_NAME like '" & cmbClient.Text & "'")
                    'xmlNode = wsSLIM.ClientDataFromLIMS("%", "LABCODE,CLI_CODE,CLI_NAME", "CLI_NAME like '" & cmbClient.Text & "'")
                    xmlNode = wsSLIM.ClientDataFromLIMS(cmbClient.Text, "LABCODE,CLI_CODE,CLI_NAME", "")
                    If xmlNode Is Nothing Then
                        MsgBox("Error")
                    ElseIf xmlNode.OuterXml.Trim.Length = 0 Or xmlNode.OuterXml.Equals("<CLIENT xmlns=""""></CLIENT>") Then
                        MsgBox("No client name matched. Please input name with 3 character or more (support % as wild card).")
                    Else

                        'select CLIENT/Row/LABCODE AND CLI_CODE and CLI_NAME
                        'select CLIENT/Client_Contact/Row/CLI_CODE and CONT_CODE and CONT_NAME
                        'Fill up Client list and Client-Contact list
                        cmbClient.Text = ""
                        cmbClientContact.Text = ""
                        lsClient = New List(Of CCLAS.Client)
                        For Each xeClient As Xml.XmlElement In xmlNode.SelectNodes("/row")
                            'MsgBox(xeClient.Item("CLI_NAME").InnerXml)
                            lsClient.Add(New CCLAS.Client With {.Accnt_Code = xeClient.Item("LABCODE").InnerXml, _
                                                                .CliCode = xeClient.Item("CLI_CODE").InnerXml, _
                                                                .Cli_Name = xeClient.Item("CLI_NAME").InnerXml})
                        Next

                        For Each xeClientContact As Xml.XmlElement In xmlNode.SelectNodes("/CLIENT_CONTACT/row")
                            'MsgBox(xeClient.Item("CLI_NAME").InnerXml)
                            For lI As Integer = 0 To lsClient.Count - 1
                                If lsClient(lI).Accnt_Code = xeClientContact.Item("LABCODE").InnerXml And _
                                    lsClient(lI).CliCode = xeClientContact.Item("CLI_CODE").InnerXml Then
                                    If lsClient(lI).ClientContacts Is Nothing Then
                                        ReDim lsClient(lI).ClientContacts(0)
                                    Else
                                        ReDim Preserve lsClient(lI).ClientContacts(lsClient(lI).ClientContacts.Count)
                                    End If
                                    lsClient(lI).ClientContacts(lsClient(lI).ClientContacts.Count - 1) = New CCLAS.ClientContact With {.ContID = xeClientContact.Item("CONT_CODE").InnerXml, _
                                                                                                                                                      .Cont_Name = xeClientContact.Item("CONT_NAME").InnerXml}
                                End If
                            Next
                        Next
                        cmbClient.Items.Clear()
                        'cmbClient.Items.Add("Previous ID")

                        For lI As Integer = 0 To lsClient.Count - 1
                            cmbClient.Items.Add(lsClient.Item(lI).CliCode)
                        Next
                        'Set cmbClient and cmbClientContact default the 1st item
                        'MsgBox(xmlNode.OuterXml)
                        lblClientContactName.Text = ""
                        lblClientName.Text = ""

                    End If
                End If
            Catch ex As Exception
                'initialise or other method timeout for network

            End Try

        End If
        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub btnSearchClient_Click(sender As Object, e As EventArgs) Handles btnSearchClient.Click

        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        'If cmbClient.Text.Trim.Length = 0 Or cmbClient.Text.Trim.Equals("BOSS_NO_ORDER") Then
        'Advance search 
        Dim frmCS As New FrmClientSearch
        frmCS.ShowDialog()
        lsClient = frmCS.lsClient
        If lsClient.Count > 0 Then

            cmbClient.Items.Clear()
            For lI As Integer = 0 To lsClient.Count - 1
                cmbClient.Items.Add(lsClient.Item(lI).CliCode)
            Next
            cmbClient.SelectedIndex = 0
        End If
        'End If
        Me.Cursor = Me.DefaultCursor

    End Sub

   

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        cmbClientContact.Text = ""
        For lI As Integer = 0 To lsClient.Count - 1
            If lsClient.Item(lI).CliCode = cmbClient.Text Then
                lblClientName.Text = lsClient.Item(lI).Cli_Name
                cmbClientContact.Items.Clear()
                If lsClient.Item(lI).ClientContacts IsNot Nothing Then
                    If lsClient.Item(lI).ClientContacts.Count > 0 Then
                        For lJ As Integer = 0 To lsClient.Item(lI).ClientContacts.Count - 1
                            cmbClientContact.Items.Add(lsClient.Item(lI).ClientContacts(lJ).ContID)
                        Next
                        cmbClientContact.SelectedIndex = 0
                        Exit For
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub cmbClientContact_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClientContact.SelectedIndexChanged
        For lI As Integer = 0 To lsClient.Count - 1
            If lsClient.Item(lI).CliCode = cmbClient.Text Then
                For lJ As Integer = 0 To lsClient.Item(lI).ClientContacts.Count - 1
                    If lsClient.Item(lI).ClientContacts(lJ).ContID = cmbClientContact.Text Then
                        lblClientContactName.Text = lsClient.Item(lI).ClientContacts(lJ).Cont_Name
                    End If
                Next
            End If
        Next
    End Sub

    Private Sub cmbProductCode_DropDown(sender As Object, e As EventArgs) Handles cmbProductCode.DropDown
        Dim xmlNode As Xml.XmlNode
        If Not cmbProductCode.Text.Contains("%") And bProductQueried Then
            Exit Sub
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            If wsSLIM.Endpoint.Address Is Nothing Or Not sInitRes.Equals("0") Then
                'wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri("http://10.205.7.226/SLIM/ccxml01/CCXML01.asmx"))
                wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))

                sInitRes = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
            End If

            If Not sInitRes.Equals("0") Then
                MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
            Else
                'xmlNode = wsSLIM.ProductDataFromLIMS("%", "PRODUCTCODE,DESCRIPTION", "")
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
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Private Function IsClientListed() As Boolean
        If cmbClient.Items.Count = 0 Then
            Return False
        Else
            For lI As Integer = 0 To cmbClient.Items.Count - 1
                If cmbClient.Text = cmbClient.Items(lI) Then
                    Return True
                End If
            Next
        End If
        Return False

    End Function

    Private Sub cmbClient_TextChanged(sender As Object, e As EventArgs) Handles cmbClient.TextChanged
        lblClientName.Text = ""
        cmbClientContact.Text = ""
        lblClientContactName.Text = ""
    End Sub

    Private Sub cmbClientContact_TextChanged(sender As Object, e As EventArgs) Handles cmbClientContact.TextChanged
        lblClientContactName.Text = ""
    End Sub

    Private Sub cmbProductCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductCode.SelectedIndexChanged

    End Sub
End Class


