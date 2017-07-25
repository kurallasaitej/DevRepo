using System.ComponentModel;
using System.Web.Http.ModelBinding;

namespace DignityHealth.WebApi.Models.Common
{
    /// <summary>
    /// Pagination Query Model
    /// </summary>
    [ModelBinder(typeof(PaginationQueryModelBinder))]
    public class PaginationQueryModel
    {
        /// <summary>
        /// Number of records to skip.If not sent, defaults to 0.
        /// </summary>
        [DefaultValue(0)]
        public int Offset { get; set; }

        /// <summary>
        /// Number of records to return.If not sent, defaults to 10.
        /// </summary>
        [DefaultValue(10)]
        public int Limit { get; set; }
    }
}