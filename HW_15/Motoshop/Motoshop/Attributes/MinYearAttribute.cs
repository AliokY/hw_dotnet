using Motoshop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Motoshop.Attributes
{
    public class MinYearAttribute : ValidationAttribute
    {
        public int MinYear { get; }
        public MinYearAttribute(int minYear)
        {
            MinYear = minYear;
        }
        public string GetErrorMessage() => $"Motorcycle must be made no early than {MinYear}";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var yearOfIssue = ((DateTime)value).Year;

            if (MinYear <= yearOfIssue && yearOfIssue <= DateTime.Now.Year)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
