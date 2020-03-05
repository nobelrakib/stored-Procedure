using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using FoodOrdering.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FoodOrdering.Core.Contexts
{
    public class FoodStoreContext : IdentityDbContext, IFoodStoreContext
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

            builder.Entity<Category>()
               .HasMany(c => c.FoodItems)
               .WithOne(c=>c.Categories);


            builder.Entity<ExtendedIdentityUser>()
               .HasMany(ei => ei.PendingOrder)
               .WithOne(ei => ei.User);

            builder.Entity<FoodItem>()
                .HasOne(fi => fi.PriceDiscount)
                .WithOne(fi => fi.FoodItem);

            builder.Entity<FoodItem>()
               .HasMany(fi => fi.Orders)
               .WithOne(fi => fi.FoodItem);

            builder.Entity<Order>()
               .HasOne(o => o.OffLinePayment)
               .WithOne(o => o.Order);

            builder.Entity<Order>()
               .HasOne(o => o.OnlinePayment)
               .WithOne(o => o.Order);

           

            base.OnModelCreating(builder);
        }

        public DbSet<FoodItem> FoodItems { get; set; }
        public DbSet<FoodImage> FoodImages { get; set; }
        public DbSet<DeliveryBoy> DeliveryBoys { get; set; }
        public DbSet<Category> Category { get; set; }
      
        public DbSet<FixedAmountDiscount> FixedAmountDiscounts { get; set; }
        public DbSet<PercentageAmountDiscount> PercentageDiscounts { get; set; }
        public DbSet<ConfirmedOrder> ConfirmedOrders { get; set; }
        public DbSet<PendingOrder> PendingOrders { get; set; }
    }
}

