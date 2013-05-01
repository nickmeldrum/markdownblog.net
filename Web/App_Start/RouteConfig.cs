using System.Web.Mvc;
using System.Web.Routing;

namespace MarkdownBlog.Net.Web.App_Start {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{*url}",
                defaults: new { controller = "Page", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "MarkdownBlog.Net.Web.Controllers" }
            );
        }
    }
}