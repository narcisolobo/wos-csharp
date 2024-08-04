#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Recap.Attributes;

namespace Recap.Models;

public class Movie
{
    public int MovieId { get; set; }

    [Required(ErrorMessage = "Please enter title.")]
    [MinLength(2, ErrorMessage = "Title must be at least two characters.")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please enter director.")]
    [MinLength(2, ErrorMessage = "Director must be at least two characters.")]
    public string Director { get; set; }

    [Required(ErrorMessage = "Please enter genre.")]
    [MinLength(2, ErrorMessage = "Genre must be at least two characters.")]
    public string Genre { get; set; }

    // use a custom validation here if you like
    // to validate that a release date was in the past
    [PastDate]
    [Required(ErrorMessage = "Please enter release date.")]
    public DateTime? ReleaseDate { get; set; }

    [Required(ErrorMessage = "Please select rating.")]
    [Range(typeof(double), "0", "11", ErrorMessage = "Rating out of range.")]
    public double? Rating { get; set; }

    [Required(ErrorMessage = "Please enter duration.")]
    [Range(1, 1000, ErrorMessage = "Duration out of range.")]
    public int? DurationInMinutes { get; set; }
}
