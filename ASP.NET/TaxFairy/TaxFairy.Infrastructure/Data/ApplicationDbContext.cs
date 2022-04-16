﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaxFairy.Infrastructure.Data.Identity;
using TaxFairy.Infrastructure.Data.Models;

namespace TaxFairy.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BankDetails> BankDetails { get; set; }
        public DbSet<Contragent> Contragents { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }



    }
}