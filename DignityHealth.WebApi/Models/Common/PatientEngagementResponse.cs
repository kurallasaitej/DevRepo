
using System.Runtime.Serialization;

namespace DignityHealth.WebApi.Models.Common
{
    /// <summary>
    /// DignityHealthResponse object
    /// </summary>
    /// <typeparam name="T">Type T</typeparam>
    [DataContract(Name = "DignityHealthResponse{0}")]
    public class DignityHealthResponse<T>
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        [DataMember]
        public int Status { get; set; }

        /// <summary>
        /// service custom code
        /// </summary>
        [DataMember]
        public int Code { get; set; }

        /// <summary>
        /// service custom message
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// response object
        /// </summary>
        [DataMember]
        public T Data { get; set; }
    }

    /// <summary>
    /// DignityHealthResponse object
    /// </summary>
    public class DignityHealthResponse
    {
        /// <summary>
        /// HTTP status code
        /// </summary>
        public int Status { get; set; }

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