namespace ManyToMany.Models;

public class MoviesPageViewModel
{
    public Movie? Movie { get; set; }
    public List<Movie> Movies { get; set; } = [];
}
