using System.Web.Routing;

namespace MarkdownBlog.Net.Web.NavigationRoutes
{
    public interface INavigationRouteFilter
    {
        bool  ShouldRemove(Route navigationRoutes);
    }
}
