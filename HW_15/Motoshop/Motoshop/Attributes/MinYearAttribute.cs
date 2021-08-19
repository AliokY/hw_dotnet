using System;
using System.ComponentModel.DataAnnotations;

namespace Motoshop.Attributes
{
    public class MinYearAttribute : ValidationAttribute
    {
        public int MinYear { get; }
        public MinYearAttribute(int minYear)
        {
            MinYear = minYear;
            ErrorMessage = $"Motorcycle must be made no early than {MinYear}";
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var yearOfIssue = ((DateTime)value).Year;

            if (MinYear <= yearOfIssue && yearOfIssue <= DateTime.Now.Year)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
