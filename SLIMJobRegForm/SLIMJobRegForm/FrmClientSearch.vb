Public Class FrmClientSearch
    Private cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)
    Private wsSLIM As New CCLAS.CCLASXMLServiceSoapClient
    Private sInitRes As String = ""
    Private xmlNode As Xml.XmlNode
    Public lsClient As New List(Of CCLAS.Client)

    Private Sub FrmClientSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        

    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        If txbClientName.Text.Trim("%").Length < 3 Then
            MsgBox("Please input name with 3 character or more (support % as wild card).")
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


                    xmlNode = wsSLIM.ClientDataFromLIMS("%", "", "CLI_NAME like '" & txbClientName.Text & "'")
                    If xmlNode Is Nothing Then
                        MsgBox("Error")
                    ElseIf xmlNode.OuterXml.Trim.Length = 0 Or xmlNode.OuterXml.Equals("<CLIENT xmlns=""""></CLIENT>") Then
                        MsgBox("No client name matched. Please input name with 3 character or more (support % as wild card).")
                    Else
                        Dim lsClient As New List(Of Windows.Forms.ListViewItem)

                        For Each xeClient As Xml.XmlElement In xmlNode.SelectNodes("/row")

                            lsClient.Add(New Windows.Forms.ListViewItem(New String() {xeClient.Item("LABCODE").InnerXml, _
                                                                                      xeClient.Item("CLI_CODE").InnerXml, _
                                                                                      xeClient.Item("CLI_NAME").InnerXml, _
                                                                                      xeClient.Item("ADDRESS1").InnerXml, _
                                                                                       xeClient.Item("ADDRESS2").InnerXml, _
                                                                                       xeClient.Item("ADDRESS3").InnerXml, _
                                                                                       xeClient.Item("STATE").InnerXml, _
                                                                                       xeClient.Item("POSTCODE").InnerXml, _
                                                                                       xeClient.Item("COUNTRY").InnerXml, _
                                                                                       xeClient.Item("TELEPHONE").InnerXml, _
                                                                                       xeClient.Item("FAX").InnerXml, _
                                                                                       xeClient.Item("EMAIL").InnerXml, _
                                                                                       xeClient.Item("USERFIELD13").InnerXml, _
                                                                                       xeClient.Item("USERFIELD14").InnerXml}))
                        Next
                        lsvClientSearch.Items.Clear()
                        lsvClientSearch.Items.AddRange(lsClient.ToArray)

                    End If
                End If
            Catch ex As Exception
                sInitRes = ""
            End Try

        End If
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If lsvClientSearch.SelectedItems.Count = 1 Then
            For Each xeClient As Xml.XmlElement In xmlNode.SelectNodes("/row")
                'MsgBox(xeClient.Item("CLI_NAME").InnerXml)
                If lsvClientSearch.SelectedItems(0).SubItems(0).Text = xeClient.Item("LABCODE").InnerXml And _
                    lsvClientSearch.SelectedItems(0).SubItems(1).Text = xeClient.Item("CLI_CODE").InnerXml Then
                    lsClient.Add(New CCLAS.Client With {.Accnt_Code = xeClient.Item("LABCODE").InnerXml, _
                                                        .CliCode = xeClient.Item("CLI_CODE").InnerXml, _
                                                        .Cli_Name = xeClient.Item("CLI_NAME").InnerXml})
                End If

            Next

            For Each xeClientContact As Xml.XmlElement In xmlNode.SelectNodes("/CLIENT_CONTACT/row")

                For lI As Integer = 0 To lsClient.Count - 1
                    If lsClient(lI).Accnt_Code = xeClientContact.Item("LABCODE").InnerXml And lsClient(lI).CliCode = xeClientContact.Item("CLI_CODE").InnerXml Then
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
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
        
    End Sub
End Class