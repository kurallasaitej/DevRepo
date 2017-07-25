using DentalWarranty.WebApi.Models.Common;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using DentalWarranty.Domain;

namespace DentalWarranty.Infrastructure.Mappings
{
    public class RefreshTokenMap : ClassMapping<RefreshToken>
    {
        public RefreshTokenMap()
        {
            Table("RefreshTokens");
			Lazy(true);
            Id(x => x.Id, map => { map.Column("Id"); map.Generator(Generators.Assigned); });
            Property(x => x.Subject);
            Property(x => x.ClientId);
            Property(x => x.ProtectedTicket);
        }
    }
}
