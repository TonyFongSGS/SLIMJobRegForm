Namespace SLIMObj
    Public Class Scheme
        Private lListRowNo As Integer
        Private sProcedureCode As String
        Private sProcedureDesc As String
        Private sSchemeCode As String
        Private sSchemeDesc As String
        Private sSchemeMethod As String
        Private sSchemeName As String

        Property ListRowNo() As Integer
            Get
                ListRowNo = lListRowNo
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then
                    lListRowNo = 1
                Else
                    lListRowNo = value
                End If
            End Set
        End Property

        Property ProcedureCode As String
            Get
                ProcedureCode = sProcedureCode
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sProcedureCode = ""
                Else
                    sProcedureCode = value
                End If
            End Set
        End Property

        Property ProcedureDesc As String
            Get
                ProcedureDesc = sProcedureDesc
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sProcedureDesc = ""
                Else
                    sProcedureDesc = value
                End If

            End Set
        End Property

        Property SchemeCode As String
            Get
                SchemeCode = sSchemeCode
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sSchemeCode = ""
                Else
                    sSchemeCode = value
                End If

            End Set
        End Property

        Property SchemeDesc As String
            Get
                SchemeDesc = sSchemeDesc
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sSchemeDesc = ""
                Else
                    sSchemeDesc = value
                End If
            End Set
        End Property

        Property SchemeMethod As String
            Get
                SchemeMethod = sSchemeMethod
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sSchemeMethod = ""
                Else
                    sSchemeMethod = value
                End If

            End Set
        End Property

        Property SchemeName As String
            Get
                SchemeName = sSchemeName
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sSchemeName = ""
                Else
                    sSchemeName = value
                End If

            End Set
        End Property
    End Class
    Class ProcedureSubGroup
        Private sCode As String

        Property Code As String
            Get
                Code = sCode
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sCode = ""
                Else
                    sCode = value
                End If

            End Set
        End Property
    End Class
    Class ProcedureGroup
        Private sCode As String
        Private oSubGroup(0) As ProcedureSubGroup

        Property Code As String
            Get
                Code = sCode
            End Get
            Set(value As String)
                If value Is Nothing Then
                    sCode = ""
                Else
                    sCode = value
                End If

            End Set
        End Property
        'Property SubGroup(ByVal i As Integer) As ProcedureSubGroup
        '    Get
        '        SubGroup = oSubGroup(i)
        '    End Get
        '    Set(value As ProcedureSubGroup)
        '        oSubGroup(i) = value
        '    End Set
        'End Property
        Property SubGroups As ProcedureSubGroup()
            Get
                SubGroups = oSubGroup
            End Get
            Set(value As ProcedureSubGroup())
                oSubGroup = value
            End Set
        End Property
        Public Sub New()
        End Sub

    End Class
End Namespace

