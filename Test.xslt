<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>
  <xsl:template match="Son/AnotherName"></xsl:template>
  <xsl:template match="Son/AThirdName"></xsl:template>
    <xsl:template match="Son/ClassName">
      <xsl:element name="{name()}" namespace="{namespace-uri()}">
        <xsl:value-of select="."/>
      </xsl:element>
    </xsl:template>
</xsl:stylesheet>
