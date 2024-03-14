using Infrastructure.Entities;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon_MVC.ViewModels;

namespace Silicon_MVC.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> singInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager= userManager;  
    private readonly SignInManager<UserEntity> _signInManager=singInManager;


    #region Sing Up

    [HttpGet]
    [Route ("/signup")]
    public IActionResult SignUp()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        return View();
    }


    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpModel viewModel)
    {
        if(ModelState.IsValid)
        {
            var exists = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email);
        }
    }

    #endregion
}
