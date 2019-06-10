﻿// <auto-generated />
using System;
using DAL.App.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DAL.App.EF.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20190609125036_InitialDbCreation")]
    partial class InitialDbCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("HouseNumber")
                        .HasMaxLength(64);

                    b.Property<string>("PostalCode")
                        .HasMaxLength(64);

                    b.Property<string>("Street")
                        .HasMaxLength(64);

                    b.Property<string>("UnitNumber")
                        .HasMaxLength(64);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Domain.HourlyRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("End");

                    b.Property<decimal>("HourRate");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.ToTable("HourlyRates");
                });

            modelBuilder.Entity("Domain.Identification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<string>("Comment");

                    b.Property<string>("DocNumber")
                        .HasMaxLength(64);

                    b.Property<DateTime?>("End");

                    b.Property<int>("IdentificationType");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Identifications");
                });

            modelBuilder.Entity("Domain.Identity.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Domain.Identity.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasMaxLength(64);

                    b.Property<int?>("HourlyRateId");

                    b.Property<string>("LastName")
                        .HasMaxLength(64);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SelfDescription");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("HourlyRateId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Domain.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Date");

                    b.Property<int>("InvoiceNumber");

                    b.Property<decimal>("TotalWithVAT");

                    b.Property<decimal>("TotalWithoutVAT");

                    b.Property<decimal>("VAT");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Domain.MultiLangString", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Value")
                        .HasMaxLength(10240);

                    b.HasKey("Id");

                    b.ToTable("MultiLangStrings");
                });

            modelBuilder.Entity("Domain.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<int>("InvoiceId");

                    b.Property<string>("MeansOfPayment");

                    b.Property<int>("PaymentCode");

                    b.Property<DateTime>("TimeOfPayment");

                    b.Property<decimal>("Total");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Rating");

                    b.Property<string>("ReviewComment");

                    b.Property<int>("ReviewGiverId");

                    b.Property<int>("ReviewReceiverId");

                    b.HasKey("Id");

                    b.HasIndex("ReviewGiverId");

                    b.HasIndex("ReviewReceiverId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("Domain.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<string>("Description");

                    b.Property<string>("SkillName");

                    b.HasKey("Id");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("Domain.TaskerTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<string>("Description");

                    b.Property<string>("TaskName");

                    b.Property<int>("TaskStatus");

                    b.Property<int>("TaskType");

                    b.Property<decimal>("TimeEstimate");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Domain.Translation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Culture")
                        .HasMaxLength(5);

                    b.Property<int>("MultiLangStringId");

                    b.Property<string>("Value")
                        .HasMaxLength(10240);

                    b.HasKey("Id");

                    b.HasIndex("MultiLangStringId");

                    b.ToTable("Translations");
                });

            modelBuilder.Entity("Domain.UserOnAddress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AddressId");

                    b.Property<int>("AppUserId");

                    b.Property<DateTime?>("End");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("AppUserId");

                    b.ToTable("UserOnAddresses");
                });

            modelBuilder.Entity("Domain.UserSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AppUserId");

                    b.Property<DateTime?>("End");

                    b.Property<int>("SkillId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("SkillId");

                    b.ToTable("UserSkills");
                });

            modelBuilder.Entity("Domain.UserTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("End");

                    b.Property<DateTime>("Start");

                    b.Property<int>("TaskGiverId");

                    b.Property<int>("TaskId");

                    b.Property<int>("TaskerId");

                    b.Property<int?>("TaskerTaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskGiverId");

                    b.HasIndex("TaskerId");

                    b.HasIndex("TaskerTaskId");

                    b.ToTable("UserTasks");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Domain.Identification", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("Identifications")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Identity.AppUser", b =>
                {
                    b.HasOne("Domain.HourlyRate", "HourlyRate")
                        .WithMany("AppUsers")
                        .HasForeignKey("HourlyRateId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Invoice", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("Invoices")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Payment", b =>
                {
                    b.HasOne("Domain.Invoice", "Invoice")
                        .WithMany("Payments")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Review", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "ReviewGiver")
                        .WithMany("GivenReviews")
                        .HasForeignKey("ReviewGiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Identity.AppUser", "ReviewReceiver")
                        .WithMany("ReceivedReviews")
                        .HasForeignKey("ReviewReceiverId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.TaskerTask", b =>
                {
                    b.HasOne("Domain.Address", "Address")
                        .WithMany("TasksOnAddress")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.Translation", b =>
                {
                    b.HasOne("Domain.MultiLangString", "MultiLangString")
                        .WithMany("Translations")
                        .HasForeignKey("MultiLangStringId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.UserOnAddress", b =>
                {
                    b.HasOne("Domain.Address", "Address")
                        .WithMany("AppUsersOnAddress")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("Addresses")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.UserSkill", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "AppUser")
                        .WithMany("Skills")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Skill", "Skill")
                        .WithMany("AppUsers")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Domain.UserTask", b =>
                {
                    b.HasOne("Domain.Identity.AppUser", "TaskGiver")
                        .WithMany("TasksCreated")
                        .HasForeignKey("TaskGiverId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Identity.AppUser", "Tasker")
                        .WithMany("TasksWorkedOn")
                        .HasForeignKey("TaskerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.TaskerTask", "TaskerTask")
                        .WithMany("AppUsersInvolved")
                        .HasForeignKey("TaskerTaskId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domain.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}