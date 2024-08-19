using DadJokes.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.Controllers;

public class AccountController(DadJokesContext context) : Controller
{
    private readonly DadJokesContext _context = context;

    [HttpGet("accounts/login")]
    public IActionResult LoginUser()
    {
        return View("LoginUser");
    }
}
