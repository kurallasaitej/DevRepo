using DentalWarranty.WebApi.Models.Common;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using DentalWarranty.Domain;

namespace DentalWarranty.Infrastructure.Mappings
{
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Table("Users");
			Lazy(true);
            Id(x => x.Id, map => { map.Column("Id"); map.Generator(Generators.Native); });
            Property(x => x.UserName);
            Property(x => x.PasswordHash);
        }
    }
}
