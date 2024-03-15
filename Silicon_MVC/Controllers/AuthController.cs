using Infrastructure.Entities;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Silicon_MVC.ViewModels;

namespace Silicon_MVC.Controllers;

public class AuthController(UserManager<UserEntity> userManager, UserService userService, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserService _userService = userService;
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;


    public IActionResult Index()
    {
        ViewData["Title"] = "Profile";
        return View();
    }

    #region SignUp
    [Route("/signup")]
    [HttpGet]

    //public IActionResult SignUp()
    //{
    //    if (_signInManager.IsSignedIn(User))
    //        return RedirectToAction("Details", "Account");
    //    return View(new SignUpViewModel());
    //}
    public IActionResult SignUp()
    {
        var viewModel = new SignUpViewModel();
        return View(viewModel);
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            
            //var exist = await _userManager.Users.AnyAsync(x => x.Email == viewModel.Form.Email);
            //if (exist)


            var exist = await _userManager.FindByEmailAsync(viewModel.Form.Email);
            if (exist != null)
            {
                ModelState.AddModelError("Email", "Email already exists");
                ViewData["ErrorMessage"] = "User with the same email already exists";
                return View(viewModel);
            }

            var userEntity = new UserEntity
            {
                FirstName = viewModel.Form.FirstName,
                LastName = viewModel.Form.LastName,
                Email = viewModel.Form.Email,
                UserName = viewModel.Form.Email,
                Created = DateTime.Now
            };

            var result = await _userManager.CreateAsync(userEntity, viewModel.Form.Password);
            if (result.Succeeded)
            {
               
                return RedirectToAction("signin");
            }
        }

        return View(viewModel);
    }
    #endregion

    #region Sign In
    [HttpGet]
    [Route("/signin")]

   

    public IActionResult SignIn()
    {
        if (_signInManager.IsSignedIn(User))
            return RedirectToAction("Details", "Account");

        return View(new SignInViewModel());
    }

    //public IActionResult SignIn(string returnUrl)
    //{
    //    if (_signInManager.IsSignedIn(User))
    //        return RedirectToAction("Details", "Account");
    //    ViewData["ReturnUrl"] = returnUrl ?? Url.Content("~/");

    //    return View(new SignInViewModel());
    //}


    [Route("/signin")]
    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var result = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, viewModel.Form.RememberMe, false);
            if (result.Succeeded)
                return RedirectToAction("Details", "Account");
        }

        ModelState.AddModelError("Email", "Incorrect email or password");
        viewModel.ErrorMessage = "Incorrect email or password";
        return View(viewModel);


    }

    //public async Task<IActionResult> SignIn(SignInViewModel viewModel, string returnUrl)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        var result = await _signInManager.PasswordSignInAsync(viewModel.Form.Email, viewModel.Form.Password, viewModel.Form.RememberMe, false);
    //        if (result.Succeeded)
    //        {
    //            if(!string.IsNullOrEmpty(returnUrl)&&Url.IsLocalUrl(returnUrl))
    //            return RedirectToAction("Details", "Account");
    //        }

    //    }

    //    ModelState.AddModelError("Email", "Incorrect email or password");
    //    viewModel.ErrorMessage = "Incorrect email or password";
    //    return View(viewModel);


    //}

    #endregion

    #region Sign Out
    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Default", "Home");
    }
    #endregion

    


}
