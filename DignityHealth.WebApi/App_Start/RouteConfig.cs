using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace DignityHealth.WebApi
{
    /// <summary>
    /// Handles routing configurations
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// creates routing configuration
        /// </summary>
        /// <param name="routes"></param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute("account-register", "api/account/register", new { controller = "Account", action = "Register"});
            //routes.MapRoute("patient-register", "api/patient/register", new { controller = "Patient", action = "Register" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
                       
        }
    }
}