using System.ComponentModel.DataAnnotations;
using ImagekitUpload.Attributes;

namespace ImagekitUpload.Models;

public class PetForm
{
    [Display(Name = "Pet name:")]
    [Required(ErrorMessage = "Please enter your pet's name.")]
    public string? PetName { get; set; }

    [ImageFile]
    [Display(Name = "Upload an image:")]
    [Required(ErrorMessage = "Please select an image.")]
    public IFormFile? PetImage { get; set; }

    [Display(Name = "Image description:")]
    [Required(ErrorMessage = "Please enter the image description.")]
    public string? PetImageDescription { get; set; }
}
