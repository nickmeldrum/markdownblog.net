using System.Web.Mvc;
using MarkdownBlog.Net.Web.Models;

namespace MarkdownBlog.Net.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Home());
        }

    }
}
