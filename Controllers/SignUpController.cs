using FinalSol.Contexts;
using FinalSol.Models.Entities;
using FinalSol.Models.Identity;
using FinalSol.Services;
using FinalSol.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalSol.Controllers;

public class SignUpController : Controller
{
    private readonly SignInManager<CustomIdentityUser> _signInManager;

    private readonly UserManager<CustomIdentityUser> _userManager;

    private readonly IdentityContext _identityContext;

    private readonly SeedService _seedService;


    public SignUpController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, IdentityContext identityContext, SeedService seedService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _identityContext = identityContext;
        _seedService = seedService;
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

        //Move to a service later on!!!
                bool result = false;
                try
                {
                    await _seedService.SeedRoles();
                    var roleName = "user";

                    if (!await _userManager.Users.AnyAsync())
                        roleName = "admin";
                    else
                        roleName = "user";


                    CustomIdentityUser customIdentityUser = viewModel;
                    await _userManager.CreateAsync(customIdentityUser, viewModel.Password);

                    await _userManager.AddToRoleAsync(customIdentityUser, roleName);

                    UserEntity userEntity = viewModel;
                    _identityContext.UsersInformations.Add(userEntity);
                    await _identityContext.SaveChangesAsync();
                    result = true;

                } catch
                {
                    result = false;
                }


                if (result == true)
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
