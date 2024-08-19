using System.ComponentModel.DataAnnotations;
using DadJokes.Attributes;

namespace DadJokes.ViewModels;

public class LoginModel
{
    [Display(Name = "Email address")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [Required(ErrorMessage = "Email address is required.")]
    public string? LoginEmail { get; set; }

    [StrongPassword]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your password is required.")]
    public string? LoginPassword { get; set; }
}
