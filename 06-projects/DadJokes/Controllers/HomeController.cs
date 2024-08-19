using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DadJokes.Models;
using DadJokes.Services;

namespace DadJokes.Controllers;

public class HomeController : Controller
{

    public HomeController() { }

    [HttpGet("")]
    public RedirectToActionResult Index()
    {
        return RedirectToAction("RandomJoke", "DadJoke");
    }

    [HttpGet("privacy")]
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
