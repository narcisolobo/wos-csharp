#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace OneToMany.Models;

public class MovieBuff
{
    [Key]
    public int MovieBuffId { get; set; }

    [MaxLength(45)]
    [Display(Name = "First name")]
    [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
    [Required(ErrorMessage = "Please enter first name.")]
    public string FirstName { get; set; }

    [MaxLength(45)]
    [Display(Name = "Last name")]
    [MinLength(2, ErrorMessage = "Last name must be at least two characters.")]
    [Required(ErrorMessage = "Please enter last name.")]
    public string LastName { get; set; }

    // computed property
    public string FullName => $"{FirstName} {LastName}";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // navigation property tracks the movies for one buff
    public List<Movie> Movies { get; set; } = [];
}
