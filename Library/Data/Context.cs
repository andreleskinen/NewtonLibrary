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

