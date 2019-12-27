using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.Core.Entities;
namespace FoodOrdering.Core.Contexts
{
    public class FoodStoreContext : DbContext, IFoodStoreContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public FoodStoreContext(string connectionString, string migrationAssemblyName)
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
            builder.Entity<FoodItem>()
                .HasMany(fi => fi.Images)
                .WithOne(fi => fi.FoodItem);

            builder.Entity<FoodItem>()
                .HasOne(fi => fi.PriceDiscount)
                .WithOne(fi => fi.FoodItem);

            builder.Entity<FoodItemCategory>()
                .HasKey(fi => new { fi.FoodItemId, fi.CategoryId });

            builder.Entity<FoodItemCategory>()
                .HasOne(fi => fi.FoodItem)
                .WithMany(fi=> fi.Categories)
                .HasForeignKey(fi => fi.FoodItemId);

            builder.Entity<FoodItemCategory>()
                .HasOne(fi => fi.Category)
                .WithMany(fi => fi.Categories)
                .HasForeignKey(fi=> fi.CategoryId);

            base.OnModelCreating(builder);
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodImage> FoodImages { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<FoodItemCategory> FoodItemCategory { get; set; }
        public DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        public DbSet<PercentageAmountDiscount> PercentageDiscounts { get; set; }
    }
}

