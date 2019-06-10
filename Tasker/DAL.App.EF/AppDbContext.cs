using System;
using System.Linq;
using Domain;
using Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<HourlyRate> HourlyRates { get; set; }
        public DbSet<Identification> Identifications { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TaskerTask> Tasks { get; set; }
        public DbSet<UserOnAddress> UserOnAddresses { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
                
        public DbSet<MultiLangString> MultiLangStrings { get; set; }
        public DbSet<Translation> Translations { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // disable cascade delete
            foreach (var relationship in builder.Model
                .GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}