﻿
using DignityHealth.WebApi.Infrastructure.Utilities;

namespace DignityHealth.WebApi.Models.Common
{
    /// <summary>
    /// Result of all model manager methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ModelManagerResult<T> 
    {
        /// <summary>
        /// Response status code
        /// </summary>
        public ResponseCodes Status { get; set; }

        /// <summary>
        /// Result value
        /// </summary>
        public T Value { get; set; }
    }
}