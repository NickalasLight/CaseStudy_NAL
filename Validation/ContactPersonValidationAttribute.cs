using CaseStudy_NAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;



namespace CaseStudy_NAL.Validation
{

    public class ContactPersonValidationAttribute : ValidationAttribute
    {
        private const string PhoneNumberPattern = @"^\+?(\d[\s\-\.]?)?(\((\d{1,3})\)[\s\-\.]?)?(\d[\s\-\.]?){6,14}$"; //TODO: Regex used for convenience but in production code preference is for something more easily read and maintained by multiple developers, even if it takes more lines of code.


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var person = value as ContactPerson;
            if (person != null)
            {

                if (!string.IsNullOrEmpty(person.Mail) && !person.Mail.Contains('@'))
                {
                    return new ValidationResult("Invalid email address format.");
                }
                if (!string.IsNullOrEmpty(person.Phone) && !Regex.IsMatch(person.Phone, PhoneNumberPattern))
                {
                    return new ValidationResult("Invalid phone number.");
                }

            }
            return ValidationResult.Success;
        }
    }


}
