using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DignityHealth.Domain
{
    [Table("WhitelistEmail")  ]
    public class WhitelistEmail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int WhitelistEmailId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email Name is required")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DeactivatedDate { get; set; }
    }
}