using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Protocols.WSTrust;
using System.IdentityModel.Tokens;
using System.Security.Claims;

namespace Enterprise.Security
{
    /// <summary>
    /// Jwt Token Manager class
    /// </summary>
    public class JwtTokenManager
    {
        public const string DeviceId = "DeviceId";
        public const string PatientId = "PatientId";
        public const string CarePartnerId = "CarePartnerId";
        public const string ProviderId = "ProviderId";
        public const string IsAccessToken = "IsAccessToken";
        public const string CreatedOn = "CreatedOn";

        /// <summary>
        /// Creates new token based on the passed UserName,deviceId
        /// </summary>
        /// <param name="tokenInfo">TokenInfo object</param>
        /// <param name="expirationMinutes">Expiration time in minutes</param>
        /// <param name="expirationEpoch"></param>
        /// <returns>Token</returns>
        public static string CreateToken(TokenInfo tokenInfo,
                                         int expirationMinutes,
                                         out long expirationEpoch)
        {
            return CreateTokenCommon(tokenInfo, expirationMinutes, null, out expirationEpoch);
        }

        /// <summary>
        ///  Creates new token based on the passed UserName,deviceId
        /// </summary>
        /// <param name="tokenInfo">TokenInfo object</param>
        /// <param name="expirationTime">Expiration time</param>
        /// <param name="expirationEpoch"></param>
        /// <returns>Token</returns>
        public static string CreateToken(TokenInfo tokenInfo,
                                         DateTime expirationTime,
                                         out long expirationEpoch)
        {
            return CreateTokenCommon(tokenInfo, null, expirationTime, out expirationEpoch);
        }

        /// <summary>
        /// Creates new token based on the passed UserName,deviceId
        /// </summary>
        /// <param name="tokenInfo">TokenInfo object</param>
        /// <param name="expirationMinutes">Expiration time in minutes</param>
        /// <param name="expirationTime">Expiration time</param>
        /// <param name="expirationEpoch"></param>
        /// <returns></returns>
        private static string CreateTokenCommon(TokenInfo tokenInfo,
                                                int? expirationMinutes,
                                                DateTime? expirationTime,
                                                out long expirationEpoch)
        {
            var claimList = new List<Claim>
            {
                new Claim(ClaimTypes.Name, tokenInfo.UserName),
                new Claim(DeviceId, tokenInfo.DeviceId),
                new Claim(IsAccessToken, tokenInfo.IsAccessToken.ToString()),
                 new Claim(CreatedOn, tokenInfo.TokenCreatedTime.ToString())
            };

            if (tokenInfo.PatientId > 0)
                claimList.Add(new Claim(PatientId, tokenInfo.PatientId.ToString(CultureInfo.InvariantCulture)));

            if (tokenInfo.CarePartnerId > 0)
                claimList.Add(new Claim(CarePartnerId, tokenInfo.CarePartnerId.ToString(CultureInfo.InvariantCulture)));

            if (tokenInfo.ProviderId > 0)
                claimList.Add(new Claim(ProviderId, tokenInfo.ProviderId.ToString(CultureInfo.InvariantCulture)));


            var tokenHandler = new JwtSecurityTokenHandler();

            var sSKey = new InMemorySymmetricSecurityKey(SecurityConstants.KeyForHmacSha256);
            SecurityToken jwtToken;

            if (expirationMinutes.HasValue)
                jwtToken = tokenHandler.CreateToken(MakeSecurityTokenDescriptor(sSKey, claimList, expirationMinutes, null));
            else
            {
                jwtToken = tokenHandler.CreateToken(MakeSecurityTokenDescriptor(sSKey, claimList, null, expirationTime));
            }

            expirationEpoch = jwtToken.ValidTo.ToEpochTime();
            return tokenHandler.WriteToken(jwtToken);
        }


        /// <summary>
        /// Validates the token
        /// </summary>
        /// <param name="jwtToken">Token string</param>
        /// <param name="jwtSecurityToken">Gives the token object</param>
        /// <returns>returns Claims principle.</returns>
        public static ClaimsPrincipal ValidateJwtToken(string jwtToken, out SecurityToken jwtSecurityToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Parse JWT from the Base64UrlEncoded wire form (<Base64UrlEncoded header>.<Base64UrlEncoded body>.<signature>)
            jwtSecurityToken = tokenHandler.ReadToken(jwtToken);

            TokenValidationParameters validationParams = new TokenValidationParameters
            {
                //AllowedAudience = SecurityConstants.TokenAudience,
                ValidIssuer = SecurityConstants.TokenIssuer,
                ValidateIssuer = true,
                //SigningToken = new BinarySecretSecurityToken(SecurityConstants.KeyForHmacSha256),
            };
            return tokenHandler.ValidateToken(jwtToken, validationParams, out jwtSecurityToken);
        }

        public static JwtSecurityToken GetToken(string tokenString)
        {
            var tokenHandler = new JwtSecurityTokenHandler ();
            return tokenHandler.ReadToken(tokenString) as JwtSecurityToken;
        }

        /// <summary>
        /// Gets Security token descriptor.
        /// </summary>
        /// <param name="securityKey">Security Key</param>
        /// <param name="claimList">Claim list</param>
        /// <param name="expirationMinutes">Expiration time in minutes</param>
        /// <param name="expirationTime">Expiration time</param>
        /// <returns>SecurityTokenDescriptor object</returns>
        private static SecurityTokenDescriptor MakeSecurityTokenDescriptor(InMemorySymmetricSecurityKey securityKey, List<Claim> claimList, int? expirationMinutes, DateTime? expirationTime)
        {
            var now = DateTime.UtcNow;
            Claim[] claims = claimList.ToArray();
            return new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                TokenIssuerName = SecurityConstants.TokenIssuer,
                AppliesToAddress = SecurityConstants.TokenAudience,

                Lifetime = expirationMinutes.HasValue ? new Lifetime(now, now.AddMinutes((double)expirationMinutes)) : new Lifetime(now, expirationTime),
                SigningCredentials = new SigningCredentials(securityKey,
                    "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256",
                    "http://www.w3.org/2001/04/xmlenc#sha256"),
            };
        }
    }


}
