#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using OneToMany.Attributes;

namespace OneToMany.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [MaxLength(45)]
    [Required(ErrorMessage = "Please enter title.")]
    [MinLength(2, ErrorMessage = "Title must be at least two characters.")]
    public string Title { get; set; }

    [MaxLength(45)]
    [Required(ErrorMessage = "Please enter director.")]
    [MinLength(2, ErrorMessage = "Director must be at least two characters.")]
    public string Director { get; set; }

    [MaxLength(45)]
    [Required(ErrorMessage = "Please enter genre.")]
    [MinLength(2, ErrorMessage = "Genre must be at least two characters.")]
    public string Genre { get; set; }

    [Display(Name = "Release date")]
    [Required(ErrorMessage = "Please enter release date.")]
    [PastDate(ErrorMessage = "Release date must be in the past.")]
    public DateTime? ReleaseDate { get; set; }

    [Required(ErrorMessage = "Please enter synopsis.")]
    [MinLength(10, ErrorMessage = "Synopsis must be at least ten characters.")]
    public string Synopsis { get; set; }

    [Display(Name = "Duration in minutes")]
    [Required(ErrorMessage = "Please enter duration in minutes.")]
    [Range(1, 1000, ErrorMessage = "Duration must be between 1 and 1000 minutes.")]
    public int? DurationInMinutes { get; set; }

    [Required(ErrorMessage = "Please enter rating.")]
    [Range(0, 11, ErrorMessage = "Rating must be between 0 and 10.")]
    public double? Rating { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int MovieBuffId { get; set; }

    public MovieBuff? MovieBuff { get; set; }
}
