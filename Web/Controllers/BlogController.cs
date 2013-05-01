using System.Web;
using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers {
    public class BlogController : Controller {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post(string postName) {
            return string.IsNullOrWhiteSpace(postName)
                ? View("Index")
                : View("Post", new Post(postName, new HttpContextWrapper(System.Web.HttpContext.Current)));
        }
    }
}