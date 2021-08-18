using System;
using System.ComponentModel.DataAnnotations;

namespace Motoshop.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GuidCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is null)
            {
                return false;
            }

            bool parseResult = Guid.TryParse(value.ToString(), out Guid _);

            return parseResult;
        }
    }
}
