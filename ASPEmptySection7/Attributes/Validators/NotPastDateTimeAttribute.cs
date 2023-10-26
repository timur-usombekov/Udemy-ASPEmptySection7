using System.ComponentModel.DataAnnotations;

namespace ASPEmptySection7.Attributes.Validators
{
    public class NotPastDateTimeAttribute: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
                return null;
            DateTime dt;
            if(DateTime.TryParse(value.ToString(), out dt))
            {
                if(dt >= DateTime.Now)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? "{0} earlier than now", validationContext.MemberName));
                }
            }
            else
            {
                return null;
            }
        }
    }
}
