using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
