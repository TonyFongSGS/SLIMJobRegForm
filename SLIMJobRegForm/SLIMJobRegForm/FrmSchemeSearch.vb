Public Class FrmSchemeSearch
    Private wsSLIM As New CCLAS.CCLASXMLServiceSoapClient
    Private cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)
    Private sInitRes As String = ""
    Private bProcQueried As Boolean = False

    Private lsProcedureGroup As New List(Of SLIMObj.ProcedureGroup)
    Public lsSearchProcScheme As New List(Of SLIMObj.Scheme)


    Private Sub FrmSchemeSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
  
    End Sub

    Private Sub cmbProcedureGroup_DropDown(sender As Object, e As EventArgs) Handles cmbProcedureGroup.DropDown
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If Not bProcQueried Then

            wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))

            Try
                sInitRes = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
                If sInitRes <> "0" Then
                    MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
                Else
                    Dim xNode As Xml.XmlNode
                    bProcQueried = True
                    xNode = wsSLIM.ProcregGroupDataFromLIMS("%", "")

                    If xNode.InnerXml.Length > 0 Then

                        For Each xeUserData As Xml.XmlElement In xNode.SelectNodes("/row")
                            'MsgBox(xeUserData.InnerText)

                            If lsProcedureGroup.Count = 0 Then
                                lsProcedureGroup.Add(New SLIMObj.ProcedureGroup With {.Code = xeUserData.Item("DATACODE").InnerXml})
                                lsProcedureGroup(lsProcedureGroup.Count - 1).SubGroups(0) = New SLIMObj.ProcedureSubGroup With {.Code = xeUserData.Item("DATAVALUE").InnerXml}
                            Else
                                'Search for existence 
                                Dim lIndex As Integer = 0
                                lIndex = lsProcedureGroup.FindIndex(Function(m As SLIMObj.ProcedureGroup) m.Code = xeUserData.Item("DATACODE").InnerText)
                                If lIndex < 0 Then
                                    'Add
                                    lsProcedureGroup.Add(New SLIMObj.ProcedureGroup With {.Code = xeUserData.Item("DATACODE").InnerXml})
                                    lsProcedureGroup(lsProcedureGroup.Count - 1).SubGroups(0) = New SLIMObj.ProcedureSubGroup With {.Code = xeUserData.Item("DATAVALUE").InnerXml}
                                Else
                                    'Update 
                                    ReDim Preserve lsProcedureGroup(lIndex).SubGroups(lsProcedureGroup(lIndex).SubGroups.Count)
                                    lsProcedureGroup(lIndex).SubGroups(lsProcedureGroup(lIndex).SubGroups.Count - 1) = New SLIMObj.ProcedureSubGroup With {.Code = xeUserData.Item("DATAVALUE").InnerXml}
                                End If

                            End If
                        Next
                    End If

                End If
            Catch ex As Exception

            End Try


            If lsProcedureGroup.Count > 0 Then
                cmbProcedureGroup.Items.Clear()
                For lI As Integer = 0 To lsProcedureGroup.Count - 1
                    cmbProcedureGroup.Items.Add(lsProcedureGroup(lI).Code)

                Next
            End If
        End If
        Me.Cursor = Me.DefaultCursor
    End Sub

    Private Sub cmbProcedureGroup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProcedureGroup.SelectedIndexChanged
        cmbProcedureSubGroup.Text = ""
        If lsProcedureGroup.Count > 0 Then

            cmbProcedureSubGroup.Items.Clear()
            Dim lIndex As Integer = lsProcedureGroup.FindIndex(Function(m As SLIMObj.ProcedureGroup) m.Code = cmbProcedureGroup.SelectedItem)
            If lIndex >= 0 Then
                For lJ As Integer = 0 To lsProcedureGroup(lIndex).SubGroups.Count - 1
                    cmbProcedureSubGroup.Items.Add(lsProcedureGroup(lIndex).SubGroups(lJ).Code)
                Next
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor

        Try
            If sInitRes = "" Then
                wsSLIM.Endpoint.Address = New ServiceModel.EndpointAddress(New Uri(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebService").Value))
                sInitRes = wsSLIM.InitialiseSession(cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceLabcode").Value, cfgSLIM.AppSettings.Settings(Globals.Ribbons.Ribbon1.cmbLabcode.Text & "_WebServiceSystem").Value)
            End If
            If sInitRes <> "0" Then
                MsgBox("Initial Session Error - " & wsSLIM.Endpoint.Address.ToString)
            Else
                Dim xNode As Xml.XmlNode

                Dim sQuery As String = BuildQuery()

                'User request to not clear the result and acumulate them
                'lsvSearchProcScheme.Items.Clear()

                xNode = wsSLIM.ProcedureDataFromLIMS("", "%", True, "PROCEDURECODE,DESCRIPTION,USERFIELD1,USERFIELD2,USERFIELD3", sQuery)

                If xNode.InnerXml.ToString.Length > 0 Then
                    Dim lsProc As New List(Of Windows.Forms.ListViewItem)
                    For Each xeProc As Xml.XmlElement In xNode.SelectNodes("/row")
                        lsProc.Add(New Windows.Forms.ListViewItem(New String() {xeProc.Item("PROCEDURECODE").InnerXml, _
                                                                                xeProc.Item("DESCRIPTION").InnerXml, _
                                                                                xeProc.Item("USERFIELD1").InnerXml, _
                                                                                xeProc.Item("USERFIELD2").InnerXml, _
                                                                                xeProc.Item("USERFIELD3").InnerXml}))
                    Next
                    For Each xeSch As Xml.XmlElement In xNode.SelectNodes("/PROCEDURE_SCHEME/row")
                        Dim sPD As String = lsProc.Find(Function(value As Windows.Forms.ListViewItem) value.SubItems(0).Text = xeSch.Item("PROCEDURECODE").InnerXml).SubItems(1).Text

                        lsSearchProcScheme.Add(New SLIMObj.Scheme With {.ProcedureCode = xeSch.Item("PROCEDURECODE").InnerXml, _
                                                                        .ProcedureDesc = sPD, _
                                                                        .SchemeCode = xeSch.Item("SCH_CODE").InnerXml, _
                                                                        .SchemeDesc = xeSch.Item("DESCRIPTION").InnerXml, _
                                                                        .SchemeMethod = xeSch.Item("METHODCODE").InnerXml, _
                                                                        .SchemeName = xeSch.Item("SCHEMENAME").InnerXml})
                    Next
                    lsvSearchProcScheme.Items.AddRange(lsProc.ToArray)
                End If

            End If
        Catch ex As Exception

        End Try
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
    Private Function BuildQuery() As String
        Dim sb As New StringBuilder

        sb.Append("1=1")
        If cmbProcedureGroup.Text.Trim.Length > 0 Then
            sb.Append(" AND USERFIELD1 like '" & cmbProcedureGroup.Text & "'")
        End If

        If cmbProcedureSubGroup.Text.Trim.Length > 0 Then
            sb.Append(" AND USERFIELD2 like '" & cmbProcedureSubGroup.Text & "'")
        End If

        If ckbProcNoteEmpty.Checked Then
            sb.Append(" AND USERFIELD3 like ''")
        ElseIf txbProcedureNote.Text.ToString.ToString.Trim().Length > 0 Then
            sb.Append(" AND USERFIELD3 like '" & txbProcedureNote.Text.ToString & "'")
        End If

        If txbProcedureDesc.Text.ToString.ToString.Trim().Length > 0 Then
            sb.Append(" AND DESCRIPTION like '" & txbProcedureDesc.Text.ToString & "'")
        End If

        If txbProcedureCode.Text.ToString.ToString.Trim().Length > 0 Then
            sb.Append(" AND PROCEDURECODE like '" & txbProcedureCode.Text.ToString & "'")
        End If

        BuildQuery = sb.ToString

    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub btnClearResult_Click(sender As Object, e As EventArgs) Handles btnClearResult.Click
        lsvSearchProcScheme.Items.Clear()
    End Sub

    Private Sub btnSelectAll_Click(sender As Object, e As EventArgs) Handles btnSelectAll.Click
        For lI = 0 To lsvSearchProcScheme.Items.Count - 1
            lsvSearchProcScheme.Items(lI).Checked = True
        Next
    End Sub
    'Private Sub btnListSchemeCheck_Click(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles btnListSchemeCheck.Click
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        ContextMenuStrip1.Show(btnListSchemeCheck, e.Location)

    '    End If
    'End Sub
    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        For lI = 0 To lsvSearchProcScheme.Items.Count - 1
            lsvSearchProcScheme.Items(lI).Checked = False
        Next
    End Sub

    Private Sub ckbProcNoteEmpty_CheckedChanged(sender As Object, e As EventArgs) Handles ckbProcNoteEmpty.CheckedChanged
        If ckbProcNoteEmpty.Checked Then
            txbProcedureNote.Enabled = False
        Else
            txbProcedureNote.Enabled = True
        End If

    End Sub

    Private Sub lsvSearchProcScheme_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles lsvSearchProcScheme.KeyUp
        If e.KeyValue = Windows.Forms.Keys.Delete Then
            If MsgBox("Delete this procedure <code> ?".Replace("<code>", lsvSearchProcScheme.SelectedItems(0).Text), MsgBoxStyle.OkCancel) = MsgBoxResult.Ok Then
                lsvSearchProcScheme.SelectedItems(0).Remove()
            End If
        End If
    End Sub


    Private Sub lsvSearchProcScheme_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsvSearchProcScheme.SelectedIndexChanged

    End Sub
End Class