using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers {
    public class BlogController : BlogControllerBase {
        public ActionResult Index()
        {
            return View(new Posts(HttpContextWrapper));
        }

        public ActionResult Post(string postName) {
            return string.IsNullOrWhiteSpace(postName)
                ? View("Index")
                : View("Post", new Post(postName, HttpContextWrapper));
        }

        public ActionResult Archive(Archive archive)
        {
            archive.GetPosts(HttpContextWrapper);
            return View(archive);
        }

        public ActionResult Feed()
        {
            return View(new Posts(HttpContextWrapper));
        }
    }
}