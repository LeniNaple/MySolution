using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
