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
          You recently initiated a password reset for <xsl:value-of select="EmailParameters/ApplicationName"/>. Please use this validation code :
            <b>
            <span style="color:blue">
              <xsl:value-of select="EmailParameters/ValidationCode"/>
            </span>
          </b>
          .
          This code will expire <xsl:value-of select="EmailParameters/ExpirationHours"/> hours after this email was sent.
        </p>
        <p>
          You didn't ask to change your password? It's likely that another user has entered your email address by mistake and your account is still secure. If you believe an unauthorized person has accessed your account, you can reset your password.       
        </p>
        <p>
          If you have any questions,
          <b>
          <u>
            <a href="mailto:MobileApp@villagehealth.com" style="color:blue">let us know</a>
          </u>
        </b> 
         <span>.</span>
          We are always happy to help.
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
