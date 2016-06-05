'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.18444
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On


Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The Labcodes Configuration Section.
    '''</summary>
    Partial Public Class Labcodes
        Inherits Global.System.Configuration.ConfigurationSection
        
        #Region "Singleton Instance"
        '''<summary>
        '''The XML name of the Labcodes Configuration Section.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const LabcodesSectionName As String = "labcodes"
        
        '''<summary>
        '''Gets the Labcodes instance.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Shared ReadOnly Property Instance() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes
            Get
                Return CType(Global.System.Configuration.ConfigurationManager.GetSection(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes.LabcodesSectionName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes)
            End Get
        End Property
        #End Region
        
        #Region "Xmlns Property"
        '''<summary>
        '''The XML name of the <see cref="Xmlns"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const XmlnsPropertyName As String = "xmlns"
        
        '''<summary>
        '''Gets the XML namespace of this Configuration Section.
        '''</summary>
        '''<remarks>
        '''This property makes sure that if the configuration file contains the XML namespace,
        '''the parser doesn't throw an exception because it encounters the unknown "xmlns" attribute.
        '''</remarks>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes.XmlnsPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public ReadOnly Property Xmlns() As String
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes.XmlnsPropertyName),String)
            End Get
        End Property
        #End Region
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "Labcode Property"
        '''<summary>
        '''The XML name of the <see cref="Labcode"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const LabcodePropertyName As String = "labcode"
        
        '''<summary>
        '''Gets or sets the Labcode.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The Labcode."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes.LabcodePropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property Labcode() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes.LabcodePropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcodes.LabcodePropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The Labcode Configuration Element.
    '''</summary>
    Partial Public Class Labcode
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "name Property"
        '''<summary>
        '''The XML name of the <see cref="name"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const namePropertyName As String = "name"
        
        '''<summary>
        '''Gets or sets the name.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The name."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.namePropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property name() As String
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.namePropertyName),String)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.namePropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "description Property"
        '''<summary>
        '''The XML name of the <see cref="description"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const descriptionPropertyName As String = "description"
        
        '''<summary>
        '''Gets or sets the description.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The description."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.descriptionPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property description() As String
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.descriptionPropertyName),String)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.descriptionPropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "active Property"
        '''<summary>
        '''The XML name of the <see cref="active"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const activePropertyName As String = "active"
        
        '''<summary>
        '''Gets or sets the active.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The active."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.activePropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property active() As Boolean
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.activePropertyName),Boolean)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.activePropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "General Property"
        '''<summary>
        '''The XML name of the <see cref="General"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const GeneralPropertyName As String = "general"
        
        '''<summary>
        '''Gets or sets the General.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The General."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.GeneralPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property General() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.General
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.GeneralPropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.General)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.GeneralPropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "Sample Property"
        '''<summary>
        '''The XML name of the <see cref="Sample"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const SamplePropertyName As String = "sample"
        
        '''<summary>
        '''Gets or sets the Sample.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The Sample."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.SamplePropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property Sample() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.Sample
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.SamplePropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.Sample)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Labcode.SamplePropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The General Configuration Element.
    '''</summary>
    Partial Public Class General
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "Register Property"
        '''<summary>
        '''The XML name of the <see cref="Register"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const RegisterPropertyName As String = "register"
        
        '''<summary>
        '''Gets or sets the Register.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The Register."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.RegisterPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property Register() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.Register
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.RegisterPropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.Register)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.RegisterPropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "TRF Property"
        '''<summary>
        '''The XML name of the <see cref="TRF"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const TRFPropertyName As String = "tRF"
        
        '''<summary>
        '''Gets or sets the TRF.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The TRF."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.TRFPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property TRF() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.TRF
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.TRFPropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.TRF)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.TRFPropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "WebService Property"
        '''<summary>
        '''The XML name of the <see cref="WebService"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const WebServicePropertyName As String = "webService"
        
        '''<summary>
        '''Gets or sets the WebService.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The WebService."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.WebServicePropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property WebService() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.WebService
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.WebServicePropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.WebService)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.General.WebServicePropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The Register Configuration Element.
    '''</summary>
    Partial Public Class Register
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "path Property"
        '''<summary>
        '''The XML name of the <see cref="path"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const pathPropertyName As String = "path"
        
        '''<summary>
        '''Gets or sets the path.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The path."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Register.pathPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property path() As String
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Register.pathPropertyName),String)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Register.pathPropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The TRF Configuration Element.
    '''</summary>
    Partial Public Class TRF
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "path Property"
        '''<summary>
        '''The XML name of the <see cref="path"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const pathPropertyName As String = "path"
        
        '''<summary>
        '''Gets or sets the path.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The path."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.TRF.pathPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property path() As String
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.TRF.pathPropertyName),String)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.TRF.pathPropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The WebService Configuration Element.
    '''</summary>
    Partial Public Class WebService
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "url Property"
        '''<summary>
        '''The XML name of the <see cref="url"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const urlPropertyName As String = "url"
        
        '''<summary>
        '''Gets or sets the url.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The url."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.WebService.urlPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property url() As String
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.WebService.urlPropertyName),String)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.WebService.urlPropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The Sample Configuration Element.
    '''</summary>
    Partial Public Class Sample
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "ClientDesc Property"
        '''<summary>
        '''The XML name of the <see cref="ClientDesc"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const ClientDescPropertyName As String = "clientDesc"
        
        '''<summary>
        '''Gets or sets the ClientDesc.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The ClientDesc."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Sample.ClientDescPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property ClientDesc() As Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Sample.ClientDescPropertyName),Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.Sample.ClientDescPropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace

Namespace SLIMJobRegFormConfig
    
    '''<summary>
    '''The ClientDesc Configuration Element.
    '''</summary>
    Partial Public Class ClientDesc
        Inherits Global.System.Configuration.ConfigurationElement
        
        #Region "IsReadOnly override"
        '''<summary>
        '''Gets a value indicating whether the element is read-only.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Public Overrides Function IsReadOnly() As Boolean
            Return false
        End Function
        #End Region
        
        #Region "CharacterDigit Property"
        '''<summary>
        '''The XML name of the <see cref="CharacterDigit"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const CharacterDigitPropertyName As String = "characterDigit"
        
        '''<summary>
        '''Gets or sets the CharacterDigit.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The CharacterDigit."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc.CharacterDigitPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property CharacterDigit() As Integer
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc.CharacterDigitPropertyName),Integer)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc.CharacterDigitPropertyName) = value
            End Set
        End Property
        #End Region
        
        #Region "NumberDigit Property"
        '''<summary>
        '''The XML name of the <see cref="NumberDigit"/> property.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0")>  _
        Friend Const NumberDigitPropertyName As String = "numberDigit"
        
        '''<summary>
        '''Gets or sets the NumberDigit.
        '''</summary>
        <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("ConfigurationSectionDesigner.CsdFileGenerator", "2.0.1.0"),  _
         Global.System.ComponentModel.DescriptionAttribute("The NumberDigit."),  _
         Global.System.Configuration.ConfigurationPropertyAttribute(Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc.NumberDigitPropertyName, IsRequired:=false, IsKey:=false, IsDefaultCollection:=false)>  _
        Public Overridable Property NumberDigit() As Integer
            Get
                Return CType(MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc.NumberDigitPropertyName),Integer)
            End Get
            Set
                MyBase.Item(Global.SLIMJobRegForm.SLIMJobRegFormConfig.ClientDesc.NumberDigitPropertyName) = value
            End Set
        End Property
        #End Region
    End Class
End Namespace