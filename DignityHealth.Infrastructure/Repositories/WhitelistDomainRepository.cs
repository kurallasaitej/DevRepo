using Enterprise.EntityFramework;
using DignityHealth.Domain;
using DignityHealth.Domain.RepositoryInterfaces;

namespace DignityHealth.Infrastructure.Repositories
{
    /// <summary>
    /// Provides all whitelist domain related operations
    /// </summary>
    public class WhitelistDomainRepository : DomainRepository<WhitelistDomain>, IWhitelistDomainRepository
    {

        public WhitelistDomainRepository(DignityHealthContext context)
            : base(context)
        {
           
        }

  
    }
}
