using Recap.Models;

namespace Recap.Interfaces;

public interface IMovieService
{
    List<Movie> GetMovies();
    void AddMovie(Movie movie);

    Movie GetMovieById(int id);

    void UpdateMovie(Movie movie);

    void DeleteMovie(int movieId);
}
