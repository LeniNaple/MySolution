using FinalSol.Models.Identity;
using FinalSol.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers;

public class SignUpController : Controller
{
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    private readonly UserManager<CustomIdentityUser> _userManager;

    public SignUpController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }
   


    [HttpGet]
    public IActionResult Index()
    {
        if (_signInManager.IsSignedIn(User))
        {
            return RedirectToAction("Index", "Home");
        }
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> Index(UserRegistrationViewModel viewModel)
    {
        if (ModelState.IsValid)
        {

            if (await _userManager.FindByNameAsync(viewModel.Email) == null)
            {
                var result = await _userManager.CreateAsync(viewModel, viewModel.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Login");
                else
                    ModelState.AddModelError("", "Something went wrong.");
            }
            else
                ModelState.AddModelError("", "A user with the same email already exists");

        }
        return View(viewModel);
    }

}
