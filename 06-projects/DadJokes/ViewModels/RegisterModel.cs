using System.ComponentModel.DataAnnotations;
using BeltExam.Attributes;
using DadJokes.Attributes;

namespace DadJokes.ViewModels;

public class RegisterModel
{
    [UniqueEmail]
    [Display(Name = "Email address")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    [Required(ErrorMessage = "Email address is required.")]
    public string? RegisterEmail { get; set; }

    [StrongPassword]
    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Your password is required.")]
    public string? RegisterPassword { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Confirm password:")]
    [Required(ErrorMessage = "Please retype your password.")]
    [Compare("RegisterPassword", ErrorMessage = "Passwords do not match.")]
    public string? ConfirmPassword { get; set; }
}
