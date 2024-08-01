using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SecretPassword.Models;

namespace SecretPassword.Controllers;

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
        return View("Index");
    }

    [HttpPost("process-password")]
    public IActionResult ProcessPassword(Password password)
    {
        if (!ModelState.IsValid)
        {
            return View("Index");
        }

        return RedirectToAction("InnerLair");
    }

    [HttpGet("inner-lair")]
    public ViewResult InnerLair()
    {
        return View("InnerLair");
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
