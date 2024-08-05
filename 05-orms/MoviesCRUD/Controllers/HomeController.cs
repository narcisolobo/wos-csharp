using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MoviesCRUD.Context;
using MoviesCRUD.Models;

namespace MoviesCRUD.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationContext context)
    {
        _logger = logger;
        _context = context;
    }

    private void AddNewMovie()
    {
        var newMovie = new Movie()
        {
            Title = "The Princess Bride",
            DurationInMInutes = 120
        };

        _context.Movies.Add(newMovie);
        _context.SaveChanges();
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        var movies = _context.Movies.ToList();
        return View("Index", movies);
    }

    [HttpGet("movies/new")]
    public ViewResult NewMovie()
    {
        return View("NewMovie");
    }

    [HttpPost("movies/create")]
    public IActionResult CreateMovie(Movie newMovie)
    {
        if (!ModelState.IsValid)
        {
            return View("NewMovie");
        }

        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("movies/{movieId:int}")]
    public IActionResult ShowMovie(int movieId)
    {
        var movie = _context.Movies
            .FirstOrDefault((movie) => movie.MovieId == movieId);

        if (movie is null)
        {
            return RedirectToAction("MovieNotFound");
        }

        return View("ShowMovie", movie);
    }

    [HttpGet("movies/{movieId:int}/edit")]
    public IActionResult EditMovie(int movieId)
    {
        var movie = _context.Movies
            .FirstOrDefault((movie) => movie.MovieId == movieId);

        if (movie is null)
        {
            return RedirectToAction("MovieNotFound");
        }

        return View("EditMovie", movie);
    }

    [HttpPost("movies/{movieId:int}/update")]
    public IActionResult UpdateMovie(int movieId, Movie updatedMovie)
    {
        var existingMovie = _context.Movies
            .FirstOrDefault((movie) => movie.MovieId == movieId);

        if (existingMovie is null)
        {
            return RedirectToAction("MovieNotFound");
        }

        existingMovie.Title = updatedMovie.Title;
        existingMovie.DurationInMInutes = updatedMovie.DurationInMInutes;
        existingMovie.Rating = updatedMovie.Rating;
        existingMovie.UpdatedAt = DateTime.Now;

        _context.SaveChanges();
        return RedirectToAction("ShowMovie", new { movieId });
    }

    [HttpPost("movies/{movieId:int}/delete")]
    public IActionResult DeleteMovie(int movieId)
    {
        var existingMovie = _context.Movies
            .FirstOrDefault((movie) => movie.MovieId == movieId);

        if (existingMovie is null)
        {
            return RedirectToAction("MovieNotFound");
        }

        _context.Movies.Remove(existingMovie);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet("/movies/not-found")]
    public ViewResult MovieNotFound()
    {
        return View("NotFound");
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
