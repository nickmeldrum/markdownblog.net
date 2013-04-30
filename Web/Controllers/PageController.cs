using System.Web.Mvc;

namespace Web.Controllers {
    public class PageController : Controller {
        public ActionResult Index()
        {
            return View();
        }
    }
}