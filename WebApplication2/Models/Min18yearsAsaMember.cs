using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebApplication2.Models
{
    public class Min18yearsAsaMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.Birthday == null)
                return new ValidationResult("Birthday is Required");
            if (customer.MembershipTypeId == MembershipType.Unknown || 
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be older than 18 years");
        }

    }
}