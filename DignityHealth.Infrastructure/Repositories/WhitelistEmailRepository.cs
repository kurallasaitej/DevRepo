using DignityHealth.Domain;
using DignityHealth.Domain.RepositoryInterfaces;
using Enterprise.EntityFramework;

namespace DignityHealth.Infrastructure.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public class WhitelistEmailRepository : DomainRepository<WhitelistEmail>, IWhitelistEmailRepository
    {
        public WhitelistEmailRepository(DignityHealthContext context)
            : base(context)
        {

        }
    }
}
