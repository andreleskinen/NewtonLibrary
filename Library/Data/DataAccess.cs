using System;
using Library.Models;

namespace Library.Data
{
    public class DataAccess
    {
        public void Seed()
        {
            Context context = new Context();

            var book1 = new Book { BookTitle = "Can´t Hurt Me", Author = "David Goggings", ISBN = "978-1-4321-0987-6", PublicationYear = 2018, Rating = 4.9, Borrowed = false };
            var book2 = new Book { BookTitle = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "978-0-06-112008-4", PublicationYear = 1960, Rating = 4.3, Borrowed = false };
            var book3 = new Book { BookTitle = "The Great Gatsby", Author = "F.Scott Fitzgerald", ISBN = "978-0-7432-7356-5", PublicationYear = 1925, Rating = 4.2, Borrowed = false };
            var book4 = new Book { BookTitle = "Harry Potter and the Sorcerer's Stone", Author = "J.K.Rowling", ISBN = "978-0-7679-2766-6", PublicationYear = 1997, Rating = 4.7, Borrowed = false };
            var book5 = new Book { BookTitle = "The Hobbit", Author = "J.R.R.Tolkien", ISBN = "978-0-261-10295-3", PublicationYear = 1937, Rating = 4.3, Borrowed = false };

            context.Books.AddRange(book1, book2, book3, book4, book5);
            context.SaveChanges();
        }

        public void BorrowBook(string bookT)
        {
            //Details about the borrower bellow
            //      :
            //      |
            //      V
            var borrower1 = new Borrower
            {
                FirstName = "André",
                LastName = "Leskinen",
                LibraryCardNumber = 143050,
                BorrowedBooks = new List<Book> { book1 }
            };

            //Function to borrow a book bellow
            //      :
            //      |
            //      V
            var bookToBorrow = context.Books.FirstOrDefault(b => b.BookTitle == "Can´t Hurt Me");

            if (bookToBorrow != null && !bookToBorrow.Borrowed)
            {
                bookToBorrow.Borrowed = true;
                bookToBorrow.BorrowDate = DateTime.Now;
                borrower1.BorrowedBooks.Add(bookToBorrow);
            }

            context.Borrowers.Add(borrower1);
        }





            
        
        

    }
}

