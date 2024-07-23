using CaseStudy_NAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;



namespace CaseStudy_NAL.Validation
{

    public class BankAccountValidationAttribute : ValidationAttribute
    {
        private const string IbanPattern = @"^[A-Z]{2}\d{2}([ ]?\d{4}){4}([ ]?\d{1,2})?$"; //TODO: Regex used for convenience but in production code preference is for something more easily read and maintained by multiple developers, even if it takes more lines of code.
        private const string BicPattern = @"^[A-Z]{4}[A-Z]{2}[A-Z0-9]{2}([A-Z0-9]{3})?$"; 

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var bankAccount = value as BankAccount;
            if (bankAccount != null)
            {

                if (!string.IsNullOrEmpty(bankAccount.IBAN) && !Regex.IsMatch(bankAccount.IBAN, IbanPattern))
                {
                    return new ValidationResult("Invalid IBAN format.");
                }
                if (!string.IsNullOrEmpty(bankAccount.BIC) && !Regex.IsMatch(bankAccount.BIC, BicPattern))
                {
                    return new ValidationResult("Invalid BIC format.");
                }
                //TODO: linq query that also checks that the vendor exists
                if (bankAccount.VendorId <= 0)
                {
                    return new ValidationResult("Invalid Vendor Id.");
                }
            }
            return ValidationResult.Success;
        }
    }


}
