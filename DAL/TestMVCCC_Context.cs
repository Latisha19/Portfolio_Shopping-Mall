using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MVCCC.Models;
using System.Web.Services.Description;

namespace MVCCC.DAL
{
    public class TestMVCCC_Context : DbContext
    {

        public TestMVCCC_Context() : base("MSSQL_DBconnect")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        //public DbSet<Account> Courses { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Category>()
                .HasKey(e => e.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .HasMaxLength(60);

            modelBuilder.Entity<Category>()
                .Property(e => e.Description)
                .HasColumnType("ntext");



            modelBuilder.Entity<Order>()
                .HasKey(e => e.OrderId);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Category) // 表示 Order 必須有一個 Category
                .WithMany(c => c.Orders)      // 表示 Category 可以有多個 Orders
                .HasForeignKey(o => o.CategoryId); // 設置外鍵

            modelBuilder.Entity<Order>()
                .Property(e => e.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(e => e.Price);

            modelBuilder.Entity<Order>()
                .Property(e => e.Customer)
                .HasMaxLength(50);

            modelBuilder.Entity<Order>()
                .Property(e => e.Quantity);

            modelBuilder.Entity<Order>()
                .Property(e => e.OrderDT)
                .HasColumnType("datetime");

            // User
            modelBuilder.Entity<User>()
                .HasKey(e => e.UserId);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .HasMaxLength(256);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailConfirmed);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash);

            modelBuilder.Entity<User>()
                .Property(e => e.SecurityStamp);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber);

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumberConfirmed);

            modelBuilder.Entity<User>()
                .Property(e => e.TwoFactorEnabled);

            modelBuilder.Entity<User>()
                .Property(e => e.LockoutEndDateUtc)
                .HasColumnType("datetime");

            modelBuilder.Entity<User>()
                .Property(e => e.LockoutEnabled);

            modelBuilder.Entity<User>()
                .Property(e => e.AccessFailedCount);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .HasMaxLength(256);

            modelBuilder.Entity<User>()
                .Property(e => e.Discriminator)
                .HasMaxLength(128);


            base.OnModelCreating(modelBuilder);
        }
    }
}