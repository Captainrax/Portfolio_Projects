<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <xsl:output method="html" indent="yes" encoding="UTF-8"/>
 
  <xsl:template match="/">
    <html>
      <body>
        <h2>tables of xml files</h2>
        <div>Classes</div>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Class ID</th>
            <th>name</th>
            <th>startdate</th>
            <th>length</th>
            <th>description</th>
          </tr>
          <xsl:for-each select="/TechCollege/classes/class">
            <tr>
              <td>
                <xsl:value-of select="@cid"/>
              </td>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="startdate"/>
              </td>
              <td>
                <xsl:value-of select="length"/>
              </td>
              <td>
                <xsl:value-of select="description"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <div>Students</div>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Student ID</th>
            <th>Class ID</th>
            <th>Login</th>
            <th>Name</th>
          </tr>
          <xsl:for-each select="/TechCollege/students/student">
            <tr>
              <td>
                <xsl:value-of select="@studentid"/>
              </td>
              <td>
                <xsl:value-of select="@cid"/>
              </td>
              <td>
                <xsl:value-of select="login"/>
              </td>
              <td>
                <xsl:value-of select="name"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <div>Relation Table Students</div>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Class Name</th>
            <th>Start Date</th>
            <th>Login</th>
            <th>Name</th>
          </tr>
            <xsl:for-each select="/TechCollege/students/student">
              <xsl:variable name="studentDetails" select="."/>
              <tr>
              <xsl:for-each select="/TechCollege/classes/class">
                <xsl:if test="@cid = $studentDetails/@cid">
                  <td>
                    <xsl:value-of select="name"/>
                  </td>
                  <td>
                    <xsl:value-of select="startdate"/>
                  </td>
                </xsl:if>
              </xsl:for-each>
                <td>
                  <xsl:value-of select="$studentDetails/login"/>
                </td>
                <td>
                  <xsl:value-of select="$studentDetails/name"/>
                </td>
              </tr>
            </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
  
</xsl:stylesheet>
