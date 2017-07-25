using System;

namespace DentalWarranty.Domain
{
    /// <summary>
    /// User entity
    /// </summary>
    public class User
    {
        /// <summary>
        /// User Id
        /// </summary>
        public virtual int UserId { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Password Hash
        /// </summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// Salt Hash
        /// </summary>
        public virtual string SlatHash { get; set; }

        /// <summary>
        /// Application Type
        /// </summary>
        public virtual string ApplicationType { get; set; }

        /// <summary>
        /// Last Login Date
        /// </summary>
        public virtual DateTime? LastLoginDate { get; set; }

        /// <summary>
        /// TC Acknowledged Date
        /// </summary>
        public virtual DateTime? TcAcknowledgedDate  { get; set; }

        /// <summary>
        /// Version
        /// </summary>
        public virtual string Version { get; set; }

        /// <summary>
        /// Deactivated On
        /// </summary>
        public virtual DateTime? DeactivatedOn { get; set; }

        /// <summary>
        /// User role id
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
