using System.ComponentModel.DataAnnotations;

namespace ImagekitUpload.Models;

public class Pet
{
    [Key]
    public int PetId { get; set; }
    public string? PetName { get; set; }
    public string? PetImageUrl { get; set; } // here is the image url property
    public string? PetImageDescription { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
