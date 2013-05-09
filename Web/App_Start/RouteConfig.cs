using System.Web.Mvc;
using System.Web.Routing;

namespace MarkdownBlog.Net.Web.App_Start {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "BlogArchive", // Route name
                "blog/archive/{month}/{year}", // URL with parameters
                new { controller = "Blog", action = "Archive" } // Parameter defaults
            );

            routes.MapRoute(
                "BlogPost", // Route name
                "blog/{postName}", // URL with parameters
                new { controller = "Blog", action = "Post" } // Parameter defaults
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{*id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }
    }
}