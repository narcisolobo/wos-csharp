using BeltExam.Models;

namespace BeltExam.ViewModels;

public class MoviesPageViewModel
{
    public User? User { get; set; }
    public List<Movie> Movies { get; set; } = new List<Movie>();
}
