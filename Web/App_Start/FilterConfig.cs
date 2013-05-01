using System.Web.Mvc;

namespace MarkdownBlog.Net.Web.App_Start {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}