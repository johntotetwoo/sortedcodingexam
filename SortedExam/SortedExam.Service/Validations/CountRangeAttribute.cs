using System.ComponentModel.DataAnnotations;

namespace SortedExam.Service.Validations
{
    public class CountRangeAttribute : ValidationAttribute
    {
        private readonly int _min;
        private readonly int _max;

        public CountRangeAttribute(int min, int max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult($"The field {validationContext.DisplayName} must be not be null.");

            int intValue;
            if (int.TryParse(value.ToString(), out intValue))
            {
                if (intValue < _min || intValue > _max)
                {
                    return new ValidationResult($"The field {validationContext.DisplayName} must be between {_min} and {_max}.");
                }
            }
            else
            {
                return new ValidationResult($"The field {validationContext.DisplayName} must be an integer.");
            }

            return ValidationResult.Success;
        }
    }
}
