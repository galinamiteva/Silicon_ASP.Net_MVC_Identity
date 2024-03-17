using Microsoft.AspNetCore.Mvc;
using Silicon_MVC.ViewModels;

namespace Silicon_MVC.Controllers;

public class WantController : Controller
{
    [Route("/dontwant")]
    [HttpGet]
    public IActionResult Want()
    {
        var viewModel = new WantViewModel();
        return View(viewModel); ;
    }

    [Route("/dontwant")]
    [HttpPost]
    public IActionResult Want(WantViewModel viewModel)
    {
        if (!ModelState.IsValid)
            return View(viewModel);


        return RedirectToAction("Index");
    }

}
