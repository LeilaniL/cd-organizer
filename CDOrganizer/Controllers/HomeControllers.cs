using Microsoft.AspNetCore.Mvc;

namespace CDOrganizer.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

    }
}