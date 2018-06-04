using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HireMe2.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var candidate = (Candidate)validationContext.ObjectInstance;
            if (candidate.MembershipTypeId == MembershipType.Unknown ||
                candidate.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (candidate.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - candidate.Birthdate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Candidate should be 18");

        }
    }
}