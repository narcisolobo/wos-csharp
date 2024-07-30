using Microsoft.AspNetCore.Mvc;

namespace Redirecting.Controllers;

public class HomeController : Controller
{
    [HttpGet("")]
    public RedirectToActionResult Index()
    {
        return RedirectToAction("Home", new { word = "does this work" });
    }

    [HttpGet("home/{word}")]
    public ViewResult Home(string word)
    {
        ViewBag.Word = word;
        return View("Home");
    }

    [HttpGet("result/{favoriteResponse}")]
    public IActionResult ItDepends(string favoriteResponse)
    {
        if (favoriteResponse == "Redirect")
        {
            return RedirectToAction("Destination");
        }
        else if (favoriteResponse == "JSON")
        {
            return Json(new { favoriteResponse, fruit = "Banana" });
        }
        else
        {
            return View("ItDepends");
        }
    }

    [HttpGet("destination")]
    public ViewResult Destination()
    {
        return View("Destination");
    }
}
