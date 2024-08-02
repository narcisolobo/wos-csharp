#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace Recap.Models;

public class Username
{
    [Display(Name = "Username:")]
    [Required(ErrorMessage = "Please enter username.")]
    [MinLength(2, ErrorMessage = "Username must be at least two characters.")]
    public string Content { get; set; }
}
