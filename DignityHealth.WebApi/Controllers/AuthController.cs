using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DentalWarranty.Domain;
using DentalWarranty.WebApi.Infrastructure.Utilities;
using Enterprise.Security;

namespace DentalWarranty.WebApi.Controllers
{
    /// <summary>
    /// Authentication controller
    /// </summary>
    public class AuthController : DentalWarrantyBaseController
    {
        /// <summary>
        /// VerifyUserCredentials and returns token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("auth")]
        public HttpResponseMessage VerifyCredentials(User user)
        {
            if (user.UserName == "admin" && user.PasswordHash == "1234")
            {
                long epoch;
                string token = JwtTokenManager.CreateToken(new TokenInfo
                    {
                        UserName = user.UserName,
                        IsAccessToken = true,
                        TokenCreatedTime = DateTime.Now
                    }, 5, out epoch);
                return Request.CreateResponse(HttpStatusCode.OK,
                                              ServiceResponse<string>.Instance.BuildResponse(HttpStatusCode.OK, ResponseCodes.OK,
                                                                                     token));
            }
             return Request.CreateResponse(HttpStatusCode.Unauthorized
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.Unauthorized, ResponseCodes.UNAUTHORIZED));
        }
    }
}
