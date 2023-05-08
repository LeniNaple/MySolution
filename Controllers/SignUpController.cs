using FinalSol.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers;

public class SignUpController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(UserRegistrationViewModel viewModel)
    {
        return View(viewModel);
    }

}
