using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Data;
using DignityHealth.Domain;
using Enterprise.EntityFramework;

namespace DignityHealth.Infrastructure.Utilities
{
    /// <summary>
    /// Nhibernate helper class
    /// </summary>
    public class NHibernateHelper
    {
        #region variables
        private static ISessionFactory _sessionFactory;
        protected static Configuration NhConfiguration;
        private static readonly string DbConfigKey = ConfigurationHelper.DbConnnectionString;

        /// <summary>
        /// session factory object
        /// </summary>
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }
        #endregion

        /// <summary>
        /// Initializes the Nhibernate configuration  settings to session factory object.
        /// </summary>
        private static void InitializeSessionFactory()
        {
            NhConfiguration = ConfigureNHibernate();
            GetMappings();

            SchemaMetadataUpdater.QuoteTableAndColumns(NhConfiguration);
            _sessionFactory = NhConfiguration.BuildSessionFactory();
            //new SchemaUpdate(NhConfiguration).Execute(false, true);
        }

        /// <summary>
        /// Initializes the Nhibernate configuration. 
        /// </summary>
        /// <returns>Returns Nhibernate configuration object.</returns>
        private static Configuration ConfigureNHibernate()
        {
            var configure = new Configuration();

            configure.DataBaseIntegration(db =>
            {
                db.Dialect<MsSql2012Dialect>();
                db.Driver<Sql2008ClientDriver>();
                db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                db.IsolationLevel = IsolationLevel.ReadCommitted;
                db.ConnectionString = DbConfigKey;
                db.Timeout = 10;

                //// enabled for testing
                //db.LogFormatedSql = true;
                db.LogSqlInConsole = true;
                db.AutoCommentSql = true;
            });

            return configure;
        }

        /// <summary>
        /// Adds class mappings.
        /// </summary>
        protected static void GetMappings()
        {
            ModelMapper mapper = new ModelMapper();
            mapper.AddMappings(typeof(WhitelistEmail).Assembly.GetTypes());
            mapper.AddMappings(typeof(WhitelistDomain).Assembly.GetTypes());
            NhConfiguration.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());
        }

        /// <summary>
        /// Opens the session for db operations.
        /// </summary>
        /// <returns>Returns session object</returns>
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
