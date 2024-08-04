using Recap.Interfaces;
using Recap.Models;

namespace Recap.Services;

public class MovieService : IMovieService
{
    private readonly List<Movie> _movies;

    public MovieService()
    {
        _movies =
        [
            new() {
                MovieId = 1,
                Title = "Inception",
                Director = "Christopher Nolan",
                Genre = "Sci-Fi",
                ReleaseDate = new DateTime(2010, 7, 16),
                Rating = 8.8,
                DurationInMinutes = 148
            },
            new() {
                MovieId = 2,
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Genre = "Crime",
                ReleaseDate = new DateTime(1972, 3, 24),
                Rating = 9.2,
                DurationInMinutes = 175
            },
            new() {
                MovieId = 3,
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Genre = "Action",
                ReleaseDate = new DateTime(2008, 7, 18),
                Rating = 9.0,
                DurationInMinutes = 152
            },
            new() {
                MovieId = 4,
                Title = "Pulp Fiction",
                Director = "Quentin Tarantino",
                Genre = "Crime",
                ReleaseDate = new DateTime(1994, 10, 14),
                Rating = 8.9,
                DurationInMinutes = 154
            },
            new() {
                MovieId = 5,
                Title = "Schindler's List",
                Director = "Steven Spielberg",
                Genre = "Biography",
                ReleaseDate = new DateTime(1993, 12, 15),
                Rating = 8.9,
                DurationInMinutes = 195
            },
            new() {
                MovieId = 6,
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Genre = "Drama",
                ReleaseDate = new DateTime(1994, 9, 23),
                Rating = 9.3,
                DurationInMinutes = 142
            },
            new() {
                MovieId = 7,
                Title = "Forrest Gump",
                Director = "Robert Zemeckis",
                Genre = "Drama",
                ReleaseDate = new DateTime(1994, 7, 6),
                Rating = 8.8,
                DurationInMinutes = 142
            },
            new() {
                MovieId = 8,
                Title = "Fight Club",
                Director = "David Fincher",
                Genre = "Drama",
                ReleaseDate = new DateTime(1999, 10, 15),
                Rating = 8.8,
                DurationInMinutes = 139
            },
            new() {
                MovieId = 9,
                Title = "The Matrix",
                Director = "Lana Wachowski, Lilly Wachowski",
                Genre = "Sci-Fi",
                ReleaseDate = new DateTime(1999, 3, 31),
                Rating = 8.7,
                DurationInMinutes = 136
            },
            new() {
                MovieId = 10,
                Title = "The Lord of the Rings: The Fellowship of the Ring",
                Director = "Peter Jackson",
                Genre = "Fantasy",
                ReleaseDate = new DateTime(2001, 12, 19),
                Rating = 8.8,
                DurationInMinutes = 178
            }
        ];
    }

    public void AddMovie(Movie movie)
    {
        // programmatically increment highest ID
        movie.MovieId = _movies.Max((m) => m.MovieId) + 1;
        _movies.Add(movie);
    }

    public void DeleteMovie(int movieId)
    {
        var movie = _movies
            .FirstOrDefault((m) => m.MovieId == movieId)
            ?? throw new ArgumentException("movie not found.");
        _movies.Remove(movie);
        return;
    }

    public Movie GetMovieById(int movieId)
    {
        var movie = _movies
            .FirstOrDefault((m) => m.MovieId == movieId)
            ?? throw new ArgumentException("movie not found.");
        return movie;
    }

    public List<Movie> GetMovies()
    {
        return _movies;
    }

    public void UpdateMovie(Movie upDatedMovie)
    {
        var movie = _movies
            .FirstOrDefault((m) => m.MovieId == upDatedMovie.MovieId)
            ?? throw new ArgumentException("movie not found.");

        movie.Title = upDatedMovie.Title;
        movie.Director = upDatedMovie.Director;
        movie.Genre = upDatedMovie.Genre;
        movie.ReleaseDate = upDatedMovie.ReleaseDate;
        movie.Rating = upDatedMovie.Rating;
        movie.DurationInMinutes = upDatedMovie.DurationInMinutes;
        return;
    }
}
