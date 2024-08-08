#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace BeltExam.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required]
    [MinLength(2)]
    public string Title { get; set; }

    [Required]
    [MinLength(2)]
    public string Genre { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime? ReleaseDate { get; set; }

    [Required]
    [MinLength(10)]
    public string Synopsis { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public List<Rating> Ratings { get; set; } = new List<Rating>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
