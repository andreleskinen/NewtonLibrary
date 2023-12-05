using System;
using System.ComponentModel.DataAnnotations;
namespace Library.Models
{
    public class Borrower
    {
        [Key]
        public int BorrowerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int LibraryCardNumber { get; set; }
        public List<Book> BorrowedBooks { get; set; }
    }
}

