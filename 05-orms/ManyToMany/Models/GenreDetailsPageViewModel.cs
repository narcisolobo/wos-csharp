namespace ManyToMany.Models;

public class GenreDetailsPageViewModel
{
    public Genre? Genre { get; set; }
    public Association? Association { get; set; }
    public List<Movie> Movies { get; set; } = [];
}
