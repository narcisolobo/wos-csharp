using System.ComponentModel.DataAnnotations;
using LoginReg.Context;

namespace LoginReg.Attributes;

public class UniqueEmailAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || string.IsNullOrEmpty(value.ToString()))
        {
            // Returning the required error if value is null or empty
            return new ValidationResult("Please enter email address.");
        }

        // Getting the context service
        if (validationContext.GetService(typeof(ApplicationContext)) is not ApplicationContext _context)
        {
            throw new ArgumentNullException(nameof(_context).ToString(), "ApplicationContext is not registered in the services container.");
        }

        // Check for the uniqueness of the email
        var email = value.ToString();
        bool emailExists = _context.Users.Any(user => user.Email == email);

        if (emailExists)
        {
            // If the email exists, return the validation error
            return new ValidationResult("Email is taken. Please log in.");
        }

        // If the email does not exist, validation is successful
        return ValidationResult.Success!;
    }
}
