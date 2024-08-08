using BeltExam.Attributes;
using BeltExam.Context;
using BeltExam.Models;
using BeltExam.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeltExam.Controllers;

public class MovieController : Controller
{
    private readonly ApplicationContext _context;

    public MovieController(ApplicationContext context)
    {
        _context = context;
    }

    [SessionCheck]
    [HttpGet("movies")]
    public IActionResult Movies()
    {
        int? userId = HttpContext.Session.GetInt32("userId");
        if (userId is null)
        {
            return RedirectToAction("Index");
        }

        var user = _context.Users.FirstOrDefault((user) => user.UserId == userId);

        if (user is null)
        {
            return RedirectToAction("Index");
        }

        var viewModel = new MoviesPageViewModel()
        {
            User = user,
            Movies = _context.Movies
                .Include((m) => m.User)
                .ToList(),
        };

        return View("Movies", viewModel);
    }

    [SessionCheck]
    [HttpGet("movies/new")]
    public ViewResult NewMovie()
    {
        var movie = new Movie()
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
        };

        return View("NewMovie", movie);
    }

    [SessionCheck]
    [HttpPost("movies/create")]
    public IActionResult CreateMovie(Movie newMovie)
    {
        if (!ModelState.IsValid)
        {
            // form is invalid
            var movie = new Movie()
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
            };

            return View("NewMovie", movie);
        }

        // form is valid, create movie
        _context.Movies.Add(newMovie);
        _context.SaveChanges();
        return RedirectToAction("Movies");
    }

    [SessionCheck]
    [HttpGet("movies/{movieId:int}")]
    public IActionResult MovieDetails(int movieId)
    {
        var movie = _context.Movies.FirstOrDefault((m) => m.MovieId == movieId);
        if (movie is null)
        {
            return NotFound();
        }

        var viewModel = new MovieDetailsViewModel()
        {
            UserId = (int)HttpContext.Session.GetInt32("userId"),
            Movie = movie,
            Rating = new Rating()
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
            }
        };

        return View("MovieDetails", viewModel);
    }

    [HttpPost("ratings/create")]
    public IActionResult CreateRating(Rating newRating)
    {
        if (!ModelState.IsValid)
        {
            var movie = _context.Movies.FirstOrDefault((m) => m.MovieId == newRating.MovieId);
            if (movie is null)
            {
                return NotFound();
            }

            var viewModel = new MovieDetailsViewModel()
            {
                UserId = (int)HttpContext.Session.GetInt32("userId"),
                Movie = movie,
                Rating = new Rating()
                {
                    UserId = (int)HttpContext.Session.GetInt32("userId"),
                }
            };
            return View("MovieDetails", viewModel);
        }

        _context.Ratings.Add(newRating);
        _context.SaveChanges();
        return RedirectToAction("MovieDetails", new { movieId = newRating.MovieId });
    }
}
