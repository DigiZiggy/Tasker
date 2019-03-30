﻿using System.Data.Common;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography.X509Certificates;
 using Contracts.DAL.Base;
 using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Action = System.Action;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>, IDataContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<HourlyRate> HourlyRates { get; set; }
        public DbSet<Identification> Identifications { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<MeansOfPayment> MeansOfPayments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TaskType> TaskTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<UserInGroup> UserInGroups { get; set; }
        public DbSet<UserOnAddress> UserOnAddresses { get; set; }
        public DbSet<UserOnTask> UserOnTasks { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<UserType> UserTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}