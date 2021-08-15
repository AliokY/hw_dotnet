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

        public override bool IsValid(object value)
        {
            var yearOfIssue = ((DateTime)value).Year;

            if (MinYear <= yearOfIssue && yearOfIssue <= DateTime.Now.Year)
            {
                return true;
            }
            else
            {
                Func<string>(GetErrorMessage());

                return false;
            }
        }
    }
}
