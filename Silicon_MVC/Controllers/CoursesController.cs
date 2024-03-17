using Microsoft.AspNetCore.Mvc;
using Silicon_MVC.Views;
namespace Silicon_MVC.Controllers;

public class CoursesController : Controller
{
    [Route("/courses")]
    public IActionResult Index()
    {
        var viewModel = new CoursesIndexViewModel();


        ViewData["Title"] = viewModel.Title;
        return View(viewModel);
    }
}
