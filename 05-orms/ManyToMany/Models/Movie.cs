#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models;

public class Movie
{
    [Key]
    public int MovieId { get; set; }

    [MaxLength(45)]
    [Required(ErrorMessage = "Please enter title.")]
    [MinLength(2, ErrorMessage = "Title must be at least two characters.")]
    public string Title { get; set; }

    // navigational property
    public List<Association> AssociatedGenres { get; set; } = [];

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
