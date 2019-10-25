using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Core;
namespace WebApi.Store
{
    public class LibraryContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;
        public LibraryContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<StudentBook>()
            .HasKey(sb => new { sb.StudentId, sb.bookbarcode });
            builder.Entity<StudentBook>()
                .HasOne(sb => sb.Student)
                .WithMany(sb => sb.Books)
                .HasForeignKey(sb => sb.StudentId);
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
        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<StudentBook> StudentBooks { get; set; }
    }
}
