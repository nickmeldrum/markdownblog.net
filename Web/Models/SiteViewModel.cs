using System.Web;

namespace MarkdownBlog.Net.Web.Models {
    public class SiteViewModel {
        public Posts Posts { get { return _posts ?? (_posts = new Posts(HttpContext)); } }
        public Site SiteData { get { return Site.SiteData; } }

        public SiteViewModel(HttpContextWrapper httpContext) {
            HttpContext = httpContext;
        }

        protected readonly HttpContextWrapper HttpContext;
        private Posts _posts;
    }
}