using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
namespace StockMarketApi.Store3
{
   
        public class StockMarketContext3 : DbContext
        {
            private string _connectionString;
            private string _migrationAssemblyName;
            public StockMarketContext3(string connectionString, string migrationAssemblyName)
            {
                _connectionString = connectionString;
                _migrationAssemblyName = migrationAssemblyName;
            }
            protected override void OnModelCreating(ModelBuilder builder)
            {

                builder.Entity<StockRecord3>()
                    .HasOne(c => c.Company3)
                    .WithMany(sp => sp.StockRecords)
                    .HasForeignKey(sp => sp.CompanyId);
                base.OnModelCreating(builder);
            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
            {
                if (!optionBuilder.IsConfigured)
                {
                    optionBuilder.UseSqlServer(_connectionString, m => m.MigrationsAssembly(_migrationAssemblyName));
                }
                base.OnConfiguring(optionBuilder);
            }

            public DbSet<Company3> Companies3 { get; set; }
            public DbSet<StockRecord3> StockRecords3 { get; set; }
        }
}
