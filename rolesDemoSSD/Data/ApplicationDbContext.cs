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
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<MyUser> MyUser { get; set; }
        //public DbSet<ProductUser> ProductUsers { get; set; }
        public DbSet<IPN> IPNs { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // When adding OnModelCreating() in .NET Core a reference 
            // to the base class is also needed at the start of the method.
            base.OnModelCreating(modelBuilder);

            // Defining Foreign Keys
            modelBuilder.Entity<Products>()
                .HasOne(p => p.MyUser)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Invoice)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => new { fk.InvoiceID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
            
            modelBuilder.Entity<ProductCart>()
                .HasKey(ps => new { ps.ProductID, ps.CartID });

            // Define foreign keys here. Do not use foreign key annotations.
            modelBuilder.Entity<ProductCart>()
                .HasOne(p => p.Product)
                .WithMany(p => p.ProductCart)
                .HasForeignKey(fk => new { fk.ProductID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<ProductCart>()
                .HasOne(p => p.Cart)
                .WithMany(p => p.ProductCart)
                .HasForeignKey(fk => new { fk.CartID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            //modelBuilder.Entity<ProductUser>()
            //    .HasOne(p => p.Products)
            //    .WithMany(p => p.ProductUsers)
            //    .HasForeignKey(fk => new { fk.ProductID })
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            //modelBuilder.Entity<ProductUser>()
            //    .HasOne(p => p.MyUser)
            //    .WithMany(p => p.ProductUsers)
            //    .HasForeignKey(fk => new { fk.UserID })
            //    .onDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<ProduceSupplier>()
            //    .HasOne(p => p.Produce)
            //    .WithMany(p => p.ProduceSuppliers)
            //    .HasForeignKey(fk => new { fk.ProduceID })
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            //modelBuilder.Entity<ProduceSupplier>()
            //    .HasOne(p => p.Supplier)
            //    .WithMany(p => p.ProduceSuppliers)
            //    .HasForeignKey(fk => new { fk.SupplierID })
            //    .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Invoice>()
                .HasOne(p => p.MyUser)
                .WithMany(p => p.Invoices)
                .HasForeignKey(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Cart>()
                .HasOne(p => p.MyUser)
                .WithOne(p => p.Cart)
                .HasForeignKey<Cart>(fk => new { fk.UserID })
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete


            modelBuilder.Entity<Products>().HasData(
                new Products
                {
                    ProductID = 1,
                    ProductName = "Black Diamond Hot Wire",
                    Category = "Climbing",
                    Price = 5.66M,
                    Photo = "black-diamond-hotforge-hybrid-quickdraw.jpg",
                    Description = "Black Diamond Hot Wire QucikPack 12cm",
                    LocationTag = "/",
                    UserID = 1,
                    InvoiceID = 1,
                    CartID = 0
                },
                new Products
                {
                    ProductID = 2,
                    ProductName = "Baseball Glove",
                    Category = "Baseball",
                    Price = 10.66M,
                    Photo = "baseball-glove.jpeg",
                    Description = "An Average Baseball Glove",
                    LocationTag = "/",
                    UserID = 1,
                    InvoiceID = 1,
                    CartID = 0
                },
                new Products
                {
                    ProductID = 3,
                    ProductName = "Snowboard",
                    Category = "Winter",
                    Price = 78.30M,
                    Photo = "snowboard.jpg",
                    Description = "Sick moves bro",
                    LocationTag = "/",
                    UserID = 1,
                    InvoiceID = 1,
                    CartID = 0
                },
                new Products
                {
                    ProductID = 4,
                    ProductName = "Coleman Tent",
                    Category = "Camping",
                    Price = 63.29M,
                    Photo = "coleman-tent.jpg",
                    Description = "Great tent for sleeping outdoors",
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
                },
                new MyUser
                {
                    UserID = 2,
                    UserName = "Ross024",
                    FirstName = "Ross",
                    LastName = "Scharbach",
                    PhoneNumber = "2501238394",
                    Email = "ross.scharbach@gmail.com",
                    City = "Vancouver",
                    StreetAddress = "42 Sitka Ave",
                    Country = "Canada",
                    PostalCode = "V5V43N",
                    Password = "P@ssw0rd!",
                    isAdmin = true
                });
        }

        public DbSet<rolesDemoSSD.Models.ProductVM> ProductVM { get; set; }
    }
}
