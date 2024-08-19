using DadJokes.Areas.Identity.Data;
using DadJokes.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DadJokes.Controllers;

public class DadJokeController(DadJokesContext context, IDadJokeAPIService service) : Controller
{
    private readonly DadJokesContext _context = context;
    private readonly IDadJokeAPIService _jokeService = service;
    private readonly string _endpoint = "https://icanhazdadjoke.com/";

    [HttpGet("jokes/random")]
    async public Task<IActionResult> RandomJoke()
    {
        var joke = await _jokeService.GetDadJokeAsync(_endpoint);

        if (!_context.DadJokes.Any((j) => j.DadJokeId == joke.DadJokeId))
        {
            _context.DadJokes.Add(joke);
            _context.SaveChanges();
        }

        var dadJoke = _context.DadJokes
            .Include((d) => d.EyeRolls)
            .FirstOrDefault((d) => d.DadJokeId == joke.DadJokeId);

        if (dadJoke == null)
        {
            return NotFound();
        }

        return View("RandomJoke", dadJoke);
    }
}
