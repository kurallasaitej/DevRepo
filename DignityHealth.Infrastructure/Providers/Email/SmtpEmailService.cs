using System.Configuration;
using System.Net.Mail;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Net.Mime;
using System.Web;
using System.Xml.Serialization;
using Enterprise.Enums;
using DignityHealth.Infrastructure.Utilities;

namespace DignityHealth.Infrastructure.Providers.Email
{
    /// <summary>
    /// Provides mailing functionality
    /// </summary>
    public class SmtpEmailService : IEmailService
    {
        #region constants

        /// <summary>
        /// xslt extension
        /// </summary>
        private const string XsltExtension = ".xslt";

        /// <summary>
        /// jpg extension
        /// </summary>
        private const string PngExtension = ".png";

        /// <summary>
        /// Village health logo image file name
        /// </summary>
        private const string VillageHealthLogo = "VHLogo";


        #endregion

        /// <summary>
        /// Sends validation code email
        /// </summary>
        /// <param name="emailTemplateType">EmailTemplateType</param>
        /// <param name="validationCode">Validation Code</param>
        /// <param name="toEmail">To Email</param>
        public void SendValidationCodeMail(EmailTemplateType emailTemplateType, string validationCode, string toEmail)
        {
            string emailLogoUrl = string.Empty;
            var emailParameters = new EmailParameters();
            emailParameters.ApplicationName = ConfigurationHelper.ApplicationName;
            emailParameters.ExpirationHours = ConfigurationHelper.ExpirationHours;
            emailParameters.ValidationCode = validationCode;
            var emailtempateFileName = Path.Combine(emailTemplateType.ToString() + XsltExtension);
            string subject = EnumManager.Instance.GetDescription(emailTemplateType);
            string body = GenerateEmailBody(emailParameters, emailtempateFileName);
            var imageUrl = Path.Combine(VillageHealthLogo + PngExtension);
            if (!string.IsNullOrEmpty(imageUrl))
            {
                emailLogoUrl = HttpContext.Current.Server.MapPath("~/" + Path.Combine(ConfigurationHelper.ImageUrlPath, imageUrl));
            }
            SendEmail(subject, body, toEmail, emailLogoUrl);
        }

        /// <summary>
        /// Generates HTML Email Body from Xslt template file
        /// </summary>
        /// <typeparam name="T">Class</typeparam>
        /// <param name="t">Object</param>
        /// <param name="emailtempateFileName">EmailTemplate</param>
        /// <returns>Email Body</returns>
        private string GenerateEmailBody<T>(T t, string emailtempateFileName)
        {
            string emailBody = string.Empty;
            var xsltPath = HttpContext.Current.Server.MapPath("~/" + Path.Combine(ConfigurationHelper.EmailTemplatePath, emailtempateFileName));
            if (File.Exists(xsltPath))
            {
                string xslInput = File.ReadAllText(xsltPath);
                XmlSerializer emailXml = new XmlSerializer(typeof(T));

                StringWriter stringWriter = new StringWriter();
                XmlWriter writer = XmlWriter.Create(stringWriter);
                emailXml.Serialize(writer, t);
                var xmlInput = stringWriter.ToString();

                using (StringReader xslStringReader = new StringReader(xslInput)) // xslInput is a string that contains xsl
                {
                    using (StringReader xmlStringReader = new StringReader(xmlInput)) // xmlInput is a string that contains xml
                    {
                        using (XmlReader xslReader = XmlReader.Create(xslStringReader))
                        {
                            using (XmlReader xmlReader = XmlReader.Create(xmlStringReader))
                            {
                                XslCompiledTransform xslt = new XslCompiledTransform();
                                xslt.Load(xslReader);
                                using (StringWriter bodyStringWriter = new StringWriter())
                                // use OutputSettings of xsl, so it can be output as HTML
                                using (XmlWriter xmlWriter = XmlWriter.Create(bodyStringWriter, xslt.OutputSettings))
                                {
                                    xslt.Transform(xmlReader, xmlWriter);
                                    emailBody = bodyStringWriter.ToString();
                                }
                            }
                        }
                    }
                }
            }
            return emailBody;
        }

        /// <summary>
        /// Sends mail
        /// </summary>
        /// <param name="subject">Mail subject</param>
        /// <param name="body">Mail body</param>
        /// <param name="mailTo">To address</param>
        /// <param name="imageUrl">Image url</param>
        /// <param name="isBodyHtml">Boolean</param>
        public void SendEmail(string subject, string body, string mailTo, string imageUrl = "", bool isBodyHtml = true)
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.Subject = subject;

            if (!string.IsNullOrEmpty(imageUrl) && File.Exists(imageUrl))
            {
                string fileExtension = Path.GetExtension(imageUrl);

                Attachment inline = new Attachment(imageUrl);
                inline.ContentDisposition.Inline = true;
                inline.ContentDisposition.DispositionType = DispositionTypeNames.Inline;
                inline.ContentId = ConfigurationHelper.ImageContentId;
                inline.ContentType = new ContentType(string.Format("image/{0}", fileExtension));
                inline.ContentType.Name = Path.GetFileName(imageUrl);
                mailMessage.Attachments.Add(inline);
                mailMessage.Body = body;
            }
            else
            {
                mailMessage.Body = body;
            }

            mailMessage.IsBodyHtml = isBodyHtml;

            //mailMessage.From = new MailAddress(ConfigurationManager.GetSection( .appsettings[common.constants.from_email_address].tostring(),
            //    configurationmanager.appsettings[common.constants.from_email_friendly_name]);           

            foreach (var item in mailTo.Split(','))
            {
                if (item != null)
                    mailMessage.To.Add(item);
            }
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Send(mailMessage);
        }
    }
}
