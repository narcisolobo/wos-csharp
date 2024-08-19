using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DadJokes.Models;

public class Profile
{
    [Key]
    public int ProfileId { get; set; }

    [ForeignKey("DadJokeUserId")]
    public virtual DadJokeUser? DadJokeUser { get; set; }

    [MaxLength(45)]
    [Display(Name = "First name")]
    [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
    public string? FirstName { get; set; }

    [MaxLength(45)]
    [Display(Name = "Last name")]
    [MinLength(2, ErrorMessage = "Last name must be at least two characters.")]
    public string? LastName { get; set; }

    public string? ImageUrl { get; set; }
}
