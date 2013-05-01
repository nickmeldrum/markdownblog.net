using System.Web;
using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers {
    public class PageController : Controller {
        public ActionResult Index()
        {
            var post = new Post(new HttpContextWrapper(System.Web.HttpContext.Current));
            return View(post);
        }
    }
}