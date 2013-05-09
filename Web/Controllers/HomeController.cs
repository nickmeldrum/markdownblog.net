using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers
{
    public class HomeController : BlogControllerBase
    {
        public ActionResult Index()
        {
            return View(new Home(HttpContextWrapper));
        }
    }
}
