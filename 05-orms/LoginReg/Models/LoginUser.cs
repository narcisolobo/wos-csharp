#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace LoginReg.Models;

public class LoginUser
{
    [Display(Name = "Email:")]
    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Please enter password.")]
    [MinLength(8, ErrorMessage = "Password must be at least eight characters.")]
    public string Password { get; set; }
}
