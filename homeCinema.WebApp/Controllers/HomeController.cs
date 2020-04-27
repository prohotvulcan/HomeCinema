using Microsoft.AspNetCore.Mvc;

namespace homeCinema.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
