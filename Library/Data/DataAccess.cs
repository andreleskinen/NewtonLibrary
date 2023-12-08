using System;
using Library.Models;

namespace Library.Data
{
    public class DataAccess
    {
        private Context context;

        public DataAccess()
        {
            context = new Context();
        }

        #region Seed data
        public void Seed()
        {
            Context context = new Context();

            var book1 = new Book { BookTitle = "Can´t Hurt Me", Author = "David Goggings", ISBN = "978-1-4321-0987-6", PublicationYear = 2018, Rating = 4.9, Borrowed = false };
            var book2 = new Book { BookTitle = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "978-0-06-112008-4", PublicationYear = 1960, Rating = 4.3, Borrowed = false};
            var book3 = new Book { BookTitle = "The Great Gatsby", Author = "F.Scott Fitzgerald", ISBN = "978-0-7432-7356-5", PublicationYear = 1925, Rating = 4.2, Borrowed = false };
            var book4 = new Book { BookTitle = "Harry Potter and the Sorcerer's Stone", Author = "J.K.Rowling", ISBN = "978-0-7679-2766-6", PublicationYear = 1997, Rating = 4.75, Borrowed = false };
            var book5 = new Book { BookTitle = "The Hobbit", Author = "J.R.R.Tolkien", ISBN = "978-0-261-10295-3", PublicationYear = 1937, Rating = 4.3, Borrowed = false };
            var book6 = new Book { BookTitle = "Harry Potter and the Prisoner of Azkaban", Author = "J.K.Rowling", ISBN = "13: 978-1-234567-89-0", PublicationYear = 1999, Rating = 2.5, Borrowed = false };
            context.Books.AddRange(book1,book2, book3, book4, book5);
            
            context.SaveChanges();
        }
        #endregion

        #region Borrow a book
        public void BorrowBook(string bookTitle, string borrowerFirstName, string borrowerLastName, int libraryCardNumber)
        {
            var bookToBorrow = context.Books.FirstOrDefault(b => b.BookTitle == bookTitle); //Hittar den första boken med samma titel som angavs när man ville låna en bok

            if (bookToBorrow != null && !bookToBorrow.Borrowed) //Kollar så att boken finns i tabbel och att den inte är uthyrd
            {
                var borrower = context.Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber); //kollar om det redan finns ett LibraryCardNumber och om inte

                if (borrower == null)
                {
                    borrower = new Borrower //skapas en ny lånare här
                    {
                        FirstName = borrowerFirstName, 
                        LastName = borrowerLastName,
                        LibraryCardNumber = libraryCardNumber
                    };

                    context.Borrowers.Add(borrower);
                    context.SaveChanges();
                }

                bookToBorrow.Borrowed = true;
                bookToBorrow.BorrowDate = DateTime.Now;

                borrower.BorrowedBooks.Add(bookToBorrow);

                context.SaveChanges();
            }
        }
        #endregion

        #region Return a book
        public void ReturnBook(string bookTitle, int libraryCardNumber)
        {
            var bookToReturn = context.Books.FirstOrDefault(b => b.BookTitle == bookTitle && b.Borrowed);

            if (bookToReturn != null)
            {
                var borrower = context.Borrowers.FirstOrDefault(b => b.LibraryCardNumber == libraryCardNumber);

                if (borrower != null)
                {
                    borrower.BorrowedBooks.Remove(bookToReturn);
                    bookToReturn.Borrowed = false;
                    bookToReturn.BorrowDate = null;
                    bookToReturn.ReturnDate = DateTime.Now;

                    context.Borrowers.Remove(borrower);

                    //borrower.BorrowedBooks.Clear();

                    context.SaveChanges();
                }

            }
        }
        #endregion

        #region Delete a book
        public void DeleteBook(string bookTitle)
        {
            var bookToDelete = context.Books.FirstOrDefault(b => b.BookTitle == bookTitle);

            if (bookToDelete != null)
            {
                context.Books.Remove(bookToDelete);
                context.SaveChanges();
            }
        }
        #endregion
    }
}

