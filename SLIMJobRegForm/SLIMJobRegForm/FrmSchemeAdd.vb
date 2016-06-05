Public Class frmSchemeAdd
    Private xSheetSam As Excel.Worksheet
    Private xSheetSch As Excel.Worksheet
    Private xSheetRef As Excel.Worksheet
    Private xListSam As Excel.ListObject
    Private xListSch As Excel.ListObject
    Private xListRef As Excel.ListObject

    'Private lsScheme As List(Of String)
    Private lsSchemeList As List(Of SLIMObj.Scheme)
    Private lsSchemeListOld As List(Of SLIMObj.Scheme)
    Private cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)

    Private sOrigSam As String = ""
    Private bShowProcCode As Boolean = False

    Private Sub frmSchemeAdd_FormClosed(sender As Object, e As Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If xListRef IsNot Nothing Then
            If lsSchemeList.Count > 0 Then
                Dim bSU As Boolean = Globals.ThisAddIn.Application.ScreenUpdating
                Globals.ThisAddIn.Application.ScreenUpdating = False
                'Delete all Scheme entry in Ref Sheet
                'Add Scheme into Ref Sheet
                If lsSchemeList.Count > lsSchemeListOld.Count Then
                    'Update and Add from List Top
                    'Update 
                    For lI As Integer = 0 To lsSchemeListOld.Count - 1
                        If lsSchemeList(lI).ProcedureCode.Trim <> "" Then
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_ProCode) = lsSchemeList(lI).ProcedureCode
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_ProDesc) = lsSchemeList(lI).ProcedureDesc
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchCode) = lsSchemeList(lI).SchemeCode
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchDesc) = lsSchemeList(lI).SchemeDesc
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchMethod) = lsSchemeList(lI).SchemeMethod
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchName) = lsSchemeList(lI).SchemeName
                        End If
                    Next
                    'Add
                    For lI As Integer = lsSchemeListOld.Count To lsSchemeList.Count - 1
                        Dim xNewRow = xListRef.ListRows.AddEx
                        xNewRow.Range.Cells(1, ThisAddIn.REFKEY) = ThisAddIn.REFSch
                        xNewRow.Range.Cells(1, ThisAddIn.REFSch_ProCode) = lsSchemeList(lI).ProcedureCode
                        xNewRow.Range.Cells(1, ThisAddIn.REFSch_ProDesc) = lsSchemeList(lI).ProcedureDesc
                        xNewRow.Range.Cells(1, ThisAddIn.REFSch_SchCode) = lsSchemeList(lI).SchemeCode
                        xNewRow.Range.Cells(1, ThisAddIn.REFSch_SchDesc) = lsSchemeList(lI).SchemeDesc
                        xNewRow.Range.Cells(1, ThisAddIn.REFSch_SchMethod) = lsSchemeList(lI).SchemeMethod
                        xNewRow.Range.Cells(1, ThisAddIn.REFSch_SchName) = lsSchemeList(lI).SchemeName
                    Next
                Else
                    'Delete and Update from List bottom
                    If lsSchemeListOld.Count = lsSchemeList.Count Then
                    Else
                        For lI As Integer = lsSchemeListOld.Count To lsSchemeList.Count + 1 Step -1
                            xListRef.ListRows(lsSchemeListOld(lI - 1).ListRowNo).Delete()
                        Next
                    End If
                    If lsSchemeList.Count > 0 Then
                        For lI As Integer = 0 To lsSchemeList.Count - 1
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_ProCode) = lsSchemeList(lI).ProcedureCode
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_ProDesc) = lsSchemeList(lI).ProcedureDesc
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchCode) = lsSchemeList(lI).SchemeCode
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchDesc) = lsSchemeList(lI).SchemeDesc
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchMethod) = lsSchemeList(lI).SchemeMethod
                            xListRef.Range.Cells(lsSchemeListOld(lI).ListRowNo + 1, ThisAddIn.REFSch_SchName) = lsSchemeList(lI).SchemeName

                        Next
                    End If
                End If
                Globals.ThisAddIn.Application.ScreenUpdating = bSU
            End If
            'Delete Original Scheme
        End If

    End Sub

    Private Sub frmSchemeAdd_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Dim result As DialogResult = MessageBox.Show("Close Form?", "Yeehaw!", MessageBoxButtons.YesNo)
        'If result = Windows.Forms.DialogResult.No Then
        '    e.Cancel = True
        'End If

    End Sub



    Private Sub frmSchemeAdd_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        xSheetSam = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If xSheetSam IsNot Nothing Then
            xListSam = ThisAddIn.getList(xSheetSam, ThisAddIn.SAMLIST, False)
            If xListSam Is Nothing Then
                MsgBox("Error - Worksheet Sample is invalid!")
                Me.Close()
                Exit Sub
            End If
        Else
            MsgBox("Error - Worksheet Sample is not found!")
            Me.Close()
            Exit Sub
        End If

        xSheetSch = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SCHSHEET, False)
        If xSheetSch IsNot Nothing Then
            xListSch = ThisAddIn.getList(xSheetSch, ThisAddIn.SCHLIST, False)
            If xListSch Is Nothing Then
                MsgBox("Error - Worksheet Scheme is invalid!")
                Me.Close()
                Exit Sub
            End If
        Else
            MsgBox("Error - Worksheet Scheme is not found!")
            Me.Close()
            Exit Sub
        End If


        xSheetRef = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.REFSHEET, True)
        If xSheetRef IsNot Nothing Then
            xListRef = ThisAddIn.getList(xSheetRef, ThisAddIn.REFLIST, True)
            If xListSch Is Nothing Then
                MsgBox("Error - Worksheet Ref is invalid!")
                'Me.Close()
                'Exit Sub
            End If
        Else
            MsgBox("Error - Worksheet Ref is not found!")

            'Me.Close()
            'Exit Sub
        End If

        RefreshSample()

        ' Load TreeView for Procedure Scheme
        'lsScheme = New List(Of String)
        lsSchemeList = New List(Of SLIMObj.Scheme)

        'Load scheme from Ref sheet first
        For lI As Integer = 1 To xListRef.ListRows.Count
            If Not xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFKEY).Index).Value2.ToString.Trim.Equals(ThisAddIn.REFSch) Then
            ElseIf xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_ProCode).Index).Value2.ToString.Trim = "" Then
            Else
                lsSchemeList.Add(New SLIMObj.Scheme With {.ListRowNo = lI, .ProcedureCode = xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_ProCode).Index).Value2.ToString, _
                                                        .SchemeCode = xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_SchCode).Index).Value2, _
                                                        .SchemeMethod = xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_SchMethod).Index).Value2, _
                                                        .SchemeDesc = xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_SchDesc).Index).Value2, _
                                                         .ProcedureDesc = xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_ProDesc).Index).Value2, _
                                                          .SchemeName = xListRef.Range.Cells(lI + 1, xListRef.ListColumns(ThisAddIn.REFSch_SchName).Index).Value2})
            End If
        Next

        lsSchemeListOld = lsSchemeList.ToList

        Dim bUnmappedScheme As Boolean = False
        For lI As Integer = xListSch.ListRows.Count To 1 Step -1
            Dim bThisUnmapped As Boolean = True
            If xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Procedure").Index).Value2 Is Nothing Then
                xListSch.ListRows(lI).Delete()
            ElseIf xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Procedure").Index).Value2.ToString.Trim = "" Then
                xListSch.ListRows(lI).Delete()
            ElseIf xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Sample ID").Index).Value2.ToString.Trim = "" Then
                xListSch.ListRows(lI).Delete()
            Else
                If lsSchemeList.Count > 0 Then
                    'Match with Ref Sheet, add if no match
                    For lJ As Integer = 0 To lsSchemeList.Count - 1
                        If lsSchemeList(lJ).ProcedureCode = xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Procedure").Index).Value2.ToString.Trim Then
                            If Not xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Scheme").Index).Value2 Is Nothing Then
                                If lsSchemeList(lJ).SchemeCode = xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Scheme").Index).Value2.ToString.Trim Then
                                    bThisUnmapped = False
                                    Exit For
                                End If
                            Else
                                bThisUnmapped = False
                                Exit For
                            End If
                        End If
                    Next
                End If
                If bThisUnmapped Then
                    'No match 
                    If Not bUnmappedScheme Then
                        bUnmappedScheme = True
                    End If
                    lsSchemeList.Add(New SLIMObj.Scheme With {.ProcedureCode = xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Procedure").Index).Value2.ToString, _
                                                    .SchemeCode = xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Scheme").Index).Value2, _
                                                    .SchemeMethod = "", _
                                                    .SchemeDesc = "", _
                                                    .ProcedureDesc = "", _
                                                    .SchemeName = ""})
                End If
                'Delete if scheme for Original type Sample
                If sOrigSam.Length > 0 Then
                    If sOrigSam.Contains(",S,".Replace("S", xListSch.Range.Cells(lI + 1, xListSch.ListColumns("Sample ID").Index).Value2.ToString.Trim)) Then
                        xListSch.ListRows(lI).Delete()
                    End If
                End If
            End If
        Next
        If bUnmappedScheme Then
            MapSchemeByWebService()
        Else
            RefreshScheme()
        End If


    End Sub
    Private Sub RefreshSample()
        Dim lsSample As New List(Of Windows.Forms.ListViewItem)

        sOrigSam = ""
        For lI As Integer = 1 To xListSam.ListRows.Count
            If xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Sample Type").Index).Value2 <> "Original" Then
                Dim sSamID As String = xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Sample ID").Index).Value2
                lsSample.Add(New Windows.Forms.ListViewItem(New String() {sSamID, _
                                                                              xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Sample Type").Index).Value2, _
                                                                              xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Client Desc").Index).Value2, _
                                                                              xListSam.Range.Cells(lI + 1, xListSam.ListColumns("SGS Desc").Index).Value2, _
                                                                            xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Color").Index).Value2, _
                                                                          ThisAddIn.GetSampleBFValue(sSamID, "FIBER COMPOSITION"), _
                                                                          xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Material").Index).Value2, _
                                                                          xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Remark").Index).Value2, _
                                                                          xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Article No").Index).Value2}))

            Else
                'Original sample
                sOrigSam = sOrigSam & "," & xListSam.Range.Cells(lI + 1, xListSam.ListColumns("Sample ID").Index).Value2.ToString.Trim
            End If
        Next
        If sOrigSam.Trim.Trim(",").Trim.Length > 0 Then
            sOrigSam = sOrigSam & ","
        End If

        lvSample.Items.Clear()
        lvSample.Items.AddRange(lsSample.ToArray)
    End Sub
    Private Sub RefreshScheme()
        TrvScheme.Nodes.Clear()
        Dim sProc As String = ""
        'lsScheme = lsScheme.Distinct().ToList
        'lsScheme.Sort()

        DistinctProcedureScheme(lsSchemeList)
        lsSchemeList.Sort(Function(x, y) x.PROCEDURECODE.ToString.CompareTo(y.PROCEDURECODE.ToString))

        For lI As Integer = 0 To lsSchemeList.Count - 1
            Dim trNode As Windows.Forms.TreeNode
            'If 1st Procedure or another new Procedure
            If sProc = "" Or sProc <> lsSchemeList(lI).ProcedureCode.Trim Then

                If lsSchemeList(lI).ProcedureCode.Trim.Length > 0 Then
                    'trNode = TrvScheme.Nodes.Add(lsSchemeList(lI).ProcedureCode.Trim)
                    If bShowProcCode Then
                        trNode = TrvScheme.Nodes.Add(lsSchemeList(lI).ProcedureCode.Trim)
                        trNode.ToolTipText = lsSchemeList(lI).ProcedureDesc.Trim
                    Else
                        trNode = TrvScheme.Nodes.Add(lsSchemeList(lI).ProcedureDesc.Trim)
                        trNode.ToolTipText = lsSchemeList(lI).ProcedureCode.Trim
                    End If

                    If lsSchemeList(lI).ProcedureCode.StartsWith(ThisAddIn.SCH_NOT_FOUND) Then
                        'disable the checkbox 
                        trNode.ForeColor = Drawing.Color.Gray
                    End If
                End If
                sProc = lsSchemeList(lI).ProcedureCode.Trim

            End If
            If lsSchemeList(lI).SchemeCode.Trim.Length > 0 Then
                'If bShowProcCode Then
                trNode = TrvScheme.Nodes(TrvScheme.Nodes.Count - 1).Nodes.Add(lsSchemeList(lI).SchemeCode.Trim)
                trNode.ToolTipText = lsSchemeList(lI).SchemeDesc.Trim
                'Else
                'trNode = TrvScheme.Nodes(TrvScheme.Nodes.Count - 1).Nodes.Add(lsSchemeList(lI).SchemeDesc.Trim)
                'trNode.ToolTipText = lsSchemeList(lI).SchemeCode.Trim
                'End If

                If lsSchemeList(lI).ProcedureCode.StartsWith(ThisAddIn.SCH_NOT_FOUND) Then
                    'disable the checkbox 
                    trNode.ForeColor = Drawing.Color.Gray
                End If
            End If
        Next
    End Sub
    Private Sub SwapSchemeListProcCodeDesc()
        bShowProcCode = Not bShowProcCode
        For lJ As Integer = 1 To TrvScheme.Nodes.Count
            Dim sToolTipText As String = TrvScheme.Nodes(lJ - 1).ToolTipText
            TrvScheme.Nodes(lJ - 1).ToolTipText = TrvScheme.Nodes(lJ - 1).Text
            TrvScheme.Nodes(lJ - 1).Text = sToolTipText
        Next
    End Sub
    Private Sub DistinctProcedureScheme(ByRef lsList As List(Of SLIMObj.Scheme))
        Dim sBuffer As String
        sBuffer = ""
        For lI As Integer = lsList.Count - 1 To 0 Step -1
            If lsList(lI).PROCEDURECODE = "***REMOVE THIS***" Then
                lsList.RemoveAt(lI)
            ElseIf sBuffer.Contains(">>" & lsList(lI).ProcedureCode & ">" & lsList(lI).SchemeCode & "<<") Then
                lsList.RemoveAt(lI)
            Else
                sBuffer = sBuffer & ">>" & lsList(lI).ProcedureCode & ">" & lsList(lI).SchemeCode & "<<"
            End If
        Next
    End Sub
    Private Sub TrvScheme_AfterCheck(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles TrvScheme.AfterCheck
        RemoveHandler TrvScheme.AfterCheck, AddressOf TrvScheme_AfterCheck

        For Each node As Windows.Forms.TreeNode In e.Node.Nodes
            node.Checked = e.Node.Checked
        Next

        If e.Node.Checked Then
            If e.Node.Parent Is Nothing = False Then
                Dim allChecked As Boolean = True

                For Each node As Windows.Forms.TreeNode In e.Node.Parent.Nodes
                    If Not node.Checked Then
                        allChecked = False
                    End If
                Next

                If allChecked Then
                    e.Node.Parent.Checked = True
                End If

            End If
        Else
            If e.Node.Parent Is Nothing = False Then
                e.Node.Parent.Checked = False
            End If
        End If

        AddHandler TrvScheme.AfterCheck, AddressOf TrvScheme_AfterCheck
    End Sub


    Private Sub Add_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        For lI As Integer = 1 To lvSample.SelectedItems.Count
            For lJ As Integer = 1 To TrvScheme.Nodes.Count
                If TrvScheme.Nodes(lJ - 1).Nodes.Count = 0 And TrvScheme.Nodes(lJ - 1).Checked Then
                    Dim xListRow As Excel.ListRow = xListSch.ListRows.AddEx
                    Dim sProcCode As String
                    If bShowProcCode Then
                        sProcCode = TrvScheme.Nodes(lJ - 1).Text
                    Else
                        sProcCode = TrvScheme.Nodes(lJ - 1).ToolTipText
                    End If

                    xListRow.Range(1, xListSch.ListColumns("Procedure").Index) = sProcCode
                    'xListRow.Range(1, xListSch.ListColumns("Scheme").Index) = TrvScheme.Nodes(lJ - 1).Nodes(lK - 1).Text
                    xListRow.Range(1, xListSch.ListColumns("Sample ID").Index) = lvSample.SelectedItems(lI - 1).Text
                Else
                    For lK As Integer = 1 To TrvScheme.Nodes(lJ - 1).Nodes.Count
                        If TrvScheme.Nodes(lJ - 1).Nodes(lK - 1).Checked() Then
                            Dim xListRow As Excel.ListRow = xListSch.ListRows.AddEx
                            Dim sProcCode As String
                            If bShowProcCode Then
                                sProcCode = TrvScheme.Nodes(lJ - 1).Text
                            Else
                                sProcCode = TrvScheme.Nodes(lJ - 1).ToolTipText
                            End If

                            xListRow.Range(1, xListSch.ListColumns("Procedure").Index) = sProcCode
                            xListRow.Range(1, xListSch.ListColumns("Scheme").Index) = TrvScheme.Nodes(lJ - 1).Nodes(lK - 1).Text
                            xListRow.Range(1, xListSch.ListColumns("Sample ID").Index) = lvSample.SelectedItems(lI - 1).Text
                        End If
                    Next
                End If

            Next
        Next
    End Sub

    Private Sub TrvScheme_AfterSelect(sender As Object, e As Windows.Forms.TreeViewEventArgs) Handles TrvScheme.AfterSelect
        If e.Node.Level = 0 Then
            Dim sProcCode As String
            If bShowProcCode Then
                sProcCode = e.Node.Text
            Else
                sProcCode = e.Node.ToolTipText
            End If
            Dim sField1 As String = lsSchemeList.Find(Function(s As SLIMObj.Scheme) s.ProcedureCode = sProcCode).ProcedureDesc
            lblSchemeMethod.Text = ""
            lblSchemeMethod.Text = sField1

            lblField1.Visible = True
            lblField1.Text = "Procedure Description"
            txbField1.Visible = True
            txbField1.Text = sField1

            lblField2.Visible = False
            txbField2.Visible = False
            txbField2.Text = ""

            lblField3.Visible = False
            txbField3.Visible = False
            txbField3.Text = ""


        ElseIf e.Node.Level = 1 Then
            lblSchemeMethod.Text = ""
            Dim sProcCode As String
            If bShowProcCode Then
                sProcCode = e.Node.Parent.Text
            Else
                sProcCode = e.Node.Parent.ToolTipText
            End If
            For lI As Integer = 0 To lsSchemeList.Count - 1
                'If lsSchemeList(lI).ProcedureCode = e.Node.Parent.Text And lsSchemeList(lI).SchemeCode = e.Node.Text Then
                If lsSchemeList(lI).ProcedureCode = sProcCode And lsSchemeList(lI).SchemeCode = e.Node.Text Then
                    lblSchemeMethod.Text = lsSchemeList(lI).SchemeMethod & vbCrLf & lsSchemeList(lI).SchemeDesc

                    lblField1.Visible = True
                    lblField1.Text = "Scheme Description"
                    txbField1.Visible = True
                    txbField1.Text = lsSchemeList(lI).SchemeDesc

                    lblField2.Visible = True
                    txbField2.Visible = True
                    txbField2.Text = lsSchemeList(lI).SchemeName

                    lblField3.Visible = True
                    txbField3.Visible = True
                    txbField3.Text = lsSchemeList(lI).SchemeMethod
                    Exit For
                End If
            Next

        End If



    End Sub


    Private Sub btnMoreScheme_Click(sender As Object, e As EventArgs) Handles btnMoreScheme.Click
        Dim frmSchSeach As New FrmSchemeSearch
        With frmSchSeach
            If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                If .lsvSearchProcScheme.CheckedItems.Count > 0 Then
                    For lI As Integer = 0 To .lsvSearchProcScheme.CheckedItems.Count - 1
                        'MsgBox(.lsvSearchProcScheme.CheckedItems(lI).SubItems(0).Text & .lsvSearchProcScheme.CheckedItems(lI).SubItems(1).Text)
                        For lJ As Integer = 0 To .lsSearchProcScheme.Count - 1
                            If .lsSearchProcScheme.Item(lJ).ProcedureCode = .lsvSearchProcScheme.CheckedItems(lI).SubItems(0).Text Then
                                lsSchemeList.Add(.lsSearchProcScheme.Item(lJ))
                            End If
                        Next

                    Next
                    RefreshScheme()
                End If
            End If
        End With

    End Sub

    Private Sub btnLoadScheme_Click(sender As Object, e As EventArgs) Handles btnLoadScheme.Click
        MapSchemeByWebService()

    End Sub

    Private Sub MapSchemeByWebService()
        Dim wsSLIM As New CCLAS.CCLASXMLServiceSoapClient
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))
        Try
            Dim sRes As String = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
            If sRes <> "0" Then
                MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
            Else
                Dim xNode As Xml.XmlNode
                For lI As Integer = 0 To lsSchemeList.Count - 1
                    If lsSchemeList(lI).ProcedureCode.Length > 0 And lsSchemeList(lI).SchemeCode.Length > 0 Then
                        'xNode = wsSLIM.ProcedureDataFromLIMS(lsSchemeList(lI).PROCEDURECODE, "%", True, "", "")
                        'If zzzNOTFOUNDzzz or valid Procedurecode, no need to map
                        If lsSchemeList(lI).ProcedureCode.StartsWith(ThisAddIn.SCH_NOT_FOUND) Then
                        Else
                            xNode = wsSLIM.ProcedureDataFromLIMS(lsSchemeList(lI).ProcedureCode, "%", True, "PROCEDURECODE", "")
                            If xNode.InnerXml.Length > 0 Then
                                'valid procedure
                            Else
                                If lsSchemeList(lI).ProcedureCode.Equals("_NO_PROCEDURE_") Then
                                    xNode = wsSLIM.ProcedureDataFromLIMS("", "%", True, "PROCEDURECODE,DESCRIPTION,USERFIELD1,USERFIELD2,USERFIELD3", "USERFIELD2='" & lsSchemeList(lI).SchemeCode & "' AND USERFIELD3=''")
                                Else
                                    xNode = wsSLIM.ProcedureDataFromLIMS("", "%", True, "PROCEDURECODE,DESCRIPTION,USERFIELD1,USERFIELD2,USERFIELD3", "USERFIELD2='" & lsSchemeList(lI).SchemeCode & "' AND USERFIELD3='" & lsSchemeList(lI).ProcedureCode & "'")
                                End If
                                'MsgBox(xNode.OuterXml)
                                'Get PROCEDURE > PROCEDURE_SCHEME > row > SCH_CODE, DESCRIPTION, METHODCODE
                                If xNode.InnerXml.Length > 0 Then
                                    Dim lsProc As New List(Of Windows.Forms.ListViewItem)
                                    For Each xeProc As Xml.XmlElement In xNode.SelectNodes("/row")
                                        lsProc.Add(New Windows.Forms.ListViewItem(New String() {xeProc.Item("PROCEDURECODE").InnerXml, _
                                                                                                xeProc.Item("DESCRIPTION").InnerXml, _
                                                                                                xeProc.Item("USERFIELD1").InnerXml, _
                                                                                                xeProc.Item("USERFIELD2").InnerXml, _
                                                                                                xeProc.Item("USERFIELD3").InnerXml}))
                                    Next
                                    For Each xeScheme As Xml.XmlElement In xNode.SelectNodes("/PROCEDURE_SCHEME/row")
                                        'MsgBox(xeScheme.Item("SCH_CODE").InnerXml)
                                        Dim sPD As String = lsProc.Find(Function(value As Windows.Forms.ListViewItem) value.SubItems(0).Text = xeScheme.Item("PROCEDURECODE").InnerXml).SubItems(1).Text

                                        lsSchemeList.Add(New SLIMObj.Scheme With {.ProcedureCode = xeScheme.Item("PROCEDURECODE").InnerXml, _
                                                                                  .ProcedureDesc = sPD, _
                                                                                .SchemeCode = xeScheme.Item("SCH_CODE").InnerXml, _
                                                                                .SchemeMethod = xeScheme.Item("METHODCODE").InnerXml, _
                                                                                .SchemeDesc = xeScheme.Item("DESCRIPTION").InnerXml, _
                                                                                .SchemeName = xeScheme.Item("SCHEMENAME").InnerXml})
                                    Next
                                    lsSchemeList(lI).ProcedureCode = "***REMOVE THIS***"
                                Else
                                    lsSchemeList(lI).ProcedureCode = ThisAddIn.SCH_NOT_FOUND & lsSchemeList(lI).ProcedureCode
                                    lsSchemeList(lI).ProcedureDesc = lsSchemeList(lI).ProcedureCode
                                End If
                            End If
                        End If
                        
                    End If

                Next
                RefreshScheme()
            End If
        Catch ex As Exception

        End Try
        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub TrvScheme_BeforeCheck(sender As Object, e As Windows.Forms.TreeViewCancelEventArgs) Handles TrvScheme.BeforeCheck
        If e.Node.ForeColor = Drawing.Color.Gray Then
            e.Cancel = True
        End If

    End Sub



    Private Sub TrvScheme_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles TrvScheme.KeyUp
        If e.KeyValue = Windows.Forms.Keys.Delete Then
            If TrvScheme.SelectedNode.Level = 0 Then
                If MsgBox("Delete procedure ?".Replace("procedure", TrvScheme.SelectedNode.Text), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                    lsSchemeList.RemoveAll(Function(s As SLIMObj.Scheme) s.ProcedureCode = TrvScheme.SelectedNode.Text)
                    RefreshScheme()

                End If
            End If
        End If


    End Sub

    Private Sub btnMoreSample_Click(sender As Object, e As EventArgs) Handles btnMoreSample.Click
        Dim fSample As New FrmSample
        fSample.ShowDialog()

        RefreshSample()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSwapProcDescCode.Click
        SwapSchemeListProcCodeDesc()
    End Sub
End Class

