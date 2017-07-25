using System;

namespace DentalWarranty.Domain
{
    /// <summary>
    /// Validation entity
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// Validation Id
        /// </summary>
        public virtual int ValidationId { get; set; }

        /// <summary>
        /// Validation Code
        /// </summary>
        public virtual string ValidationCode { get; set; }

        /// <summary>
        /// Created On
        /// </summary>
        public virtual DateTime CreatedOn { get; set; }

        /// <summary>
        /// Expired On
        /// </summary>
        public virtual DateTime ExpiredOn { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public virtual string Email { get; set; }
    }
}
