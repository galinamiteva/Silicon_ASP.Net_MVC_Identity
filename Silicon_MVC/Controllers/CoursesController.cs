using Microsoft.AspNetCore.Mvc;

namespace Silicon_MVC.Controllers;

public class CoursesController : Controller
{
    public IActionResult Index()
    {
        ViewData["Title"] = "Courses";
        return View();
    }
}
