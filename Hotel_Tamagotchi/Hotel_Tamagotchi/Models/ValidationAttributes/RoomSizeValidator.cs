using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RoomSizeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int size = (int)value;

                if (size == 2 || size == 3 || size == 5)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Only a size of 2, 3 or 5 is allowed");
        }
    }
}