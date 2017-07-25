
namespace DignityHealth.Infrastructure.Providers.Email
{
    /// <summary>
    /// Provides mailing functionality
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Sends validation code email
        /// </summary>
        /// <param name="emailTemplateType">EmailTemplateType enum</param>
        /// <param name="validationCode">Validation Code</param>
        /// <param name="toEmail">To Email</param>
        void SendValidationCodeMail(EmailTemplateType emailTemplateType, string validationCode, string toEmail);
    }
}
