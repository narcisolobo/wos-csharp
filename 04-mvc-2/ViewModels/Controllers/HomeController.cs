using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViewModels.Models;

namespace ViewModels.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var message = new Message()
        {
            Content = "This message is coming from the controller."
        };
        return View("Index", message);
    }

    [HttpGet("about")]
    public ViewResult About()
    {
        var subtitle = "This is the About Us page.";
        return View("About", subtitle);
    }

    [HttpGet("projects")]
    public ViewResult Projects()
    {
        var projects = new List<string>()
        {
            "Project 1",
            "Project 2",
            "Project 3"
        };
        return View("Projects", projects);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
