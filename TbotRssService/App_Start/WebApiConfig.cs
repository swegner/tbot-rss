using System.Web.Http;

namespace TbotRssService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}",
                defaults: new { controller = "rss" }
            );
        }
    }
}
