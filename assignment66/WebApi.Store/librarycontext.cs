using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core;
namespace WebApi.Store
{
    public class librarycontext :DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public librarycontext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<studentbook>()
            .HasKey(sb => new { sb.studentId, sb.bookId });
            builder.Entity<studentbook>()
                .HasOne(sb => sb.student)
                .WithMany(sb => sb.books)
                .HasForeignKey(sb => sb.studentId);
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

        public DbSet<student> Students { get; set; }
        public DbSet<book> Books { get; set; }
        public DbSet<studentbook> studentbooks { get; set; }
        

    }
}
