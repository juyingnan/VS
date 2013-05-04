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
    <!--1. all message names-->
    <!--2. all operation names of binding elements-->
  
  <!-- Do nothing with these elements -->
  <xsl:template match="wsdl:definitions/wsdl:documentation"/>
  <xsl:template match="wsdl:definitions/wsdl:types"/>
  <xsl:template match="wsdl:definitions/wsdl:portType"/>
  <xsl:template match="wsdl:definitions/wsdl:service"/>

  <!-- Extract the value held by and character elements encountered -->

  <xsl:template match="wsdl:message">
      <xsl:text>message.name = </xsl:text>
      <xsl:value-of select="@name"/>
  </xsl:template>

  <xsl:template match="wsdl:binding/wsdl:operation">
    <xsl:text>binding.operation.name = </xsl:text>
    <xsl:value-of select="@name"/>
  </xsl:template>

</xsl:stylesheet>
