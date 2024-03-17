using Microsoft.AspNetCore.Mvc;

namespace Silicon_MVC.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()

    {
        ViewData["Title"] = "Contact Us";
        return View();
    }
}
