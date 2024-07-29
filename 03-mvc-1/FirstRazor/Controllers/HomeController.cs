using Microsoft.AspNetCore.Mvc;

namespace FirstRazor.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpGet("about")]
    public ViewResult About()
    {
        return View("About");
    }
}
