using Microsoft.AspNetCore.Mvc;
using Recap.Interfaces;
using Recap.Models;

namespace Recap.Controllers;

public class MovieController : Controller
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("movies/dashboard")]
    public IActionResult MovieDashboard()
    {
        // redirect to home if there is no username
        if (HttpContext.Session.GetString("username") == null)
        {
            return RedirectToAction("Index", "Home", new { message = "not-allowed" });
        }

        // pull username from session
        var username = HttpContext.Session.GetString("username");
        ViewBag.Username = username;
        // destination after redirect
        return View("MovieDashboard");
    }

    [HttpGet("movies")]
    public IActionResult AllMovies()
    {
        // redirect to home if there is no username
        if (HttpContext.Session.GetString("username") == null)
        {
            return RedirectToAction("Index", "Home", new { message = "not-allowed" });
        }

        var movies = _movieService.GetMovies();
        return View("AllMovies", movies);
    }

    [HttpGet("movies/new")]
    public IActionResult NewMovie()
    {
        // redirect to home if there is no username
        if (HttpContext.Session.GetString("username") == null)
        {
            return RedirectToAction("Index", "Home", new { message = "not-allowed" });
        }

        return View("NewMovie");
    }

    [HttpPost("movies/create")]
    public IActionResult CreateMovie(Movie movie)
    {
        if (!ModelState.IsValid)
        {
            // form is invalid, show errors
            return View("NewMovie");
        }

        // form is valid, add movie
        _movieService.AddMovie(movie);
        return RedirectToAction("AllMovies");
    }
}
