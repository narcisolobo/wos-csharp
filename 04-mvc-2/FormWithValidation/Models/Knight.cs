#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace FormWithValidation.Models;

public class Knight
{
    [Display(Name = "What is your name:")]
    [Required(ErrorMessage = "Yo, I asked you your name!")]
    [MinLength(3, ErrorMessage = "Name must be at least three characters.")]
    public string Name { get; set; }

    [Display(Name = "What is your favorite color:")]
    [Required(ErrorMessage = "Please enter your favorite color!")]
    public string FavoriteColor { get; set; }

    [Display(Name = "What is the average speed of an unladen swallow:")]
    [Required(ErrorMessage = "Please enter average speed!")]
    [Range(1, 201, ErrorMessage = "Speed must be between 1 and 200.")]
    public int? AverageSpeed { get; set; }
}
