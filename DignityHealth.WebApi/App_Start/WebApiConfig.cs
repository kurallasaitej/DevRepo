using DignityHealth.WebApi.Infrastructure.Filters;
using DignityHealth.WebApi.Infrastructure.Handlers;
using System.Web.Http;


namespace DignityHealth.WebApi
{
    /// <summary>
    /// Handles WebAPI  routing
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// Initializes WebAPI routing
        /// </summary>
        /// <param name="config">HttpConfiguration object</param>
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            GlobalConfiguration.Configuration.MessageHandlers.Add(new LoggingHandler());
            config.Filters.Add(new ValidationActionFilter());
            config.Filters.Add(new HandleApiExceptionFilter());

            config.Routes.MapHttpRoute(
            name: "DefaultApi",
            routeTemplate: "{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //name: "PEAPIRoute",
            //routeTemplate: "api/{controller}/{action}/{id}",
            //defaults: new { id = RouteParameter.Optional }
            //);








            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}
