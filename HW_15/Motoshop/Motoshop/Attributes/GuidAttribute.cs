using System;
using System.ComponentModel.DataAnnotations;

namespace Motoshop.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GuidCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool parseResult = Guid.TryParse(value.ToString(), out Guid id);

            if (parseResult)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
