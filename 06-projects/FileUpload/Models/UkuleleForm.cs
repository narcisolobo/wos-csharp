using System.ComponentModel.DataAnnotations;
using FileUpload.Attributes;

namespace FileUpload.Models;

public class UkuleleForm
{
    [Required]
    public string? Brand { get; set; }

    [Required]
    public string? Model { get; set; }

    [Required]
    [ImageFile]
    public IFormFile? Image { get; set; }

    [Required]
    public string? Description { get; set; }
}
