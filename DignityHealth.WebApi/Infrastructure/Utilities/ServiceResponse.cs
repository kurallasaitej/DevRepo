using Enterprise;
using System.Net;
using Enterprise.Enums;
using DignityHealth.WebApi.Models.Common;


namespace DignityHealth.WebApi.Infrastructure.Utilities
{
    /// <summary>
    /// Manages service response
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T> : SingletonBase<ServiceResponse<T>>
    {
        private ServiceResponse()
        { }

        /// <summary>
        /// Builds the service response
        /// </summary>
        /// <param name="status">HttpStatusCode</param>
        /// <param name="code">ResponseCodes</param>
        /// <param name="data">Object of type T</param>
        /// <returns>DentalWarrantyResponse object</returns>
        public DignityHealthResponse<T> BuildResponse(HttpStatusCode status, ResponseCodes code, T data)
        {
            var peResonse = new DignityHealthResponse<T>
            {
                Status = (int)status,
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription<ResponseCodes>(code),
                Data = data
            };

            return peResonse;
        }
    }

    /// <summary>
    /// Manages service response
    /// </summary>
    public class ServiceResponse : SingletonBase<ServiceResponse>
    {
        private ServiceResponse()
        { }

        /// <summary>
        /// Builds the service response
        /// </summary>
        /// <param name="status">HttpStatusCode</param>
        /// <param name="code">ResponseCodes</param>
        /// <returns>DentalWarrantyResponse object</returns>
        public DignityHealthResponse BuildResponse(HttpStatusCode status, ResponseCodes code)
        {
            var peResponse = new DignityHealthResponse
            {
                Status = (int)status,
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription<ResponseCodes>(code)
            };
            return peResponse;
        }

        /// <summary>
        /// Builds the service response
        /// </summary>       
        /// <param name="code">ResponseCodes</param>
        /// <returns>DentalWarrantyErrorResponse object</returns>
        public DentalWarrantyErrorModel BuildResponse(ResponseCodes code)
        {
            var peErrorResponse = new DentalWarrantyErrorModel
            {               
                Code = (int)code,
                Message = EnumManager.Instance.GetDescription<ResponseCodes>(code)
            };
            return peErrorResponse;
        }
    }
}