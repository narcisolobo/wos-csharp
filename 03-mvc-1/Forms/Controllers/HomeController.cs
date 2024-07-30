using Microsoft.AspNetCore.Mvc;

namespace Forms.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        return View("Index");
    }

    [HttpPost("process")]
    public ViewResult Process(string username, string email)
    {
        ViewBag.Username = username;
        ViewBag.Email = email;
        return View("Process");
    }
}
