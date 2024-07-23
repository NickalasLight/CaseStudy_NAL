using CaseStudy_NAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;



namespace CaseStudy_NAL.Validation
{

    public class VendorValidationAttribute : ValidationAttribute
    {
        private const string PhoneNumberPattern = @"^\+?(\d[\s\-\.]?)?(\((\d{1,3})\)[\s\-\.]?)?(\d[\s\-\.]?){6,14}$"; //TODO: Regex used for convenience but in production code preference is for something more easily read and maintained by multiple developers, even if it takes more lines of code.


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var vendor = value as Vendor;
            if (vendor != null)
            {

                if (!string.IsNullOrEmpty(vendor.Mail) && !vendor.Mail.Contains('@'))
                {
                    return new ValidationResult("Invalid email address format.");
                }
                if (!string.IsNullOrEmpty(vendor.Phone) && !Regex.IsMatch(vendor.Phone, PhoneNumberPattern))
                {
                    return new ValidationResult("Invalid hone number.");
                }

            }
            return ValidationResult.Success;
        }
    }


}
