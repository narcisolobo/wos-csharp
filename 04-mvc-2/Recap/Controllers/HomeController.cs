using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Recap.Models;

namespace Recap.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Index(string? message)
    {
        if (message != null)
        {
            ViewBag.Message = message;
        }

        // display the form
        return View("Index");
    }

    [HttpPost("usernames/remember")]
    public IActionResult RememberUsername(Username username)
    {
        // check if the form is valid
        if (!ModelState.IsValid)
        {
            _logger.LogInformation("Username form is invalid.");
            // display the form with validation errors
            return View("Index");
        }

        _logger.LogInformation("Username form is valid.");

        // save the username content in session
        HttpContext.Session.SetString("username", username.Content);
        // redirect to the movie controller dashboard action
        return RedirectToAction("MovieDashboard", "Movie");
    }

    [HttpGet("logout")]
    public RedirectToActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index");
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
