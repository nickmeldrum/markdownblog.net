using System.IO;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers {
    public class PageController : Controller {
        public ActionResult Index()
        {
            var markdown = new MarkdownSharp.Markdown();
            var post = new Post();
            using (var reader = new StreamReader(Server.MapPath("~/pages/home.markdown")))
            {
                post.Body = markdown.Transform(reader.ReadToEnd());
            }
            return View(post);
        }
    }
}