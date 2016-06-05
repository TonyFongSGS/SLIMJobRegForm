<?xml version="1.0" encoding="utf-8"?>
<configurationSectionModel xmlns:dm0="http://schemas.microsoft.com/VisualStudio/2008/DslTools/Core" dslVersion="1.0.0.0" Id="8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f" namespace="SLIMJobRegFormConfig" xmlSchemaNamespace="urn:SLIMJobRegFormConfig" xmlns="http://schemas.microsoft.com/dsltools/ConfigurationSectionDesigner">
  <typeDefinitions>
    <externalType name="String" namespace="System" />
    <externalType name="Boolean" namespace="System" />
    <externalType name="Int32" namespace="System" />
    <externalType name="Int64" namespace="System" />
    <externalType name="Single" namespace="System" />
    <externalType name="Double" namespace="System" />
    <externalType name="DateTime" namespace="System" />
    <externalType name="TimeSpan" namespace="System" />
  </typeDefinitions>
  <configurationElements>
    <configurationSection name="Labcodes" codeGenOptions="Singleton, XmlnsProperty" xmlSectionName="labcodes">
      <elementProperties>
        <elementProperty name="Labcode" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="labcode" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/Labcode" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationSection>
    <configurationElement name="Labcode">
      <attributeProperties>
        <attributeProperty name="name" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="name" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="description" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="description" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/String" />
          </type>
        </attributeProperty>
        <attributeProperty name="active" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="active" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/Boolean" />
          </type>
        </attributeProperty>
      </attributeProperties>
      <elementProperties>
        <elementProperty name="General" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="general" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/General" />
          </type>
        </elementProperty>
        <elementProperty name="Sample" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="sample" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/Sample" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="General">
      <elementProperties>
        <elementProperty name="Register" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="register" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/Register" />
          </type>
        </elementProperty>
        <elementProperty name="TRF" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="tRF" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/TRF" />
          </type>
        </elementProperty>
        <elementProperty name="WebService" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="webService" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/WebService" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="Register">
      <attributeProperties>
        <attributeProperty name="path" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="path" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="TRF">
      <attributeProperties>
        <attributeProperty name="path" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="path" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="WebService">
      <attributeProperties>
        <attributeProperty name="url" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="url" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/String" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
    <configurationElement name="Sample">
      <elementProperties>
        <elementProperty name="ClientDesc" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="clientDesc" isReadOnly="false">
          <type>
            <configurationElementMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/ClientDesc" />
          </type>
        </elementProperty>
      </elementProperties>
    </configurationElement>
    <configurationElement name="ClientDesc">
      <attributeProperties>
        <attributeProperty name="CharacterDigit" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="characterDigit" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/Int32" />
          </type>
        </attributeProperty>
        <attributeProperty name="NumberDigit" isRequired="false" isKey="false" isDefaultCollection="false" xmlName="numberDigit" isReadOnly="false">
          <type>
            <externalTypeMoniker name="/8bfd9ecf-8f25-4951-aa30-9c5d9d77d55f/Int32" />
          </type>
        </attributeProperty>
      </attributeProperties>
    </configurationElement>
  </configurationElements>
  <propertyValidators>
    <validators />
  </propertyValidators>
</configurationSectionModel>