using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Web.Http;
using DignityHealth.Infrastructure.Utilities;
using Enterprise.UnityLifeTime;
using Microsoft.Practices.Unity.InterceptionExtension;
using NHibernate;

namespace DignityHealth.WebApi.Infrastructure.IOC
{
    /// <summary>
    /// Handles unity configuration
    /// </summary>
    public static class UnityConfig
    {
        /// <summary>
        /// Registers unity configurations
        /// </summary>
        public static void RegisterComponents()
        {
            IUnityContainer container = new UnityContainer();
            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unityPE");
            section.Configure(container);

            container.RegisterType<ISession>(new PerRequestLifetimeManager(),
                                                new InjectionFactory(c =>
                                                {
                                                    return NHibernateHelper.OpenSession();
                                                }));

            container.AddNewExtension<Interception>();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityResolver(container);
        }
    }
}