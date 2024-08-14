using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DadJokes.Models;
using DadJokes.Services;

namespace DadJokes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDadJokeAPIService _jokeService;
    private readonly string _endpoint = "https://icanhazdadjoke.com/";

    public HomeController(ILogger<HomeController> logger, IDadJokeAPIService jokeService)
    {
        _logger = logger;
        _jokeService = jokeService;
    }

    [HttpGet("")]
    async public Task<IActionResult> Index()
    {
        var joke = await _jokeService.GetDadJokeAsync(_endpoint);
        return View("Index", joke);
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
