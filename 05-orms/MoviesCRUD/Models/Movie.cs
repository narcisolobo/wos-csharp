#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace MoviesCRUD.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Please enter title.")]
    [MinLength(2, ErrorMessage = "Title must be at least two characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter duration in minutes.")]
    [Range(1, 1000, ErrorMessage = "Duration must be between 1 and 1000 minutes.")]
    public int? DurationInMInutes { get; set; }

    [Required(ErrorMessage = "Please enter rating.")]
    [Range(1, 11, ErrorMessage = "Rating must be between 1 and 10.")]
    public double? Rating { get; set; } = 0;

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
