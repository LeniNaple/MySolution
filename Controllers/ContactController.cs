using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
