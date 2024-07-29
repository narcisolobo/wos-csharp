using Microsoft.AspNetCore.Mvc;

namespace RazorDeeperDive.Controllers;

public class MainController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View();
    }

    [HttpGet("jinja")]
    public ViewResult Jinja()
    {
        return View("Jinja");
    }
}
