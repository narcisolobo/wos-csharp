using BeltExam.Models;
namespace BeltExam.ViewModels;

public class MovieDetailsViewModel
{
    public int? UserId { get; set; }
    public Movie? Movie { get; set; }
    public Rating? Rating { get; set; }
}
