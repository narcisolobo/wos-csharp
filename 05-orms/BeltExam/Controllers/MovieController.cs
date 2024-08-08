using System.Reflection;
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
    public IActionResult Movies(string? property)
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
            Movies = GetSortedMovies(property ?? "CreatedAt"),
        };

        return View("Movies", viewModel);
    }

    [HttpPost("movies/sort")]
    public RedirectToActionResult SortMovies(string property)
    {
        return RedirectToAction("Movies", new { property });
    }

    public List<Movie> GetSortedMovies(string property)
    {
        switch (property)
        {
            case "Title":
                return _context.Movies
                .Include((m) => m.User)
                .OrderBy((m) => m.Title)
                .ToList();
            case "Genre":
                return _context.Movies
                .Include((m) => m.User)
                .OrderBy((m) => m.Genre)
                .ToList();
            default:
                return _context.Movies
                    .Include((m) => m.User)
                    .OrderBy((m) => m.CreatedAt)
                    .ToList();
        }
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
        var movie = _context.Movies
            .Include((m) => m.Ratings)
            .FirstOrDefault((m) => m.MovieId == movieId);
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
                MovieId = movieId,
            }
        };

        return View("MovieDetails", viewModel);
    }

    [SessionCheck]
    [HttpPost("movies/{movieId:int}/ratings/create")]
    public IActionResult CreateRating(int movieId, Rating newRating)
    {
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);

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

        _context.Ratings.Add(newRating);
        _context.SaveChanges();
        return RedirectToAction("MovieDetails", new { movieId });
    }

    [SessionCheck]
    [HttpGet("movies/{movieId:int}/edit")]
    public IActionResult EditMovie(int movieId)
    {
        var movie = _context.Movies.FirstOrDefault((m) => m.MovieId == movieId);

        if (movie is null)
        {
            return NotFound();
        }

        return View("EditMovie", movie);
    }

    [SessionCheck]
    [HttpPost("movies/{movieId:int}/update")]
    public IActionResult UpdateMovie(int movieId, Movie updatedMovie)
    {
        var existingMovie = _context.Movies.FirstOrDefault((m) => m.MovieId == movieId);
        if (!ModelState.IsValid)
        {
            var message = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
            Console.WriteLine(message);
            var movie = _context.Movies.FirstOrDefault((m) => m.MovieId == movieId);

            if (movie is null)
            {
                return NotFound();
            }

            return View("EditMovie", movie);
        }

        existingMovie.Title = updatedMovie.Title;
        existingMovie.Genre = updatedMovie.Genre;
        existingMovie.ReleaseDate = updatedMovie.ReleaseDate;
        existingMovie.Synopsis = updatedMovie.Synopsis;
        existingMovie.UpdatedAt = updatedMovie.UpdatedAt;

        _context.SaveChanges();
        return RedirectToAction("MovieDetails", new { movieId });
    }

    [SessionCheck]
    [HttpPost("movies/{movieId:int}/delete")]
    public IActionResult DeleteMovie(int movieId)
    {
        Console.WriteLine("DELETEMOVIE METHOD INVOKED!!!");
        Console.WriteLine($"MOVIE ID: {movieId}");
        var existingMovie = _context.Movies.FirstOrDefault((m) => m.MovieId == movieId);

        if (existingMovie is null)
        {
            return NotFound();
        }

        _context.Movies.Remove(existingMovie);
        _context.SaveChanges();
        return RedirectToAction("Movies");
    }
}
