using System;
namespace Library.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();

        public Author()
        {

        }
    }
}

