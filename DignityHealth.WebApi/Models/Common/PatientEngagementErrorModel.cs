
namespace DignityHealth.WebApi.Models.Common
{
    /// <summary>
    /// DentalWarrantyErrorResponse object.
    /// </summary>
    public class DentalWarrantyErrorModel
    {
        /// <summary>
        /// service custom code
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// service custom message
        /// </summary>
        public string Message { get; set; }
    }
}