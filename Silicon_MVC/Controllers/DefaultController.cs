using Microsoft.AspNetCore.Mvc;

namespace Silicon_MVC.Controllers;

public class DefaultController : Controller
{
    [Route("/")]
    public IActionResult Home() => View();



    [Route("/error")]
    public IActionResult Error404(int statusCode) => View();


    [Route("/dehied")]
    public IActionResult AccessDenied(int statusCode) => View();
}
