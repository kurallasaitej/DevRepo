using System.Security.Cryptography;

namespace Enterprise.Security
{
    /// <summary>
    /// Defines Security constants
    /// </summary>
    public class SecurityConstants
    {
        /// <summary>
        /// Sets or Gets KeyForHmacSha256
        /// </summary>
        public static readonly byte[] KeyForHmacSha256 = new byte[64];

        /// <summary>
        /// Sets or Gets TokenIssuer
        /// </summary>
        public static readonly string TokenIssuer = string.Empty;

        /// <summary>
        /// Sets or Gets TokenAudience
        /// </summary>
        public static readonly string TokenAudience = string.Empty;

        /// <summary>
        /// Constructor
        /// </summary>
        static SecurityConstants()
        {
            RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider();
            cryptoProvider.GetNonZeroBytes(KeyForHmacSha256);
            TokenIssuer = "DaVita";
            TokenAudience = "http://com";  
        }
    }
}
