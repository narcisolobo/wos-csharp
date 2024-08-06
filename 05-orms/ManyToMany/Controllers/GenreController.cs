using ManyToMany.Context;
using ManyToMany.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ManyToMany.Controllers;

public class GenreController : Controller
{
    private readonly ApplicationContext _context;

    public GenreController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("genres")]
    public ViewResult Genres()
    {
        var genres = _context.Genres.ToList();
        var genresPageViewModel = new GenresPageViewModel()
        {
            Genre = new Genre(),
            Genres = genres,
        };
        return View("Genres", genresPageViewModel);
    }

    [HttpPost("genres/create")]
    public IActionResult CreateGenre(Genre newGenre)
    {
        if (!ModelState.IsValid)
        {
            var genres = _context.Genres.ToList();
            var genresPageViewModel = new GenresPageViewModel()
            {
                Genre = new Genre(),
                Genres = genres,
            };

            return View("Genres", genresPageViewModel);
        }

        _context.Genres.Add(newGenre);
        _context.SaveChanges();
        return RedirectToAction("Genres");
    }

    [HttpGet("genres/{genreId:int}")]
    public IActionResult GenreDetails(int genreId)
    {
        var genre = _context.Genres
            .Include((g) => g.AssociatedMovies)
            .ThenInclude((a) => a.Movie)
            .FirstOrDefault((g) => g.GenreId == genreId);

        if (genre is null)
        {
            return NotFound();
        }

        var unassociatedMovies = _context.Movies
            .Where((m) => !m.AssociatedGenres.Any((a) => a.GenreId == genreId))
            .ToList();

        var viewModel = new GenreDetailsPageViewModel()
        {
            Genre = genre,
            Association = new Association()
            {
                GenreId = genreId
            },
            Movies = unassociatedMovies,
        };

        return View("GenreDetails", viewModel);
    }

    [HttpPost("genres/add-movie")]
    public IActionResult AddMovieToGenre(int genreId, int movieId)
    {
        var newAssociation = new Association()
        {
            GenreId = genreId,
            MovieId = movieId,
        };
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();
        return RedirectToAction("GenreDetails", new { genreId });
    }
}
