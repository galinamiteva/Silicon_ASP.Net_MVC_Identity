using Microsoft.AspNetCore.Mvc;
using Silicon_MVC.ViewModels;
using Silicon_MVC.Views;

namespace Silicon_MVC.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Home()
    {
        var viewModel = new HomeIndexViewModel();

        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }



    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();


    [Route("/dehied")]
    public IActionResult AccessDenied(int statusCode) => View();

    public IActionResult DeleteConfirmation()
    {
        return View();
    }

    
}
