using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FileUpload.Models;

namespace FileUpload.Controllers;

public class HomeController : Controller
{

    public HomeController() { }

    [HttpGet("")]
    public IActionResult Index()
    {
        return View("Index");
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
