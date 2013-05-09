using System;
using System.Web;

namespace MarkdownBlog.Net.Web.Models {
    public class Site {
        public static readonly Site SiteData = new Site();

        public string Name { get { return "Blog"; } }
        public string Description { get { return "Blog Description"; } }
        public string Owner { get { return "Blog Owner"; } }

        private Site() {
        }

        public static string ResolveServerUrl(string serverUrl, bool forceHttps) {
            if (serverUrl.IndexOf("://", StringComparison.Ordinal) > -1)
                return serverUrl;

            var newUrl = serverUrl;
            var originalUri = HttpContext.Current.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) + "://" + originalUri.Authority + newUrl;

            return newUrl;
        } 

        public static Uri GetAbsoluteUrl(string virtualUrl)
        {
            return new Uri(ResolveServerUrl(VirtualPathUtility.ToAbsolute(virtualUrl), false));
        }
    }
}