Public Class FrmHelp

    Private Sub FrmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim oLink As Windows.Forms.LinkLabel.Link

        lnkChangeLog.Links.Clear()
        lnkSharepoint.Links.Clear()
        lnkUserDoc.Links.Clear()

        lnkSharepoint.Links.Add(0, 100, "http://cnsites01.sgs.net/sites/CTSSLIMSupport/Shared%20Documents/Forms/AllItems.aspx?RootFolder=%2fsites%2fCTSSLIMSupport%2fShared%20Documents%2fVF%5fEcVision%2fJobRegForm&FolderCTID=&View=%7b21974CAC%2d44CC%2d4E7F%2dA526%2dB39007B53AA7%7d")
        lnkUserDoc.Links.Add(0, 100, "http://cnsites01.sgs.net/sites/CTSSLIMSupport/Shared%20Documents/VF_EcVision/JobRegForm/JobRegForm_Instruction.pdf")
        lnkChangeLog.Links.Add(0, 100, "http://cnsites01.sgs.net/sites/CTSSLIMSupport/Shared%20Documents/VF_EcVision/JobRegForm/SLIM%20Job%20Reg%20Form%20-%20Change%20Log.pdf")

    End Sub

    Private Sub lnkSharepoint_LinkClicked(sender As Object, e As Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSharepoint.LinkClicked, lnkChangeLog.LinkClicked, lnkUserDoc.LinkClicked
        System.Diagnostics.Process.Start(e.Link.LinkData.ToString)

    End Sub
End Class