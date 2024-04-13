using System.ComponentModel.DataAnnotations;

namespace ADSProject.Validations
{
    public class CustomRequires:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if(value == null || value.ToString() == "0")
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
