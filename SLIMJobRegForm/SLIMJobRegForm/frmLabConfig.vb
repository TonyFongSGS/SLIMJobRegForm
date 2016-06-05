Public Class frmLabConfig
    Private cfgSLIM As Configuration.Configuration = Configuration.ConfigurationManager.OpenExeConfiguration(Configuration.ConfigurationUserLevel.None)

    Private Sub DataGridView1_CellContentClick(sender As Object, e As Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub frmLabConfig_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim sLabcodes() As String = cfgSLIM.AppSettings.Settings("Labcodes").Value.Split(",")
        If sLabcodes.Length > 0 Then
            For lI As Integer = 0 To sLabcodes.Length - 1
                lsbLabcodes.Items.Add(sLabcodes(lI))

            Next
            lsbLabcodes.SelectedIndex = 0
        Else

        End If

    End Sub

    Private Sub lsbLabcodes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbLabcodes.SelectedIndexChanged
        RefreshSetting()
    End Sub
    Private Sub RefreshSetting()
        Dim lsSettings As New List(Of Windows.Forms.ListViewItem)
        lsvSettings.Items.Clear()
        For Each appSetting As String In cfgSLIM.AppSettings.Settings.AllKeys
            If appSetting.StartsWith(lsbLabcodes.SelectedItem.ToString & "_") Then
                lsSettings.Add(New Windows.Forms.ListViewItem(New String() {appSetting.Substring(lsbLabcodes.SelectedItem.ToString.Length + 1), cfgSLIM.AppSettings.Settings(appSetting).Value}))
            End If
        Next

        lsvSettings.Items.AddRange(lsSettings.ToArray)

    End Sub

End Class