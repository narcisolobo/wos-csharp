#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using LoginReg.Attributes;

namespace LoginReg.Models;

public class User
{
    [Key]
    public int UserId { get; set; }

    [Display(Name = "First name:")]
    [Required(ErrorMessage = "Please enter first name.")]
    [MinLength(2, ErrorMessage = "First name must be at least two characters.")]
    public string FirstName { get; set; }

    [Display(Name = "Last name:")]
    [Required(ErrorMessage = "Please enter last name.")]
    [MinLength(2, ErrorMessage = "Last name must be at least two characters.")]
    public string LastName { get; set; }

    [UniqueEmail]
    [Display(Name = "Email:")]
    [Required(ErrorMessage = "Please enter email.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [Required(ErrorMessage = "Please enter password.")]
    [MinLength(8, ErrorMessage = "Password must be at least eight characters.")]
    public string Password { get; set; }

    [NotMapped]
    [DataType(DataType.Password)]
    [Display(Name = "Confirm password:")]
    [Required(ErrorMessage = "Please retype password.")]
    [Compare("Password", ErrorMessage = "Passwords do not match.")]
    [MinLength(8, ErrorMessage = "Confirm password must be at least eight characters.")]
    public string ConfirmPassword { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
