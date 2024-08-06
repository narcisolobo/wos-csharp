#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace ManyToMany.Models;

public class Genre
{
    [Key]
    public int GenreId { get; set; }

    [MaxLength(45)]
    [Required(ErrorMessage = "Please enter name.")]
    [MinLength(2, ErrorMessage = "Name must be at least two characters.")]
    public string Name { get; set; }

    // navigational property
    public List<Association> AssociatedMovies { get; set; } = [];

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
