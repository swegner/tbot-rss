using System.Web.Mvc;
using System.Web.Routing;

namespace TbotRssService
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "rss",
                url: "{controller}/{action}",
                defaults: new { controller = "Rss", action = "Feed" }
            );
        }
    }
}