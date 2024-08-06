namespace ManyToMany.Models;

public class GenresPageViewModel
{
    public Genre? Genre { get; set; }
    public List<Genre> Genres { get; set; } = [];
}
