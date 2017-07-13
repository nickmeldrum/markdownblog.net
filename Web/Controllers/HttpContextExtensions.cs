using System;
using System.Web;

namespace MarkdownBlog.Net.Web.Controllers {
    public static class HttpContextExtensions {
        public static void SendHttpStatusResponse(this HttpContextWrapper contextWrapper, int statusCode) {
            contextWrapper.Response.StatusCode = 404;
            contextWrapper.Response.End();
        }

        public static string ResolveServerUrl(this HttpContextWrapper contextWrapper, string serverUrl, bool forceHttps) {
            if (serverUrl.IndexOf("://", StringComparison.Ordinal) > -1)
                return serverUrl;

            var newUrl = serverUrl;
            var originalUri = contextWrapper.Request.Url;
            newUrl = (forceHttps ? "https" : originalUri.Scheme) + "://" + originalUri.Authority + newUrl;

            return newUrl;
        }

        public static Uri GetAbsoluteUrl(this HttpContextWrapper contextWrapper, string virtualUrl) {
            return new Uri(ResolveServerUrl(contextWrapper, VirtualPathUtility.ToAbsolute(virtualUrl), false));
        }

    }
}