using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OneToMany.Context;
using OneToMany.Models;

namespace OneToMany.Controllers;

public class MovieBuffController : Controller
{
    private readonly ApplicationContext _context;

    public MovieBuffController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet("movie-buffs")]
    public ViewResult MovieBuffs()
    {
        var movieBuffs = _context.MovieBuffs
            .Include((mb) => mb.Movies)
            .ToList();
        var movieBuffsPageViewModel = new MovieBuffsPageViewModel()
        {
            MovieBuff = new MovieBuff(),
            MovieBuffs = movieBuffs,
        };

        return View("MovieBuffs", movieBuffsPageViewModel);
    }

    [HttpPost("movie-buffs/create")]
    public IActionResult CreateMovieBuff(MovieBuff newMovieBuff)
    {
        if (!ModelState.IsValid)
        {
            var movieBuffs = _context.MovieBuffs
                .Include((mb) => mb.Movies)
                .ToList();
            var movieBuffsPageViewModel = new MovieBuffsPageViewModel()
            {
                MovieBuff = new MovieBuff(),
                MovieBuffs = movieBuffs,
            };
            return View("MovieBuffs", movieBuffsPageViewModel);
        };

        _context.MovieBuffs.Add(newMovieBuff);
        _context.SaveChanges();
        return RedirectToAction("MovieBuffs");
    }
}
