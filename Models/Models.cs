using CaseStudy_NAL.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CaseStudy_NAL.Models
{
    // Models/Vendor.cs
    [VendorValidation]
    public class Vendor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure ID is auto-generated
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Name2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? ZIP { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Notes { get; set; }
        public List<BankAccount>? BankAccount { get; set; }
        public List<ContactPerson>? ContactPersons { get; set; }
    }

    // Models/BankAccount.cs
    [BankAccountValidation]
    public class BankAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Ensure ID is auto-generated
        public int Id { get; set; }
        public string IBAN { get; set; }
        public string BIC { get; set; }
        public string? Name { get; set; }
        public int VendorId { get; set; }

        [JsonIgnore]
        public Vendor? Vendor { get; set; }
    }

    // Models/ContactPerson.cs
    [ContactPersonValidation]
    public class ContactPerson
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Phone { get; set; }
        public string? Mail { get; set; }
        public int VendorId { get; set; }

        [JsonIgnore]
        public Vendor? Vendor { get; set; }
    }
}
