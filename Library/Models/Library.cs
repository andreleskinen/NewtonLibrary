using System;
namespace Library.Models
{
    public class Library
    {
        public Guid Id { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

        public ICollection<Borrower> Borrowers { get; set; } = new List<Borrower>();

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}

