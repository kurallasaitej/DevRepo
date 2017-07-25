using System;

namespace DentalWarranty.WebApi.Models.Users
{
    /// <summary>
    /// User entity
    /// </summary>
    public class UserVM
    {
        /// <summary>
        /// User Id
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// User Name
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Password Hash
        /// </summary>
        public virtual string PasswordHash { get; set; }
    }
}
