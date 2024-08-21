using System.ComponentModel.DataAnnotations;

namespace FileUpload.Models;

public class Ukulele
{
    [Key]
    public int UkuleleId { get; set; }

    public string? Brand { get; set; }
    public string? Model { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public bool IsStatic { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
