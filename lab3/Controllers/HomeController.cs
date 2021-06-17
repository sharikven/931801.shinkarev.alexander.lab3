using Microsoft.AspNetCore.Mvc;

namespace lab3.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MockIndex()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
