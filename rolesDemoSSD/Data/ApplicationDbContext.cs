using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using rolesDemoSSD.ViewModels;
using System.ComponentModel.DataAnnotations.Schema;
using rolesDemoSSD.Models;

namespace rolesDemoSSD.Data
{

    public class MyRegisteredUser
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string Email { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MyRegisteredUser> MyRegisteredUsers { get; set; }

        public DbSet<rolesDemoSSD.ViewModels.RoleVM> RoleVM { get; set; }

        public DbSet<rolesDemoSSD.ViewModels.UserVM> UserVM { get; set; }

        public DbSet<rolesDemoSSD.ViewModels.UserRoleVM> UserRoleVM { get; set; }

        // -------------------------------------------------------------------
        // Define entity collections.
        public DbSet<Produce> Produces { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProduceSupplier> ProduceSuppliers { get; set; }
        // --------------------------------------------------------------------
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<MyUser> MyUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // When adding OnModelCreating() in .NET Core a reference 
            // to the base class is also needed at the start of the method.
            base.OnModelCreating(modelBuilder);

            // Defining Foreign Keys
            modelBuilder.Entity<Product>()
                .HasOne(p => p.User)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Invoice)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => new { fk.InvoiceID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Invoice>()
                .HasOne(p => p.User)
                .WithMany(p => p.Invoices)
                .HasForeignKey(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductID = 1,
                    ProductName = "Black Diamond Hot Wire",
                    Category = "Climbing",
                    Price = 5.66M,
                    Photo = "/",
                    Description = "Black Diamond Hot Wire QucikPack 12cm",
                    LocationTag = "/",
                    UserID = 1,
                    InvoiceID = 1
                });
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice
                {
                    InvoiceID = 1,
                    InvoiceDate = new DateTime(2022, 2, 8),
                    InvoiceTotal = 7.99M,
                    PaymentMethod = "Visa",
                    UserID = 1
                });
            modelBuilder.Entity<MyUser>().HasData(
                new MyUser
                {
                    UserID = 1,
                    UserName = "Gaurav453",
                    FirstName = "Gaurav",
                    LastName = "Joshi",
                    PhoneNumber = "7788888888",
                    Email = "joshig@bcit.ca",
                    City = "Vancouver",
                    StreetAddress = "45 Mayfair Ave",
                    Country = "Canada",
                    PostalCode = "V5V43N",
                    Password = "P@ssw0rd!",
                    isAdmin = true
                });

            // -------------------------------------------------------------------
            // Define composite primary keys.
            modelBuilder.Entity<ProduceSupplier>()
                .HasKey(ps => new { ps.ProduceID, ps.SupplierID });

            // Define foreign keys here. Do not use foreign key annotations.
            modelBuilder.Entity<ProduceSupplier>()
                .HasOne(p => p.Produce)
                .WithMany(p => p.ProduceSuppliers)
                .HasForeignKey(fk => new { fk.ProduceID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ProduceSupplier>()
                .HasOne(p => p.Supplier)
                .WithMany(p => p.ProduceSuppliers)
                .HasForeignKey(fk => new { fk.SupplierID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
            
            
            modelBuilder.Entity<Produce>().HasData(
                new Produce { ProduceID = 1, Description = "Oranges" });

            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierID = 1, SupplierName = "Kin's Market" },
                new Supplier { SupplierID = 2, SupplierName = "Fresh Street Market" });

            modelBuilder.Entity<ProduceSupplier>().HasData(
                new ProduceSupplier { SupplierID = 1, ProduceID = 1, Qty = 25 });

            // -----------------------------------------------------------------------------------
        }
    }
}
