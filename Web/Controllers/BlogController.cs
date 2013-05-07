using System.Web;
using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers {
    public class BlogController : Controller {

        private static HttpContextWrapper HttpContextWrapper { get { return new HttpContextWrapper(System.Web.HttpContext.Current); } }

        public ActionResult Index()
        {
            return View(new Posts(HttpContextWrapper));
        }

        public ActionResult Post(string postName) {
            return string.IsNullOrWhiteSpace(postName)
                ? View("Index")
                : View("Post", new Post(postName, HttpContextWrapper));
        }
    }
}