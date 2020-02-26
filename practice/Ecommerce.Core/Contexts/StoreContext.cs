using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Core.Contexts
{
    public class StoreContext : DbContext, IStoreContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;
        public StoreContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }
            base.OnConfiguring(dbContextOptionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasMany(p => p.Images)
                .WithOne(i => i.Product);

            builder.Entity<ExtendedIdentityUser>()
               .HasMany(ei => ei.Orders)
               .WithOne(ei => ei.User)
               .HasForeignKey(ei => ei.UserId);
               

            builder.Entity<Product>()
                .HasOne(p => p.PriceDiscount)
                .WithOne(d => d.Product);

            builder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.Categories)
                .HasForeignKey(pc => pc.ProductId);

            builder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.Categories)
                .HasForeignKey(pc => pc.CategoryId);

            base.OnModelCreating(builder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        public DbSet<PercentageDiscount> PercentageDiscounts { get; set; }
        public DbSet<Order2> Order { get; set; }
        //public DbSet<ExtendedIdentityUser> Users { get; set; }
    }
}
