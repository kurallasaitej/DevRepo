using System.Data.Entity.ModelConfiguration;
using DignityHealth.Domain;

namespace Enterprise.EntityFramework
{
    public class WhitelistEmailMap : EntityTypeConfiguration<WhitelistEmail>
    {
        public WhitelistEmailMap()
        {
            ToTable("WhitelistEmail");
            HasKey(d => d.WhitelistEmailId);
            Property(x => x.FirstName);
            Property(x => x.LastName);
            Property(x => x.Email);
            Property(x => x.CreatedBy);
            Property(x => x.CreatedOn);
            Property(x => x.DeactivatedDate);
        }
    }
}
