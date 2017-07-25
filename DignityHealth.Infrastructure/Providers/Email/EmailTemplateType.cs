using System.ComponentModel;

namespace DignityHealth.Infrastructure.Providers.Email
{
    /// <summary>
    /// Email template type enum
    /// </summary>
    public enum EmailTemplateType
    {
        /// <summary>
        /// Patient Registration
        /// </summary>
        [Description("Patient Registration Validation Code")]
        PatientRegistration = 1,

        /// <summary>
        /// CarePartner Registration
        /// </summary>
        [Description("CarePartner Registration Validation Code")]
        CarePartnerRegistration = 2,

        /// <summary>
        /// Forgot password
        /// </summary>
        [Description("Forgot password Validation Code")]
        ForgotPassWord = 3
    }
}