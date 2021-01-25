using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project_MVC5.Models
{
    public class Min18YearsIfAMember: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
             var customer = (Customer)validationContext.ObjectInstance;
            if ( customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date Is Required !");
            int age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 years old to go member");
        }
    }
}