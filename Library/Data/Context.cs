using System;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Data
{
    public class Context : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Borrower> Borrowers { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
            .HasMany(a => a.Books)
            .WithMany(b => b.Authors)
            .UsingEntity(j => j.ToTable("AuthorBook"));

            modelBuilder.Entity<Borrower>()
            .HasMany(b => b.BorrowedBooks)
            .WithOne(book => book.Borrower)  
            .HasForeignKey(book => book.BorrowerId);

            base.OnModelCreating(modelBuilder);

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost; " +
                "Database=NewtonLibrary--André--Leskinen; " +
                "Trust Server Certificate =Yes; " +
                "User Id=NewtonLibrary; " +
                "password=NewtonLibrary");
        }
    }
}

