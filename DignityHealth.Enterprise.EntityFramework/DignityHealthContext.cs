using System.Data.Entity;

namespace Enterprise.EntityFramework
{
    public class DignityHealthContext : DbContext
    {
        public DignityHealthContext()
            : base("DignityHealthConnection")
        {
            Database.SetInitializer<DignityHealthContext>(new CreateDatabaseIfNotExists<DignityHealthContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new WhitelistEmailMap());
            modelBuilder.Configurations.Add(new WhitelistDomainMap());
        }

    }
}
