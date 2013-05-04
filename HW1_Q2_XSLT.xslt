<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
xmlns:soap="http://schemas.xmlsoap.org/wsdl/soap/" xmlns:tm="http://microsoft.com/wsdl/mime/textMatching/"
xmlns:soapenc="http://schemas.xmlsoap.org/soap/encoding/" xmlns:mime="http://schemas.xmlsoap.org/wsdl/mime/"
xmlns:tns="http://WebXml.com.cn/" xmlns:s="http://www.w3.org/2001/XMLSchema"
xmlns:soap12="http://schemas.xmlsoap.org/wsdl/soap12/" xmlns:http="http://schemas.xmlsoap.org/wsdl/http/"
xmlns:wsdl="http://schemas.xmlsoap.org/wsdl/"
                >
  <xsl:output method="xml" omit-xml-declaration="yes"/>

  <!--Purpose-->
  <!--this XML processor is to output-->
  <!--1. All complex types names-->
  <!--2. All operation names in portType-->
  <!--3. Service element and its sub-elements-->

  <!-- Do nothing with these elements -->
  <xsl:template match="wsdl:definitions/wsdl:documentation"/>
  <xsl:template match="wsdl:definitions/wsdl:message"/>
  <xsl:template match="wsdl:definitions/wsdl:binding"/>
  <xsl:template match="wsdl:definitions/wsdl:service/wsdl:documentation"/>


  <!-- Extract the value held by and character elements encountered -->

  <xsl:template match="s:complexType">
    <xsl:text>complexType.name = </xsl:text>
    <xsl:value-of select="@name"/>
  </xsl:template>

  <xsl:template match="wsdl:portType/wsdl:operation">
    <xsl:element name="{name()}" namespace="">
    <xsl:text>portType.operation.name = </xsl:text>
    <xsl:value-of select="@name"/>
    </xsl:element>
  </xsl:template>


  <xsl:template match="wsdl:service">
    <xsl:call-template name="copy"/>
    <xsl:apply-templates/>
  </xsl:template>

  <xsl:template name="copy">
    <xsl:element name="{name()}" namespace="">
      <xsl:copy-of select="@*"/>
      <xsl:value-of select="."/>
      <xsl:for-each select="*">
        <xsl:call-template name="copy"/>
      </xsl:for-each>
    </xsl:element>
  </xsl:template>

</xsl:stylesheet>
