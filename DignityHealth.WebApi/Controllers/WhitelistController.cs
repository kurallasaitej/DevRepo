using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DignityHealth.WebApi.Infrastructure.Utilities;
using DignityHealth.WebApi.Infrastructure.ModelManagers.Interfaces;
using DignityHealth.WebApi.Models.Common;
using DignityHealth.WebApi.Models.Whitelists;

namespace DignityHealth.WebApi.Controllers
{
    /// <summary>
    /// Manages all whitelist related operations.
    /// </summary>
    public class WhitelistController : DignityHealthBaseController
    {
        private readonly IWhitelistManager _whitelistManager;

        /// <summary>
        /// Constructor for WhitelistController
        /// </summary>
        /// <param name="whitelistManager">IWhitelistManager object</param>
        public WhitelistController(IWhitelistManager whitelistManager)
        {
            _whitelistManager = whitelistManager;
        }

        /// <summary>
        /// Get All whitelist emails
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ResponseType(typeof(DignityHealthResponse))]
        [Route("Whitelist")]
        public HttpResponseMessage GetWhitelist(WhitelistType type)
        {
            try
            {
                var whitelistEmails = _whitelistManager.GetWhitelist(type);
                return Request.CreateResponse(HttpStatusCode.OK, whitelistEmails);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.NotFound, ResponseCodes.RESOURCE_NOTFOUND));
            }
        }

        /// <summary>
        /// creates White list emails
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(DignityHealthResponse))]
        [Route("Whitelist/Emails")]
        public HttpResponseMessage CreateWhitelistEmail(WhitelistVM whitelistModel)
        {
            try
            {
                _whitelistManager.CreateWhitelistEmail(whitelistModel);
                return Request.CreateResponse(HttpStatusCode.OK
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.OK, ResponseCodes.WHITELISTEMAIL_ADDED));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.NotFound, ResponseCodes.INTERNAL_SEREVR_ERROR));
            }
        }

        /// <summary>
        /// creates White list Domains
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ResponseType(typeof(DignityHealthResponse))]
        [Route("Whitelist/Domains")]
        public HttpResponseMessage CreateWhitelistDomain(WhitelistVM whitelistModel)
        {
            try
            {
                _whitelistManager.CreateWhitelistDomain(whitelistModel);
                return Request.CreateResponse(HttpStatusCode.OK
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.OK, ResponseCodes.WHITELISTDOMAIN_ADDED));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.NotFound, ResponseCodes.INTERNAL_SEREVR_ERROR));
            }
        }

        /// <summary>
        /// Update WhiteList (Deactivate)
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [ResponseType(typeof(DignityHealthResponse))]
        [Route("Whitelist")]
        public HttpResponseMessage UpdateWhitelistEmail(WhitelistType whitelistType, WhitelistVM whitelistModel)
        {
            try
            {
                if (!_whitelistManager.UpdateWhitelistEmail(whitelistType, whitelistModel))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError,
                        ServiceResponse.Instance.BuildResponse(HttpStatusCode.InternalServerError, ResponseCodes.WHITELIST_UPDATION_FAILED));
                }
                return Request.CreateResponse(HttpStatusCode.OK
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.OK, ResponseCodes.WHITELIST_UPDATED));
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound
                                            , ServiceResponse.Instance.BuildResponse(HttpStatusCode.NotFound, ResponseCodes.INTERNAL_SEREVR_ERROR));
            }
        }
    }
}
