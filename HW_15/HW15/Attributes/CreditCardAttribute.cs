using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace HW15.Task1
{
    [AttributeUsage(AttributeTargets.Property)]
    class CreditCardAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool typeChecking = value is string;

            if (value is null || !typeChecking)
            {
                return false;
            }

            // the first item of card number must be 4(Visa), 5(Mastercard) or 6(БЕЛКАРТ)
            string cardNumberPattern = @"[4-6]\d{3}([\s]\d{4}){3}";
            Regex regex = new(cardNumberPattern);

            Match match = regex.Match(value.ToString());

            return match.Success;
        }
    }
}
