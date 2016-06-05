Public Class ucBiofield
    Public Event txtFieldValueTextChanged(sender As Object, e As EventArgs)
    Public Event cmbFieldValueSelectedIndexChanged(sender As Object, e As EventArgs)
    Public Event dtpFieldValueValueChanged(sender As Object, e As EventArgs)
    Public Event chkRepActiveCheckedChanged(sender As Object, e As EventArgs)
    Public Event cmbFieldValueTextChanged(sender As Object, e As EventArgs)
    'Public Shared FieldType As Integer

    Private Sub txtFieldValue_TextChanged(sender As Object, e As EventArgs) Handles txtFieldValue.TextChanged
        RaiseEvent txtFieldValueTextChanged(sender, e)
    End Sub

    Private Sub cmbFieldValue_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFieldValue.SelectedIndexChanged
        RaiseEvent cmbFieldValueSelectedIndexChanged(sender, e)
    End Sub

    Private Sub cmbFieldValue_TextChanged(sender As Object, e As EventArgs) Handles cmbFieldValue.TextChanged
        RaiseEvent cmbFieldValueTextChanged(sender, e)
    End Sub

    Private Sub dtpFieldValue_ValueChanged(sender As Object, e As EventArgs) Handles dtpFieldValue.ValueChanged
        RaiseEvent dtpFieldValueValueChanged(sender, e)
    End Sub

    Private Sub chkRepActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkRepActive.CheckedChanged
        RaiseEvent chkRepActiveCheckedChanged(sender, e)
    End Sub

    Private Sub lblFieldName_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles lblFieldName.MouseDown
        'Me.BackColor = Drawing.Color.Yellow
    End Sub

    Private Sub lblFieldName_MouseHover(sender As Object, e As EventArgs) Handles lblFieldName.MouseHover
        lblFieldName.BringToFront()
    End Sub

    Private Sub lblFieldName_MouseLeave(sender As Object, e As EventArgs) Handles lblFieldName.MouseLeave
        lblFieldName.SendToBack()
    End Sub
    Public Sub SetField(FieldName As String, Optional FieldValue As String = "", Optional lReportActive As Integer = 0)
        Dim lFieldType As Integer

        If FieldName = "" Then
            'Me.Hide 
            Me.Visible = False
        Else
            Me.Visible = True
            Me.BackColor = System.Drawing.SystemColors.Control
            lblFieldName.Text = FieldName
            'FieldType = CheckFieldType(FieldName)
            'FieldType = ConvertBioFieldTypeToInt(GetBiofieldFieldValue(FieldName, "DATAVALUE"))
            lFieldType = ConvertBioFieldTypeToInt(GetBiofieldFieldValue(FieldName, "DATAVALUE"))
            RemoveHandler chkRepActive.CheckedChanged, AddressOf chkRepActive_CheckedChanged
            chkRepActive.Checked = IIf(lReportActive = 0, False, True)
            AddHandler chkRepActive.CheckedChanged, AddressOf chkRepActive_CheckedChanged
            Select Case lFieldType
                Case 1  '= "S"
                    RemoveHandler txtFieldValue.TextChanged, AddressOf txtFieldValue_TextChanged
                    txtFieldValue.Text = FieldValue
                    AddHandler txtFieldValue.TextChanged, AddressOf txtFieldValue_TextChanged
                    txtFieldValue.BringToFront()
                    cmbFieldValue.TabStop = False
                    dtpFieldValue.TabStop = False
                Case 2 '= "C" or "L"
                    RemoveHandler cmbFieldValue.SelectedIndexChanged, AddressOf cmbFieldValue_SelectedIndexChanged
                    LoadComboboxList(GetBiofieldFieldValue(FieldName, "DATAEXTRA2"))
                    cmbFieldValue.Text = FieldValue
                    AddHandler cmbFieldValue.SelectedIndexChanged, AddressOf cmbFieldValue_SelectedIndexChanged
                    cmbFieldValue.BringToFront()
                    txtFieldValue.TabStop = False
                    dtpFieldValue.TabStop = False
                Case 3 '= "D"
                    RemoveHandler dtpFieldValue.ValueChanged, AddressOf dtpFieldValue_ValueChanged
                    dtpFieldValue.Text = FieldValue
                    AddHandler dtpFieldValue.ValueChanged, AddressOf dtpFieldValue_ValueChanged
                    dtpFieldValue.BringToFront()
                    cmbFieldValue.TabStop = False
                    txtFieldValue.TabStop = False
            End Select

            'Highlight field here instead of in form
            HighlightField()
        End If
    End Sub
    Public Function CheckFieldType(FieldName As String) As Integer
        CheckFieldType = 1
    End Function

    Private Sub LoadComboboxList(sList As String)
        Dim sValues() As String
        cmbFieldValue.Items.Clear()
        If sList.Trim.Length > 0 Then
            sValues = sList.Split(",")
            For lI As Integer = 0 To sValues.Count - 1
                cmbFieldValue.Items.Add(sValues(lI))
            Next
        End If

    End Sub
    Private Sub ucBiofield_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        'Me.BackColor = Drawing.Color.Aqua
        If Me.BackColor <> System.Drawing.SystemColors.Highlight Then
            Me.BackColor = System.Drawing.SystemColors.Highlight
        Else
            Me.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub

    Private Sub ucBiofield_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        'Me.BackColor = Drawing.Color.Yellow
    End Sub

    Private Sub lblFieldName_Click(sender As Object, e As EventArgs) Handles lblFieldName.Click
        If Me.BackColor <> System.Drawing.SystemColors.Highlight Then
            Me.BackColor = System.Drawing.SystemColors.Highlight
        Else
            Me.BackColor = System.Drawing.SystemColors.Control
        End If
    End Sub
    Private Function GetBiofieldFieldValue(sBiofieldCode As String, sGetField As String) As String
        Dim xBook As Excel.Workbook = Globals.ThisAddIn.Application.ActiveWorkbook
        Dim xSheet As Excel.Worksheet
        Dim xList As Excel.ListObject

        xSheet = ThisAddIn.getSheet(xBook, ThisAddIn.UDSHEET)
        xList = ThisAddIn.getList(xSheet, ThisAddIn.UDLIST)

        For lI As Integer = 1 To xList.ListRows.Count
            If xList.Range.Cells(lI + 1, ThisAddIn.UD_DataCode).value2 IsNot Nothing Then
                If xList.Range.Cells(lI + 1, ThisAddIn.UD_DataCode).value2.ToString.ToUpper.Equals(sBiofieldCode.ToUpper) Then
                    Return xList.Range.Cells(lI + 1, xList.ListColumns(sGetField).Index).value2.ToString
                    Exit Function
                End If
            End If

        Next
        Return ""
    End Function
    Private Function ConvertBioFieldTypeToInt(sType) As Integer
        Select Case sType
            Case "S"
                Return 1
            Case "C", "L"
                Return 2
            Case "D"
                Return 3
            Case Else
                Return 1
        End Select
    End Function
    'Private Function GetValue() As String
    '    Select Case FieldType
    '        Case 1 '"S"
    '            Return 1
    '        Case 2 '"C", "L"
    '            Return 2
    '        Case 3 '"D"
    '            Return 3
    '        Case Else
    '            Return 1
    '    End Select
    'End Function
    Private Sub ucBiofield_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub HighlightField()
        Dim cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)

        Dim sFields As String = cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_SampleBioFieldFieldHighlight").Value()
        sFields = "," & sFields.ToUpper & ","

        If sFields.Contains("," & lblFieldName.Text.ToUpper & ",") Then
            txtFieldValue.BackColor = System.Drawing.Color.LightPink
            cmbFieldValue.BackColor = System.Drawing.Color.LightPink
            dtpFieldValue.BackColor = System.Drawing.Color.LightPink
        Else
            txtFieldValue.BackColor = System.Drawing.SystemColors.Window
            cmbFieldValue.BackColor = System.Drawing.SystemColors.Window
            dtpFieldValue.BackColor = System.Drawing.SystemColors.Window
        End If
    End Sub

End Class
