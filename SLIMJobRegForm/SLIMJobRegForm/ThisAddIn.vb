Public Class ThisAddIn
    Public Const JOBSHEET As String = "Job"
    Public Const JOBLIST As String = "Job"
    Public Const JOBLISTBF As String = "JobBF"
    Public Const SAMSHEET As String = "Sample"
    Public Const SAMLIST As String = "Sample"
    Public Const SAMLISTBF As String = "SampleBF"
    Public Const ORIGSHEET As String = "OrigSample"
    Public Const ORIGLIST As String = "OrigSample"
    Public Const ORIGLISTBF As String = "OrigSampleBF"
    Public Const SPECSHEET As String = "SpecSample"
    Public Const SPECLIST As String = "SpecSample"
    Public Const SPECLISTBF As String = "SpecSampleBF"
    Public Const COMPSHEET As String = "CompSample"
    Public Const COMPLIST As String = "CompSample"
    Public Const COMPLISTBF As String = "CompSampleBF"
    Public Const SCHSHEET As String = "Scheme"
    Public Const SCHLIST As String = "Scheme"
    Public Const REFSHEET As String = "Ref"
    Public Const REFLIST As String = "Ref"
    Public Const UDSHEET As String = "UserData"
    Public Const UDLIST As String = "UserData"
    'Ref Column Assignment for different Key
    Public Const REFKEY As Integer = 1
    'Procedure	Scheme	Scheme Desc	Scheme Method	Procedure Description Scheme Name
    Public Const REFSch As String = "SCHEME"
    Public Const REFSch_ProCode As Integer = 2
    Public Const REFSch_SchCode As Integer = 3
    Public Const REFSch_SchDesc As Integer = 4
    Public Const REFSch_SchMethod As Integer = 5
    Public Const REFSch_ProDesc As Integer = 6
    Public Const REFSch_SchName As Integer = 7
    'UserData  
    Public Const UD_DataField As Integer = 1     'description_3 - Article;     'description_5 - Material;    'description_6 - Color
    Public Const UD_DataSeq As Integer = 2
    Public Const UD_DataCode As Integer = 3
    Public Const UD_DataExtra1 As Integer = 4
    Public Const UD_DataExtra2 As Integer = 5
    Public Const UD_DataValue As Integer = 6
    Public Const UD_UF1 As Integer = 7 ' EN Desc for Biofield
    Public Const UD_UF2 As Integer = 8 ' DE Desc for Biofield
    Public Const UD_UF3 As Integer = 9 ' NL Desc for Biofield
    Public Const UD_UF4 As Integer = 10 ' ES Desc for Biofield
    Public Const UD_UF5 As Integer = 11 ' FR Desc for Biofield
    Public Const UD_UF6 As Integer = 12 ' IT Desc for Biofield
    Public Const UD_UF7 As Integer = 13 ' CN Desc for Biofield
    Public Const UD_UF8 As Integer = 14
    Public Const UD_UF9 As Integer = 15
    Public Const UD_UF10 As Integer = 16 ' Job/Sample for Biofield

    Public Const SCH_NOT_FOUND As String = "zzzNOT FOUNDzzz"

    Shared cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)

    Private Sub ThisAddIn_Startup() Handles Me.Startup
        'MsgBox("123")
    End Sub

    Private Sub ThisAddIn_Shutdown() Handles Me.Shutdown

    End Sub
    Public Shared Sub setSLIMWorkBook()
        Dim xBook As Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
        Dim xSheet As Excel.Worksheet
        Dim xList As Excel.ListObject
        Dim xBFList As Excel.ListObject

        If xBook Is Nothing Then
            MsgBox("Please first create workbook")
            xBook = Globals.ThisAddIn.Application.Workbooks.Add
        End If

        If xBook Is Nothing Then
            MsgBox("Fail")
        Else
            xSheet = getSheet(xBook, REFSHEET, , True)
            xList = getList(xSheet, REFLIST)
            xSheet.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden

            xSheet = getSheet(xBook, UDSHEET, , True)
            xList = getList(xSheet, UDLIST)
            xSheet.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden

            'check Job worksheet, if not found -> create Job worksheet
            'create Scheme worksheet
            xSheet = getSheet(xBook, SCHSHEET)
            'create Scheme table
            xList = getList(xSheet, SCHLIST)

            'create Sample worksheet - for all original,specimen,composite
            xSheet = getSheet(xBook, SAMSHEET)
            'create Sample table - for all original,specimen,composite
            xList = getList(xSheet, SAMLIST)
            'create Sample Biofield table  - for all original,specimen,composite
            xBFList = getList(xSheet, SAMLISTBF)

            'create Job Sheet
            xSheet = getSheet(xBook, JOBSHEET)
            'create Job table
            xList = getList(xSheet, JOBLIST)
            'create Job Biofield table
            xBFList = getList(xSheet, JOBLISTBF)


        End If
    End Sub
    Public Shared Function getSheet(xBook As Excel.Workbook, sName As String, Optional bNew As Boolean = True, Optional bHidden As Boolean = False) As Excel.Worksheet
        Dim xSheet As Excel.Worksheet

        For Each xSheet In xBook.Worksheets
            If xSheet.Name = sName Then
                Return xSheet
                Exit For
            End If
        Next
        If bNew Then
            xSheet = xBook.Worksheets.Add
            xSheet.Name = sName
            If bHidden Then
                xSheet.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden
            End If
            Return xSheet
        Else
            Return Nothing
        End If
    End Function
    Public Shared Function getList(xSheet As Excel.Worksheet, sName As String, Optional bNew As Boolean = True) As Excel.ListObject
        Dim xList As Excel.ListObject
        Dim lLastRow As Integer
        Dim aCol() As String

        For Each xList In xSheet.ListObjects
            If xList.Name = sName Then
                Return xList
                Exit For
            End If
        Next

        If Not bNew Then
            Return Nothing
        Else
            '************ Enhance here
            lLastRow = xSheet.UsedRange.SpecialCells(Excel.XlCellType.xlCellTypeLastCell).Row
            If lLastRow > 1 Then
                lLastRow += 1
            End If
            If Right(sName, 2) = "BF" Then
                lLastRow += 3
            End If

            aCol = Split(getListColumn(sName), ",")
            xList = xSheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, xSheet.Range(xSheet.Cells(lLastRow, 1), xSheet.Cells(lLastRow, aCol.Count)), , Excel.XlYesNoGuess.xlYes, xSheet.Range("$A$1"), )

            For lI As Integer = 1 To aCol.Count
                xList.ListColumns(lI).Name = aCol(lI - 1).Trim
            Next
            xList.Name = sName

            Return xList
        End If

    End Function
    Public Shared Function getListColumn(sListName As String) As String
        Select Case sListName.Trim
            Case JOBLIST
                getListColumn = "Client,Project,Client Contact,Order,Client Order,Product Code,Report Template,Cost Code,Required Date"
            Case SAMLIST
                getListColumn = "Sample Type,Sample ID,Linked ID,SampleIdent,Client Desc,SGS Desc,Article No,Material,Color,Remark,Product Code,SLIM Lab ID"
            Case SCHLIST
                getListColumn = "Procedure,Scheme,Sample ID"
            Case JOBLISTBF
                getListColumn = "Biofield,Value,Report Active"
            Case SAMLISTBF
                getListColumn = "Sample ID,Biofield,Value,Report Active"
            Case REFLIST
                getListColumn = "Key,Field1,Field2,Field3,Field4,Field5,Field6,Field7,Field8,Field9,Field10"
            Case UDLIST
                getListColumn = "DATAFIELD,DATASEQUENE,DATACODE,DATAEXTRA1,DATAEXTRA2,DATAVALUE,USERFIELD01,USERFIELD02,USERFIELD03,USERFIELD04,USERFIELD05,USERFIELD06,USERFIELD07,USERFIELD08,USERFIELD09,USERFIELD10"
            Case Else
                getListColumn = "Field1,Field2,Field3"
        End Select

    End Function
    Public Shared Function GetJobValue(sField As String) As String
        Dim xSheet As Excel.Worksheet

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.JOBSHEET, False)
        If IsNothing(xSheet) Then
        Else
            Dim xList As Excel.ListObject
            xList = ThisAddIn.getList(xSheet, ThisAddIn.JOBLIST, False)
            If IsNothing(xList) Then
            Else
                Try
                    Return xList.Range.Cells(2, xList.ListColumns(sField).Index).Value2
                Catch ex As Exception
                End Try
            End If
        End If

        GetJobValue = ""

    End Function
    Public Shared Function IsAllSampleValid(Optional ByVal sLinkedSampleType As String = "Specimen,Composite") As Boolean
        Dim xSheet As Excel.Worksheet
        sLinkedSampleType = "," & sLinkedSampleType & ","
        ' Check (1) Sample Type & Sample ID is not empty (2) Linked ID is not empty if 
        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If IsNothing(xSheet) Then
            Return False
        Else
            Dim xList As Excel.ListObject
            xList = ThisAddIn.getList(xSheet, ThisAddIn.SAMLIST, False)
            If IsNothing(xList) Then
            Else
                Try
                    For lI As Integer = 1 To xList.ListRows.Count
                        If xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2.ToString.Trim.Length = 0 Then
                            Return False
                        ElseIf sLinkedSampleType.IndexOf("," & xList.Range.Cells(lI + 1, xList.ListColumns("Sample Type").Index).Value2.ToString & ",") >= 0 Then
                            If xList.Range.Cells(lI + 1, xList.ListColumns("Linked ID").Index).Value2.ToString.Length = 0 Then
                                'Sample belongs Linked Sample Type and Linked ID is empty
                                Return False
                            End If

                        End If
                    Next
                Catch ex As Exception
                    Return False
                End Try
            End If
        End If
        IsAllSampleValid = True
    End Function
    Public Shared Function GetSampleBFValue(sSamID As String, sBF As String) As String
        Dim xSheet As Excel.Worksheet

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If IsNothing(xSheet) Then
        Else
            Dim xList As Excel.ListObject
            xList = ThisAddIn.getList(xSheet, ThisAddIn.SAMLISTBF, False)
            If IsNothing(xList) Then
            Else
                Try

                    For lI As Integer = 1 To xList.ListRows.Count
                        If xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).Value2 = sSamID And _
                            xList.Range.Cells(lI + 1, xList.ListColumns("Biofield").Index).Value2 = sBF Then
                            Return xList.Range.Cells(lI + 1, xList.ListColumns("Value").Index).Value2
                        End If
                    Next
                Catch ex As Exception
                End Try
            End If
        End If

        GetSampleBFValue = ""

    End Function

    Public Shared Function GetSampleLastIndex(sField As String, sValue As String) As Integer
        Dim xSheet As Excel.Worksheet

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If IsNothing(xSheet) Then
        Else
            Dim xList As Excel.ListObject
            xList = ThisAddIn.getList(xSheet, ThisAddIn.SAMLIST, False)
            If IsNothing(xList) Then
            Else
                Try
                    For lI As Integer = xList.ListRows.Count To 1 Step -1
                        If xList.Range.Cells(lI + 1, xList.ListColumns(sField).Index).Value2 = sValue Then
                            Return lI
                        End If
                    Next
                Catch ex As Exception
                End Try
            End If
        End If

        GetSampleLastIndex = -1
    End Function
    Public Shared Sub ManageSampleList()
        Dim xSheet As Excel.Worksheet
        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If IsNothing(xSheet) Then
        Else
            Dim xList As Excel.ListObject
            Dim xListBF As Excel.ListObject
            Dim sSamIDs As String = ","

            xList = getList(xSheet, ThisAddIn.SAMLIST, False)
            xListBF = getList(xSheet, ThisAddIn.SAMLISTBF, False)

            'Remove blank row in Sample List
            For lI As Integer = xList.ListRows.Count To 1 Step -1
                If xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).value2 Is Nothing Then
                    xList.ListRows(lI).Delete()
                ElseIf xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).value2.ToString.Length = 0 Then
                    xList.ListRows(lI).Delete()
                Else
                    sSamIDs = sSamIDs & xList.Range.Cells(lI + 1, xList.ListColumns("Sample ID").Index).value2 & ","
                End If
            Next
            'Remove blank row in SampleBF List
            For lI As Integer = xListBF.ListRows.Count To 1 Step -1
                If xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Sample ID").Index).value2 Is Nothing Or _
                    xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Biofield").Index).value2 Is Nothing Then
                    xListBF.ListRows(lI).Delete()
                ElseIf xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Sample ID").Index).value2.ToString.Length = 0 Or _
                    xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Biofield").Index).value2.ToString.Length = 0 Then
                    xListBF.ListRows(lI).Delete()
                Else
                    Dim sSamID As String = "," & xListBF.Range.Cells(lI + 1, xListBF.ListColumns("Sample ID").Index).value2 & ","
                    If sSamIDs.IndexOf(sSamID) >= 0 Then
                    Else
                        xListBF.ListRows(lI).Delete()
                    End If
                End If
            Next
            'Remove duplicate SampleId in Sample List
            Dim xSamCol(0) As Object
            xSamCol.SetValue(2, 0)
            xSheet.Range(ThisAddIn.SAMLIST).RemoveDuplicates(xSamCol, Excel.XlYesNoGuess.xlYes)

            'Remove duplicate BF per SampleId per Biofield code
            Dim xCol(1) As Object
            xCol.SetValue(1, 0)
            xCol.SetValue(2, 1)
            xSheet.Range(ThisAddIn.SAMLISTBF).RemoveDuplicates(xCol, Excel.XlYesNoGuess.xlYes)

            'Remove row with non-exist SampleId  in SampleBF List
        End If
    End Sub
    Public Shared Function MapXMLField(sField As String, Optional ByVal sLevel As String = "") As String
        Select Case sField
            '"Client,Project,Client Contact,Order,Client Order,Product Code"
            Case "Client"
                MapXMLField = "CCLAS_LABCODE"
            Case "Project"
                MapXMLField = "PROJ_CODE"
            Case "Client Contact"
                MapXMLField = "OWNERCODE"
            Case "Order"
                MapXMLField = "PRO_JOB"
            Case "Product Code"
                MapXMLField = "PRODUCTCODE"
            Case "Report Template"
                MapXMLField = "REPORTTPL"
            Case "Cost Code"
                MapXMLField = "COSTCODE"
            Case "Required Date"
                MapXMLField = "REQUIRED"
            Case "Sample ID"
                MapXMLField = "SAMPLEIDENT"
            Case "Sample Type"
                MapXMLField = "DESCRIPTION"
            Case "Linked ID"
                If sLevel = "Specimen" Then
                    MapXMLField = "DESCRIPTION_1"
                ElseIf sLevel = "Composite" Then
                    MapXMLField = "DESCRIPTION_2"
                Else
                    MapXMLField = ""
                End If
            Case "Client Desc"
                MapXMLField = "SAM_DESCRIPTION"
            Case "SGS Desc"
                MapXMLField = "SAM_REMARKS"
            Case "Article No"
                MapXMLField = "DESCRIPTION_3"
            Case "Remark"
                MapXMLField = "DESCRIPTION_4"
            Case "Material"
                MapXMLField = "DESCRIPTION_5"
            Case "Color"
                MapXMLField = "DESCRIPTION_6"
            Case "Biofield"
                MapXMLField = "BIOFIELD"
            Case "Value"
                MapXMLField = "BIOVALUE"
            Case "Report Active"
                MapXMLField = "ISACTIVE"
            Case "Procedure"
                MapXMLField = "PROCEDURECODE"
            Case "Scheme"
                MapXMLField = "INCLUDE"

            Case Else
                MapXMLField = ""
        End Select
    End Function

    Public Shared Sub AddJob()
        Dim fJob As New frmJob
        fJob.bNew = False
        'fJob.Show()
        fJob.ShowDialog()


    End Sub
    Public Shared Sub AddSample()
        Dim fSample As New FrmSample

        'fSample.Show()
        fSample.ShowDialog()

    End Sub
    Public Shared Sub DeleteSample()
        Dim xSheet As Excel.Worksheet
        Dim xList As Excel.ListObject
        Dim xListBF As Excel.ListObject

        xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SAMSHEET, False)
        If IsNothing(xSheet) Then
            MsgBox("Error - Not SLIM Job Reg Workbook")
            Exit Sub
        Else
            xList = ThisAddIn.getList(xSheet, ThisAddIn.SAMLIST, False)
            xListBF = ThisAddIn.getList(xSheet, ThisAddIn.SAMLISTBF, False)
            If IsNothing(xList) Or IsNothing(xListBF) Then
                MsgBox("Error - Not SLIM Job Reg Workbook")
                Exit Sub
            End If
            '!!!! Now only 1 active cell !!!!
            If Globals.ThisAddIn.Application.ActiveCell.ListObject.Name.ToString.Equals(ThisAddIn.SAMSHEET) Then
                Dim xRow As Excel.ListRow = Globals.ThisAddIn.Application.ActiveCell.ListObject.ListRows(Globals.ThisAddIn.Application.ActiveCell.Row - Globals.ThisAddIn.Application.ActiveCell.ListObject.Range.Row)
                Dim sST As String = xRow.Range.Cells(1, xList.ListColumns("Sample Type").Index).Value2
                Dim sSID As String = xRow.Range.Cells(1, xList.ListColumns("Sample ID").Index).Value2
                Dim lsDeleteID As List(Of String) = New List(Of String)

                If sST.Equals("Original") Then
                    'Delete original and specimen and composite and its schemes
                    MsgBox("Not allow to delete original sample.")

                ElseIf sST.Equals("Specimen") Then
                    'Delete specimen and composite and its schemes (checking on both Sample ID and Linked ID)
                    For lSRow As Integer = xList.ListRows.Count + 1 To 1 Step -1
                        If xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2 Is Nothing Or xList.Range.Cells(lSRow, xList.ListColumns("Linked ID").Index).Value2 Is Nothing Then
                        ElseIf xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2.ToString.Equals(sSID) Or xList.Range.Cells(lSRow, xList.ListColumns("Linked ID").Index).Value2.ToString.Contains(sSID) Then
                            lsDeleteID.Add(xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2)
                            xList.ListRows(lSRow - 1).Delete()

                        End If
                    Next
                    For lSBFRow As Integer = xListBF.ListRows.Count + 1 To 1 Step -1
                        If xListBF.Range.Cells(lSBFRow, xListBF.ListColumns("Sample ID").Index).Value2 Is Nothing Then
                        ElseIf lsDeleteID.IndexOf(xListBF.Range.Cells(lSBFRow, xListBF.ListColumns("Sample ID").Index).Value2) >= 0 Then
                            xListBF.ListRows(lSBFRow - 1).Delete()
                        End If
                    Next

                    'Delete gridded scheme
                    xSheet = ThisAddIn.getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, ThisAddIn.SCHSHEET, False)
                    xList = ThisAddIn.getList(xSheet, ThisAddIn.SCHSHEET, False)
                    For lSRow As Integer = xList.ListRows.Count + 1 To 1 Step -1
                        If xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2 Is Nothing Then
                        ElseIf xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2.ToString.Equals(sSID) Then
                            lsDeleteID.Add(xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2)
                            xList.ListRows(lSRow - 1).Delete()

                        End If
                    Next
                Else
                    'Delete itself and its schemes e.g. Composite  (checking on Sample ID only)
                    For lSRow As Integer = xList.ListRows.Count + 1 To 1 Step -1
                        If xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2 Is Nothing Then
                        ElseIf xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2.ToString.Equals(sSID) Then
                            lsDeleteID.Add(xList.Range.Cells(lSRow, xList.ListColumns("Sample ID").Index).Value2)
                            xList.ListRows(lSRow - 1).Delete()

                        End If
                    Next
                    For lSBFRow As Integer = xListBF.ListRows.Count + 1 To 1 Step -1
                        If xListBF.Range.Cells(lSBFRow, xListBF.ListColumns("Sample ID").Index).Value2 Is Nothing Then
                        ElseIf lsDeleteID.IndexOf(xListBF.Range.Cells(lSBFRow, xListBF.ListColumns("Sample ID").Index).Value2) >= 0 Then
                            xListBF.ListRows(lSBFRow - 1).Delete()
                        End If
                    Next

                    'Delete gridded scheme

                End If
            End If

        End If
    End Sub
    Public Shared Sub openSLIMXML(ByVal xmlDoc As Xml.XmlDocument)

        Dim xmlDoc2 As Xml.XmlDocument
        Dim xBook As Excel.Workbook
        Dim xSheet As Excel.Worksheet
        Dim xSheet1 As Excel.Worksheet
        Dim xList As Excel.ListObject
        Dim xListBF As Excel.ListObject
        Dim xList1 As Excel.ListObject
        Dim xRow As Excel.ListRow
        Dim sOrderNo As String = ""

        'Write Job Level field to Table 
        'Not to ask, always new worksheet
        Dim oAns = MsgBoxResult.No
        'MsgBox("Load into the current active workbook?", MsgBoxStyle.YesNoCancel)
        'If oAns = MsgBoxResult.Cancel Then
        '    Exit Sub
        'ElseIf oAns = MsgBoxResult.No Then
        '    xBook = Globals.ThisAddIn.Application.ActiveWorkbook
        'Else
        '    'Globals.ThisAddIn.Application.DisplayAlerts = False
        'End If

        If xBook Is Nothing Then
            'MsgBox("Please first create workbook")
            xBook = Globals.ThisAddIn.Application.Workbooks.Add
        End If
        xSheet = getSheet(xBook, REFSHEET, , True)
        xList = getList(xSheet, REFLIST)
        xSheet.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden

        xSheet = getSheet(xBook, UDSHEET, , True)
        xList = getList(xSheet, UDLIST)
        xSheet.Visible = Excel.XlSheetVisibility.xlSheetVeryHidden

        xSheet = getSheet(xBook, JOBSHEET)
        xSheet.Cells.NumberFormat = "@"
        If Not IsNothing(xSheet) Then
            xList = getList(xSheet, JOBLIST)
            For Each oElement As Xml.XmlElement In xmlDoc.SelectNodes("/JOB")
                For Each oAttribute As Xml.XmlAttribute In oElement.Attributes
                    'MsgBox(oAttribute.Name & ":" & oAttribute.Value)
                    For lI As Integer = 1 To xList.ListColumns.Count
                        If MapXMLField(xList.ListColumns(lI).Name) = oAttribute.Name Then
                            If IsNothing(xRow) Then
                                xRow = xList.ListRows.AddEx
                            End If
                            xRow.Range.Cells(1, lI) = oAttribute.Value
                            If xList.ListColumns(lI).Name = "Order" Then
                                sOrderNo = oAttribute.Value
                            End If
                        End If
                    Next
                Next
            Next
            xRow = Nothing
            xList = Nothing

            'Write Job Level Biofield to Table
            xList = getList(xSheet, JOBLISTBF)
            'Add Default Job biofield 
            'Biofield1~BioValue1~IsActive1,Biofield2~BioValue2~IsActive2 etc. 
            Dim sDefJobBFs As String = ""
            If cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_JobBioFieldDefault") IsNot Nothing Then
                sDefJobBFs = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_JobBioFieldDefault").Value
            End If

            If sDefJobBFs.Trim.Length > 0 Then
                Dim sDefJobBF() As String = sDefJobBFs.Split(",")
                For lI As Integer = 0 To sDefJobBF.Count - 1
                    xRow = xList.ListRows.AddEx
                    For lJ As Integer = 1 To xList.ListColumns.Count
                        xRow.Range.Cells(1, lJ) = MapDefJobBFField(sDefJobBF(lI), xList.ListColumns(lJ).Name)

                    Next
                Next
            End If
            For Each oElement As Xml.XmlElement In xmlDoc.SelectNodes("/JOB/JOBBIOFIELD")
                If oElement.GetAttribute("BIOFIELD").Length > 0 Then
                    xRow = xList.ListRows.AddEx
                    'xRow.Range.Cells(1, xList.ListColumns("Biofield")) = oElement.GetAttribute("Biofield")
                    For lI As Integer = 1 To xList.ListColumns.Count
                        xRow.Range.Cells(1, lI) = oElement.GetAttribute(MapXMLField(xList.ListColumns(lI).Name))
                    Next
                End If
            Next
            xRow = Nothing
            xList = Nothing
            xSheet = Nothing

            xmlDoc2 = New Xml.XmlDocument
            xSheet = getSheet(xBook, SAMSHEET)
            xSheet.Cells.NumberFormat = "@"
            xList = getList(xSheet, SAMLIST)
            xListBF = getList(xSheet, SAMLISTBF)
            xSheet1 = getSheet(xBook, SCHSHEET)
            xSheet1.Cells.NumberFormat = "@"
            xList1 = getList(xSheet1, SCHLIST)
            For Each oElement As Xml.XmlElement In xmlDoc.SelectNodes("/JOB/SAMPLE")
                If oElement.GetAttribute("SAMPLEIDENT").Length > 0 Then
                    xRow = xList.ListRows.AddEx
                    For lI As Integer = 1 To xList.ListColumns.Count
                        xRow.Range.Cells(1, lI) = oElement.GetAttribute(MapXMLField(xList.ListColumns(lI).Name))
                    Next
                    xRow = Nothing
                    If oElement.InnerXml.Length > 0 Then
                        'xmlDoc2 = Nothing
                        xmlDoc2.LoadXml(oElement.OuterXml)
                        For Each oInnerElement As Xml.XmlElement In xmlDoc2.SelectNodes("/SAMPLE/SAMPLEBIOFIELD")
                            If oInnerElement.GetAttribute("BIOFIELD").Length > 0 Then
                                xRow = xListBF.ListRows.AddEx()
                                For lJ As Integer = 1 To xListBF.ListColumns.Count
                                    If xListBF.ListColumns(lJ).Name.Equals("Sample ID") Then
                                        xRow.Range.Cells(1, lJ) = oElement.GetAttribute("SAMPLEIDENT")
                                    Else
                                        xRow.Range.Cells(1, lJ) = oInnerElement.GetAttribute(MapXMLField(xListBF.ListColumns(lJ).Name))
                                    End If
                                Next
                                xRow = Nothing
                            End If
                        Next
                        For Each oInnerElement As Xml.XmlElement In xmlDoc2.SelectNodes("/SAMPLE/SCHEME")
                            If oInnerElement.GetAttribute("PROCEDURECODE").Length > 0 Or oInnerElement.GetAttribute("INCLUDE").Length > 0 Then
                                xRow = xList1.ListRows.AddEx()
                                For lJ As Integer = 1 To xList1.ListColumns.Count
                                    If xList1.ListColumns(lJ).Name.Equals("Sample ID") Then
                                        xRow.Range.Cells(1, lJ) = oElement.GetAttribute("SAMPLEIDENT")
                                    Else
                                        xRow.Range.Cells(1, lJ) = oInnerElement.GetAttribute(MapXMLField(xList1.ListColumns(lJ).Name))
                                    End If
                                Next
                            End If
                        Next
                    End If
                End If
                '    xRow = xList.ListRows.AddEx
                '    'xRow.Range.Cells(1, xList.ListColumns("Biofield")) = oElement.GetAttribute("Biofield")
                '    For lI As Integer = 1 To xList.ListColumns.Count
                '        xRow.Range.Cells(1, lI) = oElement.GetAttribute(MapXMLField(xList.ListColumns(lI).Name))
                '    Next
                'End If

            Next
            'Write Sample level field and Biofield to Table (Original Sample)
            'Write Sample Scheme to Table - May need to map ECVStandardID
            xSheet = getSheet(xBook, ThisAddIn.SCHSHEET, False)
            xSheet.Move(xBook.Worksheets(1))
            xSheet = getSheet(xBook, ThisAddIn.SAMSHEET, False)
            xSheet.Move(xBook.Worksheets(1))
            xSheet = getSheet(xBook, ThisAddIn.JOBSHEET, False)
            xSheet.Move(xBook.Worksheets(1))

            'Delete Sheet1,2,3 if new worksheet
            If oAns = MsgBoxResult.No Then
                Dim bDA As Boolean = Globals.ThisAddIn.Application.DisplayAlerts
                Globals.ThisAddIn.Application.DisplayAlerts = False
                xSheet = getSheet(xBook, "Sheet1")
                If xSheet IsNot Nothing Then
                    xSheet.Delete()
                End If
                xSheet = getSheet(xBook, "Sheet2")
                If xSheet IsNot Nothing Then
                    xSheet.Delete()
                End If
                xSheet = getSheet(xBook, "Sheet3")
                If xSheet IsNot Nothing Then
                    xSheet.Delete()
                End If
                Globals.ThisAddIn.Application.DisplayAlerts = bDA
            End If
            Using sfd As New Windows.Forms.SaveFileDialog
                sfd.InitialDirectory = FileIO.SpecialDirectories.Desktop
                sfd.FileName = sOrderNo
                sfd.Filter = "Excel Workbook (*.xlsx)|*.xlsx"
                If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    xBook.SaveAs(sfd.FileName)
                    'MessageBox.Show(sfd.FileName)
                End If
            End Using

        End If

    End Sub
    Public Shared Function MapDefJobBFField(ByVal sDefJBF As String, ByVal sField As String) As String
        Dim sValue() As String = sDefJBF.Split("~")

        MapDefJobBFField = ""
        If sField.Equals("Biofield") Then
            If sValue.Count >= 1 Then
                MapDefJobBFField = sValue(0)
            End If
        ElseIf sField.Equals("Value") Then
            If sValue.Count >= 2 Then
                MapDefJobBFField = sValue(1)
            End If
        ElseIf sField.Equals("Report Active") Then
            If sValue.Count >= 3 Then
                If Not IsNumeric(sValue(2)) Then
                    MapDefJobBFField = "0"
                ElseIf sValue(2).Trim.Equals("1") Then
                    MapDefJobBFField = "1"
                Else
                    MapDefJobBFField = "0"
                End If

            End If
        Else
        End If

    End Function
    Public Shared Sub openSLIMXML(sFileName As String)
        Dim xmlDoc As Xml.XmlDocument
        xmlDoc = New Xml.XmlDocument
        Try
            xmlDoc.Load(sFileName)
        Catch ex As Exception
            'file error e.g locked by other program
            MsgBox("Error open file - " & ex.Message)
            Exit Sub
        End Try
    End Sub
    Public Shared Sub convECVXML(oOpenFile As System.Windows.Forms.OpenFileDialog)
        oOpenFile.Filter = "XML (*.xml)|*.xml"
        oOpenFile.InitialDirectory = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_TRFPath").Value

        If oOpenFile.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument
            Try
                '"C:\Users\tony_fong\Desktop\CTS SLIM Sharepoint\VF_EcVision\__ecVision_sFTP\ToTestCompany\Ready\TR_TR201504000443_20150415165424.xml"
                xmlDoc.Load(oOpenFile.FileName)
                If Not My.Computer.FileSystem.FileExists(System.IO.Path.GetDirectoryName(oOpenFile.FileName) + "\ecV_SLIM.xsl") Then
                    MsgBox("Error - XSL does not exists.", MsgBoxStyle.OkOnly, "Job Reg Form")
                Else
                    Dim xmlNav As Xml.XPath.XPathNavigator
                    Dim xmlTranfmr As Xml.Xsl.XslCompiledTransform = New Xml.Xsl.XslCompiledTransform
                    Dim xmlSettings As Xml.Xsl.XsltSettings = New Xml.Xsl.XsltSettings

                    xmlSettings.EnableScript = True

                    xmlNav = xmlDoc.CreateNavigator
                    xmlTranfmr.Load(System.IO.Path.GetDirectoryName(oOpenFile.FileName) + "\ecV_SLIM.xsl", xmlSettings, Nothing)

                    Dim strWriter As System.IO.StringWriter = New IO.StringWriter
                    xmlTranfmr.Transform(xmlNav, Nothing, strWriter)
                    Dim xmlDocNew As Xml.XmlDocument = New Xml.XmlDocument
                    xmlDocNew.LoadXml(strWriter.ToString)

                    openSLIMXML(xmlDocNew)
                    '    Dim txtWriter As IO.TextWriter = New IO.StreamWriter(System.IO.Path.GetDirectoryName(oOpenFile.FileName) + "\" + System.IO.Path.GetFileNameWithoutExtension(oOpenFile.FileName) + "_ToSLIM.xml")
                    '    xmlTranfmr.Transform(xmlNav, Nothing, txtWriter)
                    '    txtWriter = Nothing

                    My.Computer.FileSystem.RenameFile(oOpenFile.FileName, System.IO.Path.GetFileNameWithoutExtension(oOpenFile.FileName) & "_JRF" & Now.ToString("yyyyMMddHHmmss") & ".BAK")

                    xmlTranfmr = Nothing
                    xmlNav = Nothing
                End If
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            xmlDoc = Nothing
        End If

    End Sub

    Private Sub Application_SheetBeforeDoubleClick(Sh As Object, Target As Microsoft.Office.Interop.Excel.Range, ByRef Cancel As Boolean) Handles Application.SheetBeforeDoubleClick

        If Target.ListObject.Name = SAMLIST Then
            'MsgBox("Sample data row")
            Dim lCurrListRow As Integer = Target.Row - Target.ListObject.Range.Row
            If lCurrListRow > 0 Then
                'Data row i.e. not Header row
                Dim fSample As New FrmSample

                fSample.lRowID = lCurrListRow
                fSample.ShowDialog()

            End If
        End If
    End Sub

    Public Shared Sub AddSchemeBySample()
        Dim frmSch As New frmSchemeAdd
        'frmSch.Show()
        frmSch.ShowDialog()

    End Sub
    Public Shared Sub ExportSLIMXML()
        'get setting about export setting and path
        'export

        Dim xList As Excel.ListObject
        Dim xListBF As Excel.ListObject
        Dim xList2 As Excel.ListObject
        Dim xSheet As Excel.Worksheet
        Dim xSheet2 As Excel.Worksheet

        Dim sDir As String = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_RegPath").Value

        Dim sOrderNo As String = "NoOrderNumber"
        xSheet = getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, JOBSHEET, False)
        xList = getList(xSheet, JOBLIST, False)

        If xList.ListRows.Count <> 1 Then
            MsgBox("Error - Only 1 Job row support.")
        ElseIf Not IsAllSampleValid() Then
            MsgBox("Error - Check Sample Type, ID and Linked ID any empty or invalid value.")
        Else
            Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument
            Dim xmlDecl As Xml.XmlDeclaration
            Dim xmlJob As Xml.XmlElement

            xmlDecl = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "")
            xmlDoc.InsertBefore(xmlDecl, xmlDoc.DocumentElement)

            xmlJob = xmlDoc.CreateElement("JOB")
            Dim sXMLField As String = ""
            For lI As Integer = 1 To xList.ListColumns.Count
                If xList.ListColumns(lI).Name = "Order" Then
                    If xList.Range.Cells(2, lI).Value2 IsNot Nothing Then
                        sOrderNo = xList.Range.Cells(2, lI).Value2.ToString.Trim
                    Else
                        sOrderNo = "NoOrder_"
                    End If

                End If
                sXMLField = ThisAddIn.MapXMLField(xList.ListColumns(lI).Name)
                If sXMLField <> "" Then
                    xmlJob.SetAttribute(sXMLField, xList.Range.Cells(2, lI).Value2)
                End If
            Next
            xmlDoc.AppendChild(xmlJob)

            xList = getList(xSheet, JOBLISTBF, False)
            If xList Is Nothing Then
            ElseIf xList.ListRows.Count = 0 Then
            Else
                'Remove duplicate BF
                Dim xCol(0) As Object
                xCol.SetValue(1, 0)
                xSheet.Range(JOBLISTBF).RemoveDuplicates(xCol, Excel.XlYesNoGuess.xlYes)

                Dim xmlJobBF As Xml.XmlElement
                For lI As Integer = 1 To xList.ListRows.Count
                    xmlJobBF = xmlDoc.CreateElement("JOBBIOFIELD")
                    For lJ As Integer = 1 To xList.ListColumns.Count
                        sXMLField = ThisAddIn.MapXMLField(xList.ListColumns(lJ).Name)
                        If sXMLField <> "" Then
                            xmlJobBF.SetAttribute(sXMLField, xList.Range.Cells(lI + 1, lJ).Value2)
                        End If
                    Next
                    xmlJob.AppendChild(xmlJobBF)
                Next
            End If

            xSheet = getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, SAMSHEET, False)
            xList = getList(xSheet, SAMLIST, False)
            xListBF = getList(xSheet, SAMLISTBF, False)

            xSheet2 = getSheet(Globals.ThisAddIn.Application.ActiveWorkbook, SCHSHEET, False)
            xList2 = getList(xSheet2, SCHLIST, False)

            If xList Is Nothing Or xListBF Is Nothing Or xList2 Is Nothing Then
            ElseIf xList.ListRows.Count = 0 Or xList2.ListRows.Count = 0 Then
            Else
                'Remove duplicate BF
                Dim xCol(1) As Object
                xCol.SetValue(1, 0)
                xCol.SetValue(2, 1)
                xSheet.Range(SAMLISTBF).RemoveDuplicates(xCol, Excel.XlYesNoGuess.xlYes)

                'Mode Original(All)-Specimen(All)-Composite(All)
                Dim lsExtIdent As List(Of String) = New List(Of String)
                Dim lsLabId As List(Of String) = New List(Of String)

                'Order Sample List by Sample Type (Order by Orig-Spec-Comp) > Client Desc > Sample ID
                'Avoid duplicate sort key, clear all first
                xList.Sort.SortFields.Clear()
                xList.Sort.SortFields.Add(Globals.ThisAddIn.Application.Range("A2"), Excel.XlSortOn.xlSortOnValues, Excel.XlSortOrder.xlAscending, "Original,Specimen,Composite")
                xList.Sort.SortFields.Add(Globals.ThisAddIn.Application.Range("B2"), Excel.XlSortOn.xlSortOnValues, Excel.XlSortOrder.xlAscending, , Excel.XlSortDataOption.xlSortTextAsNumbers)
                xList.Sort.Apply()

                AppendSampleXMLElement(xmlJob, xmlDoc, xList, xListBF, xList2, lsLabId, lsExtIdent, "Original", False)
                AppendSampleXMLElement(xmlJob, xmlDoc, xList, xListBF, xList2, lsLabId, lsExtIdent, "Specimen", True)
                AppendSampleXMLElement(xmlJob, xmlDoc, xList, xListBF, xList2, lsLabId, lsExtIdent, "Composite", True)

                'Mode Original(Single)-Specimen(Linked)-Original(Single)-Specimen(Linked)-Composite(All)

            End If
            Dim sResPath As String = ""
            If Not My.Computer.FileSystem.DirectoryExists(sDir) Then
                If MsgBox("Remote directory not found - " & sDir & vbCrLf & "Save to local folder?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    sResPath = Globals.ThisAddIn.Application.ActiveWorkbook.Path & "\" & sOrderNo & "_JRF" & Now.ToString("yyyyMMddHHmmss") & ".XML"
                End If
            Else
                sResPath = sDir & "\" & sOrderNo & "_JRF" & Now.ToString("yyyyMMddHHmmss") & ".XML"
            End If
            If sResPath.Length > 0 Then
                If MsgBox("Export XML?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    xmlDoc.Save(sResPath)
                    MsgBox("Saved to " & sResPath)
                End If
            End If
        End If
    End Sub
    Public Shared Sub AppendSampleXMLElement(ByRef xmlJob As Xml.XmlElement, ByRef xmlDoc As Xml.XmlDocument, ByRef xListSample As Excel.ListObject, ByRef xListSampleBF As Excel.ListObject, ByRef xListScheme As Excel.ListObject, ByRef lsLabId As List(Of String), ByRef lsExtIdent As List(Of String), Optional ByVal sSampleType As String = "Original", Optional ByVal bScheme As Boolean = False)
        Dim xmlSample As Xml.XmlElement
        Dim xmlSampleBF As Xml.XmlElement
        Dim xmlScheme As Xml.XmlElement

        'Dim xmlDoc As Xml.XmlDocument = New Xml.XmlDocument

        Dim sXMLField As String = ""
        'Sample ==================================================================================
        For lSamRow As Integer = 1 To xListSample.ListRows.Count
            If xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("Sample Type").Index).Value2 = sSampleType And xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("Sample Type").Index).Value2.ToString.Trim <> "" Then
                xmlSample = xmlDoc.CreateElement("SAMPLE")
                Dim sCompSamIdent As String = ""
                For lSamCol As Integer = 1 To xListSample.ListColumns.Count

                    sXMLField = ThisAddIn.MapXMLField(xListSample.ListColumns(lSamCol).Name, sSampleType)
                    'Special Handling for non-XML field LabID for HK Sample Break Down
                    If xListSample.ListColumns(lSamCol).Name = "SLIM Lab ID" Then
                        lsLabId.Add(xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("Sample ID").Index).Value2)
                        xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("SLIM Lab ID").Index) = "'" & lsLabId.Count.ToString.PadLeft(3, "0")
                    End If
                    If sXMLField <> "" Then
                        If sXMLField = "SAMPLEIDENT" Then
                            If sSampleType = "Composite" Then
                                If sCompSamIdent = "" Then
                                    'Replace Linked ID with External ID
                                    Dim sLinkedID() As String
                                    Dim lExtID As Integer
                                    sLinkedID = xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("Linked ID").Index).Value2.ToString.Split(",")
                                    Dim sExtID(sLinkedID.GetUpperBound(0)) As String
                                    For lK As Integer = 0 To sLinkedID.GetUpperBound(0)
                                        lExtID = lsExtIdent.IndexOf(sLinkedID(lK)) + 1
                                        sExtID(lK) = lExtID.ToString.PadLeft(3, "0")
                                    Next
                                    Array.Sort(sExtID)
                                    sCompSamIdent = String.Join("+", sExtID)
                                End If
                                xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("SampleIdent").Index) = "'" & sCompSamIdent
                                xmlSample.SetAttribute(sXMLField, sCompSamIdent)
                            Else
                                'Buffer Sample ID into lsExtIdent 
                                lsExtIdent.Add(xListSample.Range.Cells(lSamRow + 1, lSamCol).Value2)
                                sCompSamIdent = lsExtIdent.Count.ToString.PadLeft(3, "0")
                                xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("SampleIdent").Index) = "'" & sCompSamIdent
                                xmlSample.SetAttribute(sXMLField, sCompSamIdent)
                            End If

                        ElseIf sXMLField = "DESCRIPTION_1" Then
                            'Replace Linked ID with External ID
                            If xListSample.Range.Cells(lSamRow + 1, lSamCol).Value2 Is Nothing Then
                                'MsgBox("Error - Missing Linked ID for row#" & CStr(lSamRow + 1))
                            ElseIf xListSample.Range.Cells(lSamRow + 1, lSamCol).Value2.ToString.Trim.Length = 0 Then
                            Else
                                Dim lExtID As Integer

                                lExtID = lsExtIdent.IndexOf(xListSample.Range.Cells(lSamRow + 1, lSamCol).Value2.ToString) + 1
                                xmlSample.SetAttribute(sXMLField, lExtID.ToString.PadLeft(3, "0"))
                            End If

                        ElseIf sXMLField = "DESCRIPTION_2" Then
                            If sSampleType = "Composite" Then
                                'Concat
                                xmlSample.SetAttribute(sXMLField, sCompSamIdent)
                            End If
                        Else
                            xmlSample.SetAttribute(sXMLField, xListSample.Range.Cells(lSamRow + 1, lSamCol).Value2)
                        End If
                    End If
                Next
                If xListSampleBF.ListRows.Count > 0 Then
                    For lSamBFRow As Integer = 1 To xListSampleBF.ListRows.Count
                        If xListSampleBF.Range.Cells(lSamBFRow + 1, xListSampleBF.ListColumns("Sample ID").Index).Value2 = xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("Sample ID").Index).Value2 Then
                            xmlSampleBF = xmlDoc.CreateElement("SAMPLEBIOFIELD")
                            For lK As Integer = 1 To xListSampleBF.ListColumns.Count
                                sXMLField = ThisAddIn.MapXMLField(xListSampleBF.ListColumns(lK).Name)
                                If sXMLField <> "" And sXMLField <> "SAMPLEIDENT" Then
                                    xmlSampleBF.SetAttribute(sXMLField, xListSampleBF.Range.Cells(lSamBFRow + 1, lK).Value2)
                                End If
                            Next
                            xmlSample.AppendChild(xmlSampleBF)
                            'xmlSampleBF = Nothing
                        End If
                    Next
                End If

                If bScheme Then
                    'Extract distinct list of Procedure and Scheme
                    Dim lsValues As List(Of String) = New List(Of String)
                    For lSchRow As Integer = 1 To xListScheme.ListRows.Count
                        If xListScheme.Range.Cells(lSchRow + 1, xListScheme.ListColumns("Sample ID").Index).Value2 = xListSample.Range.Cells(lSamRow + 1, xListSample.ListColumns("Sample ID").Index).Value2 Then
                            If xListScheme.Range.Cells(lSchRow + 1, xListScheme.ListColumns("Procedure").Index).Value2.ToString.Trim = "" Then
                            Else
                                If xListScheme.Range.Cells(lSchRow + 1, xListScheme.ListColumns("Scheme").Index).Value2 Is Nothing Then
                                    lsValues.Add(xListScheme.Range.Cells(lSchRow + 1, xListScheme.ListColumns("Procedure").Index).Value2.ToString.Trim.PadRight(20))
                                Else
                                    lsValues.Add(xListScheme.Range.Cells(lSchRow + 1, xListScheme.ListColumns("Procedure").Index).Value2.ToString.Trim.PadRight(20) & xListScheme.Range.Cells(lSchRow + 1, xListScheme.ListColumns("Scheme").Index).Value2.ToString.Trim.PadRight(20))
                                End If
                            End If

                        End If
                    Next
                    Dim lsResults As List(Of String) = lsValues.Distinct().ToList
                    lsResults.Sort()
                    'Construct Scheme element by concatenate scheme for same procedure code
                    If lsResults.Count > 0 Then
                        Dim sProc As String = lsResults(0).ToString.Substring(0, 20).Trim
                        Dim sSch As String
                        If lsResults(0).ToString.Length > 20 Then
                            sSch = lsResults(0).ToString.Substring(20, 20).Trim
                        Else
                            sSch = ""
                        End If

                        If lsResults.Count > 1 Then
                            For lJ As Integer = 2 To lsResults.Count
                                If sProc <> lsResults(lJ - 1).ToString.Substring(0, 20).Trim Then
                                    xmlScheme = xmlDoc.CreateElement("SCHEME")
                                    xmlScheme.SetAttribute("PROCEDURECODE", sProc)
                                    If sSch.Length > 0 Then
                                        xmlScheme.SetAttribute("INCLUDE", sSch)
                                    End If
                                    xmlSample.AppendChild(xmlScheme)

                                    sProc = lsResults(lJ - 1).ToString.Substring(0, 20).Trim
                                    If lsResults(lJ - 1).ToString.Length > 20 Then
                                        sSch = lsResults(lJ - 1).ToString.Substring(20, 20).Trim
                                    Else
                                        sSch = ""
                                    End If
                                Else
                                    If lsResults(lJ - 1).ToString.Length > 20 Then
                                        sSch = sSch & "~" & lsResults(lJ - 1).ToString.Substring(20, 20).Trim
                                    End If
                                End If
                            Next
                        End If
                        xmlScheme = xmlDoc.CreateElement("SCHEME")
                        xmlScheme.SetAttribute("PROCEDURECODE", sProc)
                        If sSch.Length > 0 Then
                            xmlScheme.SetAttribute("INCLUDE", sSch)
                        End If
                        xmlSample.AppendChild(xmlScheme)
                    End If
                End If

                xmlJob.AppendChild(xmlSample)
            End If
        Next
        '==================================================================================================
    End Sub
    Public Shared Sub ConfigLabcodes()
        Dim frmLC As New frmLabConfig

        frmLC.ShowDialog()

    End Sub
    Public Shared Function IsExcelInEdit() As Boolean
        Dim m As Object = Type.Missing
        Const MENU_ITEM_TYPE As Integer = 1
        Const NEW_MENU As Integer = 18

        Dim oNewMenu As Microsoft.Office.Core.CommandBarControl

        oNewMenu = Globals.ThisAddIn.Application.CommandBars("Worksheet Menu Bar").FindControl(MENU_ITEM_TYPE, NEW_MENU, m, m, True)
        'CommandBarControl oNewMenu = 

        'Application.CommandBars[&quot;Worksheet Menu Bar&quot;].FindControl(
        '     MENU_ITEM_TYPE, //the type of item to look for
        '     NEW_MENU, //the item to look for
        '     m, //the tag property (in this case missing)
        '     m, //the visible property (in this case missing)
        '     true ); //we want to look for it recursively
        '             //so the last argument should be true.

        If oNewMenu IsNot Nothing Then
            If oNewMenu.Enabled Then
                Return False
            Else
                Return True
            End If
        Else
            Return False
        End If
    End Function

    Public Shared Sub fetchUserData(ByRef wsSLIM As CCLAS.CCLASXMLServiceSoapClient, sUDField As String, Optional bUpdate As Boolean = False)
        Dim xmlNode As Xml.XmlNode
        Dim sInitRes As String
        Dim bFound As Boolean = False

        Dim xBook As Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
        Dim xSheet As Excel.Worksheet
        Dim xList As Excel.ListObject

        '- <USERDATA>
        '- <row>
        '  <LABCODE>HKCTS82</LABCODE> 
        '  <DATAFIELD>DESCRIPTION_3</DATAFIELD> 
        '  <DATASEQUENCE>0001</DATASEQUENCE> 
        '  <DATACODE>Main fabric</DATACODE> 
        '  <DATAVALUE>230</DATAVALUE> 
        '  <DATAEXTRA1>Coating</DATAEXTRA1> 
        '  <DATAEXTRA2>36</DATAEXTRA2> 
        '  <USERFIELD1 /> 
        '  <USERFIELD2 /> 
        '  <USERFIELD3 /> 
        '  <USERFIELD4 /> 
        '  <USERFIELD5 /> 
        '  <USERFIELD6 /> 
        '  <USERFIELD7 /> 
        '  <USERFIELD8 /> 
        '  <USERFIELD9 /> 
        '  <USERFIELD10 /> 
        '  </row>


        xSheet = getSheet(xBook, ThisAddIn.UDSHEET, , True)
        xList = getList(xSheet, ThisAddIn.UDLIST)

        'Lookup Excel Ref sheet any sUDField data, if found & bUpdate=False (no need to fetch web service and exit), otherwise download & bUpdate if Yes
        '=====================================================
        For lI As Integer = xList.ListRows.Count - 1 To 1 Step -1
            If xList.Range.Cells(lI + 1, xList.ListColumns(ThisAddIn.UD_DataField).Index).value2 = sUDField Then
                bFound = True
                If bUpdate Then
                    xList.ListRows(lI + 1).Delete()
                Else
                    Exit For
                End If
            End If
        Next

        If bFound And Not bUpdate Then
            Exit Sub
        End If
        '=====================================================

        Try
            'If wsSLIM.Endpoint.Address Is Nothing Then
            wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))

            sInitRes = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
            'End If

            If Not sInitRes.Equals("0") Then
                MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
            Else
                xmlNode = wsSLIM.UserDataFromLIMS(sUDField, "", "")

                For Each xeUD As Xml.XmlElement In xmlNode.SelectNodes("/row")
                    Dim xListRow As Excel.ListRow = xList.ListRows.AddEx
                    xListRow.Range.Cells(1, ThisAddIn.UD_DataField) = xeUD.Item("DATAFIELD").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_DataSeq) = xeUD.Item("DATASEQUENCE").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_DataCode) = xeUD.Item("DATACODE").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_DataValue) = xeUD.Item("DATAVALUE").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_DataExtra1) = xeUD.Item("DATAEXTRA1").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_DataExtra2) = xeUD.Item("DATAEXTRA2").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF1) = xeUD.Item("USERFIELD1").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF2) = xeUD.Item("USERFIELD2").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF3) = xeUD.Item("USERFIELD3").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF4) = xeUD.Item("USERFIELD4").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF5) = xeUD.Item("USERFIELD5").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF6) = xeUD.Item("USERFIELD6").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF7) = xeUD.Item("USERFIELD7").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF8) = xeUD.Item("USERFIELD8").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF9) = xeUD.Item("USERFIELD9").InnerXml
                    xListRow.Range.Cells(1, ThisAddIn.UD_UF10) = xeUD.Item("USERFIELD10").InnerXml
                Next

            End If
        Catch ex As Exception
        End Try

    End Sub
End Class
