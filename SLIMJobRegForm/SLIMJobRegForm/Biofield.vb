Public Class Biofield
    Private sSampleIdent As String
    Private sBiofield As String
    Private sBioValue As String
    Private sBioUValue As String
    Private lIsActive As Integer
    Private lSeq As Integer
    Private lType As Integer
    Private lListRowNo As Integer

    Property SampleIdent() As String
        Get
            SampleIdent = sSampleIdent
        End Get
        Set(ByVal value As String)
            If value <> "" Then
                sSampleIdent = value
            Else
                sSampleIdent = "*"
            End If
        End Set
    End Property

    Property Biofield As String
        Get
            Biofield = sBiofield
        End Get
        Set(value As String)
            sBiofield = value
        End Set
    End Property

    Property BioValue As String
        Get
            BioValue = sBioValue
        End Get
        Set(value As String)
            sBioValue = value
        End Set
    End Property

    Property BioUValue As String
        Get
            BioUValue = sBioUValue
        End Get
        Set(value As String)
            sBioUValue = value
        End Set
    End Property

    Property IsActive As Boolean
        Get
            IsActive = IIf(IsActive = 0, False, True)
        End Get
        Set(value As Boolean)
            lIsActive = IIf(value = False, 0, 1)
        End Set
    End Property

    Property ReportActive As Integer
        Get
            ReportActive = lIsActive
        End Get
        Set(value As Integer)
            lIsActive = value
        End Set
    End Property

    Property Seq As Integer
        Get
            Seq = lSeq
        End Get
        Set(value As Integer)
            lSeq = value
        End Set
    End Property

    Property Type As Integer
        Get
            Type = lType
        End Get
        Set(value As Integer)
            '1=String TextBox
            '2=List ComboBox
            '3=DateTime DateTimePicker
            lType = value
        End Set
    End Property

    Property ListRowNo As Integer
        Get
            ListRowNo = lListRowNo
        End Get
        Set(value As Integer)
            lListRowNo = value
        End Set
    End Property

    Public Sub New()
        Me.Type = 1
    End Sub
    Public Sub New(sBiofield As String)
        Me.Type = 1
        Me.Biofield = sBiofield
        Me.IsActive = 0
    End Sub
    Public Sub New(sSampleID As String, sBiofield As String)
        Me.Type = 1
        Me.SampleIdent = sSampleID
        Me.Biofield = sBiofield
        Me.IsActive = 0
    End Sub

End Class
