using ManyToMany.Context;
using ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.Controllers;

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
        var movies = _context.Movies.ToList();
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
            var movies = _context.Movies.ToList();
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
}
