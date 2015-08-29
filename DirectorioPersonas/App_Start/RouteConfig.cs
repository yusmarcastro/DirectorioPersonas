using System.Web.Mvc;
using System.Web.Routing;

namespace DirectorioPersonas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.ashx/{*pathInfo}");

            routes.MapRoute("Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Persona", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }
    }
}