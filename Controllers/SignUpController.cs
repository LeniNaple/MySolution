using FinalSol.Contexts;
using FinalSol.Models.Entities;
using FinalSol.Models.Identity;
using FinalSol.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalSol.Controllers;

public class SignUpController : Controller
{
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    private readonly UserManager<CustomIdentityUser> _userManager;

    private readonly IdentityContext _identityContext;


    public SignUpController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, IdentityContext identityContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _identityContext = identityContext;
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

                CustomIdentityUser customIdentityUser = viewModel;
                var result = await _userManager.CreateAsync(customIdentityUser, viewModel.Password);

                UserEntity userEntity = viewModel;
                userEntity.UserId = customIdentityUser.AdressId;

                _identityContext.UsersInformations.Add(viewModel);
                await _identityContext.SaveChangesAsync();

                

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                    ModelState.AddModelError("", "Something went wrong.");
            }
            else
                ModelState.AddModelError("", "A user with the same email already exists");

        }
        return View(viewModel);
    }

}
