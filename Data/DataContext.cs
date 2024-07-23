using CaseStudy_NAL.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CaseStudy_NAL.Data
{
    // Data/VendorContext.cs
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<ContactPerson> ContactPersons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vendor>()
                .HasMany(v => v.BankAccount)
                .WithOne(b => b.Vendor)
                .HasForeignKey(b => b.VendorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Vendor>()
                .HasMany(v => v.ContactPersons)
                .WithOne(c => c.Vendor)
                .HasForeignKey(c => c.VendorId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }

}
