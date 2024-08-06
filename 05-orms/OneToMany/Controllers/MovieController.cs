using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToMany.Context;
using OneToMany.Models;

namespace OneToMany.Controllers;

public class MovieController : Controller
{
    private readonly ApplicationContext _context;

    public MovieController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("movies")]
    public ViewResult Movies()
    {
        var movieBuffs = _context.MovieBuffs.ToList();
        ViewBag.MovieBuffs = movieBuffs;

        var movies = _context.Movies
            .Include((m) => m.MovieBuff)
            .ToList();
        var moviesPageViewModel = new MoviesPageViewModel()
        {
            Movie = new Movie(),
            Movies = movies,
        };
        return View("Movies", moviesPageViewModel);
    }

    [HttpPost("movies/create")]
    public IActionResult CreateMovie(Movie newMovie)
    {
        if (!ModelState.IsValid)
        {
            var movieBuffs = _context.MovieBuffs.ToList();
            ViewBag.MovieBuffs = movieBuffs;

            var movies = _context.Movies
                .Include((m) => m.MovieBuff)
                .ToList();
            var moviesPageViewModel = new MoviesPageViewModel()
            {
                Movie = new Movie(),
                Movies = movies,
            };

            return View("Movies", moviesPageViewModel);
        }

        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        return RedirectToAction("Movies");
    }

    [HttpGet("movies/{movieId:int}")]
    public IActionResult MovieDetail(int movieId)
    {
        var movie = _context.Movies
            .Include((m) => m.MovieBuff)
            .FirstOrDefault((m) => m.MovieId == movieId);

        if (movie is null)
        {
            return NotFound();
        }

        return View("MovieDetails", movie);
    }
}
