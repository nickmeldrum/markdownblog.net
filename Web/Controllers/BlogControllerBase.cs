using System.Web;
using System.Web.Mvc;

namespace MarkdownBlog.Net.Web.Controllers {
    public class BlogControllerBase : Controller {
        protected HttpContextWrapper HttpContextWrapper { get { return new HttpContextWrapper(System.Web.HttpContext.Current); } }

        protected void SendHttpStatusResponse(int statusCode) {
            Response.StatusCode = 404;
            Response.End();
        }
    }
}