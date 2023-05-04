using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
