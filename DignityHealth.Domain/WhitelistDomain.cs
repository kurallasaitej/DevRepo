using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DignityHealth.Domain
{
    [Table("WhitelistDomain")]
    public class WhitelistDomain
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int WhitelistDomainId { get; set; }

        public string DomainName { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DeactivateDate { get; set; }
    }
}