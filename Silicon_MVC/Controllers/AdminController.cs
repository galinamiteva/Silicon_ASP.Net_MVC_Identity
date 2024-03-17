using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Silicon_MVC.Controllers;

[Authorize(Policy ="Admins")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }


    [Authorize(Policy = "CIO")]

    public IActionResult Settings()
    {
        return View();
    }
}
