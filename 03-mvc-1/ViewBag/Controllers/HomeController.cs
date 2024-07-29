using Microsoft.AspNetCore.Mvc;

namespace ViewBag.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public ViewResult Index()
    {
        ViewBag.Username = "Kermit the Frog";
        ViewBag.Muppets = new List<string>()
            {
                "Kermit the Frog",
                "Miss Piggy",
                "Fozzie Bear",
                "Gonzo the Great"
            };
        return View("Index");
    }
}