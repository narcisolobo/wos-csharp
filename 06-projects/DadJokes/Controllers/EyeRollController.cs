using DadJokes.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.Controllers;

public class EyeRollController(DadJokesContext context) : Controller
{
    private readonly DadJokesContext _context = context;

    [HttpPost("eyerolls/create")]
    public IActionResult CreateEyeRoll()
    {
        var user = HttpContext.User;
        Console.WriteLine("HERE IS THE USER!!!");
        Console.WriteLine(user);
        if (user.Identity is not null)
        {
            if (!user.Identity.IsAuthenticated)
            {
                return RedirectToAction("LoginReg", "Account");
            }
        }

        return RedirectToAction("RandomJoke", "DadJoke");
    }
}
