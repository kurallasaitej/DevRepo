using System;

namespace Enterprise.Security
{
    public class TokenInfo
    {
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// A unique id created by the client application
        /// </summary>
        public string DeviceId { get; set; }

        /// <summary>
        /// Gets or Sets Patient Id
        /// </summary>
        public int PatientId { get; set; }

        /// <summary>
        /// Gets or Sets Care Partner Id
        /// </summary>
        public int CarePartnerId { get; set; }

        /// <summary>
        /// Gets or Sets Provider Id
        /// </summary>
        public int ProviderId { get; set; }

        /// <summary>
        /// Gets or Sets whether it is access token or not.
        /// </summary>
        public bool IsAccessToken { get; set; }

        /// <summary>
        /// Created time of the token.
        /// </summary>
        public DateTime TokenCreatedTime { get; set; }
    }
}
