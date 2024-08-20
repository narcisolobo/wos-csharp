using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DadJokes.Attributes;

public partial class StrongPasswordAttribute : ValidationAttribute
{

    [GeneratedRegex(@"[A-Z]")]
    private static partial Regex OneUpperCase();

    [GeneratedRegex(@"[a-z]")]
    private static partial Regex OneLowerCase();

    [GeneratedRegex(@"\d")]
    private static partial Regex OneNumber();

    [GeneratedRegex(@"[!@#$%^&*]")]
    private static partial Regex OneSpecial();

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is not string password)
        {
            return new ValidationResult("Password is required.");
        }

        if (password.Length < 8)
        {
            return new ValidationResult("Password must be at least 8 characters long.");
        }

        if (!OneUpperCase().IsMatch(password))
        {
            return new ValidationResult("Password must contain at least one uppercase letter.");
        }

        if (!OneLowerCase().IsMatch(password))
        {
            return new ValidationResult("Password must contain at least one lowercase letter.");
        }

        if (!OneNumber().IsMatch(password))
        {
            return new ValidationResult("Password must contain at least one number.");
        }

        if (!OneSpecial().IsMatch(password))
        {
            return new ValidationResult("Password must contain at least one special character (!, @, #, $, %, ^, &, *).");
        }

        return ValidationResult.Success;
    }
}
