using System.ComponentModel.DataAnnotations;

namespace SecretPassword.Attributes;

public class ValidPasswordAttribute : ValidationAttribute
{
    protected string PasswordContent { get; set; }

    public ValidPasswordAttribute(string passwordContent)
    {
        PasswordContent = passwordContent;
    }

    // override the IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        // is the value null? does the value match?
        if (value == null || value.ToString() != PasswordContent)
        {
            return new ValidationResult("You got the wrong password.");
        }

        return ValidationResult.Success;
    }
}
