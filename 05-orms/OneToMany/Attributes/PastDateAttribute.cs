using System.ComponentModel.DataAnnotations;

namespace OneToMany.Attributes;

public class PastDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("Date is required.");
        }

        if (value is DateTime date)
        {
            if (date > DateTime.Now)
            {
                return new ValidationResult(this.ErrorMessage);
            }

            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Invalid date format.");
        }
    }
}
