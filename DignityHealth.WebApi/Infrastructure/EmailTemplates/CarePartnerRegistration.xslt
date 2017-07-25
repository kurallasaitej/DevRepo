<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl">
  <xsl:output method="html" indent="yes" omit-xml-declaration="yes"/>
  <xsl:template match="/">
    <html>
      <head>
      </head>
      <body>
        <p>Hello!</p>
        <p>
          Thank you for creating an account with <xsl:value-of select="EmailParameters/ApplicationName"/>. We look forward to helping support you in your role as a Care Partner.
        </p>
        <p>
          <b>
            To complete your registration, please use the following validation code when prompted:
          </b>
          <b>
            <span style="color:blue">
              <xsl:value-of select="EmailParameters/ValidationCode"/>
            </span>
          </b>.
          This code will expire <xsl:value-of select="EmailParameters/ExpirationHours"/> hours after this email was sent.
        </p>
        <p>
          If you believe you received this e-mail in error, please
          <b>
            <u>
              <a href="mailto:MobileApp@villagehealth.com" style="color:blue">let us know</a>
            </u>
          </b>
          <span>.</span>
        </p>
        <p>
          Sincerely,
        </p>
        <p>
          Your VillageHealth Team
        </p>
        <img src="cid:PELogo" alt="image" height="50" width="220"></img>
        <p>
          <b>
            If you have a medical emergency, call 911 immediately.
          </b>
          This app is for informational purposes only and is not intended to be a health-management or emergency alert system, or substitute for medical advice or diagnosis from a physician.
        </p>
        <p>
          PLEASE DO NOT REPLY TO THIS MESSAGE. THIS E-MAIL IS SENT FROM AN UNMONITORED E-MAIL ACCOUNT.
        </p>
        <p>
          STATEMENT OF CONFIDENTIALITY: The information contained in this electronic message and any attachments to this message are strictly intended for the exclusive use of the addressee(s) and may contain confidential or privileged information.If you are not the intended recipient, please destroy all copies of this message and any attachments.Thank you.
        </p>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
