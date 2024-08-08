using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BeltExam.Models;
using BeltExam.Context;
using BeltExam.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BeltExam.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index(string? message)
    {
        ViewBag.Message = message;

        var homePageViewModel = new HomePageViewModel()
        {
            User = new User(),
            LoginUser = new LoginUser(),
        };

        return View("Index", homePageViewModel);
    }

    [HttpPost("register")]
    public IActionResult Register(User newUser)
    {
        if (!ModelState.IsValid)
        {
            // form is invalid
            // show the form again with errors


            var homePageViewModel = new HomePageViewModel()
            {
                User = new User(),
                LoginUser = new LoginUser(),
            };
            return View("Index", homePageViewModel);
        }

        // form is valid
        // hash the user's password
        var hasher = new PasswordHasher<User>();
        newUser.Password = hasher.HashPassword(newUser, newUser.Password);

        // save the new user to the db
        _context.Users.Add(newUser);
        _context.SaveChanges();

        // login the user by storing their id in session
        HttpContext.Session.SetInt32("userId", newUser.UserId);

        // redirect user to movies
        // the second argument is the controller name
        return RedirectToAction("Movies", "Movie");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginUser loginUser)
    {
        if (!ModelState.IsValid)
        {
            // form is invalid
            // send them back to form to show errors
            var homePageViewModel = new HomePageViewModel()
            {
                User = new User(),
                LoginUser = new LoginUser(),
            };
            return View("Index", homePageViewModel);
        }

        // form is valid check if email exists
        var user = _context.Users.SingleOrDefault((user) => user.Email == loginUser.Email);

        if (user is null)
        {
            // email does not exist show a message
            return RedirectToAction("Index", new { message = "invalid-credentials" });
        }

        // check their password
        var hasher = new PasswordHasher<User>();

        PasswordVerificationResult result = hasher.VerifyHashedPassword(
            user,
            user.Password,
            loginUser.Password
        );

        if (result == 0)
        {
            // password is incorrect
            return RedirectToAction("Index", new { message = "invalid-credentials" });
        }

        // password is correct
        // login the user by storing their id in session
        HttpContext.Session.SetInt32("userId", user.UserId);

        // redirect user to movies
        // the second argument is the controller name
        return RedirectToAction("Movies", "Movie");
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
