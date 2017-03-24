using System.Web.Http;

namespace LinkService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{id}",
                defaults: new { id = RouteParameter.Optional, controller = "values" }
            );
        }
    }
}
