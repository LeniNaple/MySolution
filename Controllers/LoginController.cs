using FinalSol.Models.Identity;
using FinalSol.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<CustomIdentityUser> _signInManager;

        public LoginController(SignInManager<CustomIdentityUser> signInManager)
        {
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
        public async Task<IActionResult> Index(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");

                ModelState.AddModelError("", "Incorrect email address or password");
            }

            return View(viewModel);
        }
    }
}
