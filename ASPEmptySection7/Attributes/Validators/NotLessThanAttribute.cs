using System.ComponentModel.DataAnnotations;

namespace ASPEmptySection7.Attributes.Validators
{
    public class NotLessThanAttribute : ValidationAttribute
    {
        private double _minimum;
        public NotLessThanAttribute(double minimum) 
        { 
            _minimum = minimum;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null)
            {
                return null;
            }
            double num = double.Parse(value.ToString()!);
            if (_minimum > num)
            {
                return new ValidationResult(string.Format(ErrorMessage ?? "{0} less than minimum value", validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
