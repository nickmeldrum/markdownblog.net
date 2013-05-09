using System.Web;

namespace MarkdownBlog.Net.Web.Controllers {
    public static class HttpContextExtensions {
        public static void SendHttpStatusResponse(this HttpContextWrapper contextWrapper, int statusCode) {
            contextWrapper.Response.StatusCode = 404;
            contextWrapper.Response.End();
        }
    }
}