
namespace DignityHealth.Infrastructure.Providers.Email
{
    /// <summary>
    /// Email parameters object
    /// </summary>
    public class EmailParameters
    {
        /// <summary>
        /// Validation code
        /// </summary>
        public string ValidationCode { get; set; }

        /// <summary>
        /// Application Name
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Expiration Hours
        /// </summary>
        public int ExpirationHours { get; set; }

        /// <summary>
        /// Image Name
        /// </summary>
        public string ImageName { get; set; }
    }
}