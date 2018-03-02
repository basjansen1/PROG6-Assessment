using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hotel_Tamagotchi.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class AgeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int age = (int)value;

                if (age >= 0)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("An amount less than 0 is not allowed");
        }
    }
}