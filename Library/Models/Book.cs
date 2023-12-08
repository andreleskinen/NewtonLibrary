using System;
using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        public string? BookTitle { get; set; }
        public string? Author { get; set; }

        public string? ISBN { get; set; }
        public int PublicationYear { get; set; }

        public double Rating { get; set; }
        public bool Borrowed { get; set; }

        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual ICollection<Author> Authors { get; set; } = new List<Author>();

        //public int AuthorId { get; set; }
        
    }
}

