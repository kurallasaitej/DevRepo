using System.Data.Entity.ModelConfiguration;
using DignityHealth.Domain;

namespace Enterprise.EntityFramework
{
    public class WhitelistDomainMap : EntityTypeConfiguration<WhitelistDomain>
    {
        public WhitelistDomainMap()
        {
            ToTable("WhitelistDomain");
            HasKey(x => x.WhitelistDomainId);
            Property(x => x.DomainName);
            Property(x => x.CreatedBy);
            Property(x => x.CreatedOn);
            Property(x => x.DeactivateDate);
        }
    }
}
