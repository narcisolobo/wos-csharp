using Microsoft.AspNetCore.Mvc;
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
        var movies = _context.Movies.ToList();
        var moviesPageViewModel = new MoviesPageViewModel()
        {
            Movie = new Movie(),
            Movies = movies,
        };
        return View("Movies", moviesPageViewModel);
    }
}
