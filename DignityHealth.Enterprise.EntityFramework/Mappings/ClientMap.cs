using DentalWarranty.WebApi.Models.Common;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using DentalWarranty.Domain;

namespace DentalWarranty.Infrastructure.Mappings
{
    public class ClientMap : ClassMapping<Client>
    {
        public ClientMap()
        {
            Table("Clients");
			Lazy(true);
            Id(x => x.Id, map => { map.Column("Id"); map.Generator(Generators.Assigned); });
            Property(x => x.ClientSecret);
            Property(x => x.AppType);
            Property(x => x.Active);
            Property(x => x.AllowedOrigin);
            Property(x => x.Name);
            Property(x => x.RefreshTokenLifeTime);
        }
    }
}
