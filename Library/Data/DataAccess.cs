using System;
using Helpers;
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
            var author1 = new Author { FirstName = "John", LastName = "Wick" };
            var author2 = new Author { FirstName = "Joe", LastName = "Rogan" };
            var author3 = new Author { FirstName = "Bill", LastName = "Murray" };
            var author4 = new Author { FirstName = "Donald", LastName = "Trump" };
            var author5 = new Author { FirstName = "Spgonlge", LastName = "Katt" };
            context.Authors.AddRange(author1, author2, author3, author4, author5);

            context.SaveChanges();



            var book1 = new Book { BookTitle = "Can´t Hurt Me", AuthorId = author1.AuthorId, ISBN = "978-1-4321-0987-6", PublicationYear = 2018, Rating = 4.9, Borrowed = false };
            var book2 = new Book { BookTitle = "To Kill a Mockingbird", AuthorId = author2.AuthorId, ISBN = "978-0-06-112008-4", PublicationYear = 1960, Rating = 4.3, Borrowed = false };
            var book3 = new Book { BookTitle = "The Great Gatsby", AuthorId = author3.AuthorId, ISBN = "978-0-7432-7356-5", PublicationYear = 1925, Rating = 4.2, Borrowed = false };
            var book4 = new Book { BookTitle = "Harry Potter and the Sorcerer's Stone", AuthorId = author4.AuthorId, ISBN = "978-0-7679-2766-6", PublicationYear = 1997, Rating = 4.75, Borrowed = false };
            var book5 = new Book { BookTitle = "The Hobbit", AuthorId = author5.AuthorId, ISBN = "978-0-261-10295-3", PublicationYear = 1937, Rating = 4.3, Borrowed = false };
            var book6 = new Book { BookTitle = "Harry Potter and the Prisoner of Azkaban", AuthorId = author4.AuthorId, ISBN = "13: 978-1-234567-89-0", PublicationYear = 1999, Rating = 2.5, Borrowed = false };
            context.Books.AddRange(book1, book2, book3, book4, book5, book6);
            

            context.SaveChanges();
        }
        #endregion
        

        #region Create an author
        public void CreateAuthor()
        {
            string? AuthorFirstName = "";
            string? AuthorLastName = "";

            Console.WriteLine("Entier firstName");
            AuthorFirstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            AuthorLastName = Console.ReadLine();

            Console.WriteLine("Author has been added");
            Console.WriteLine("Returning to main menu");

            var author = new Author { FirstName = AuthorFirstName, LastName = AuthorLastName };

            context.Authors.Add(author);
            context.SaveChanges();
        }
        #endregion


        #region
        public void CreateBook()
        {
            List<Author> authors = context.Authors.ToList();

            Console.WriteLine("Select an author");

            while (true)
            {
                authors.ForEach((author) =>
                {
                    Console.WriteLine($"{author.AuthorId}: {author.FirstName} {author.LastName}");

                });
                if (int.TryParse(Console.ReadLine(), out int selectedAuthor))
                {
                    Console.WriteLine("Name your book");
                    string NamedBookTitle = Console.ReadLine();

                    Console.WriteLine("enter ISBN");
                    string isbn = Console.ReadLine();

                    Console.WriteLine("Enter Publication Year");
                    int.TryParse(Console.ReadLine(), out int publicationYear);

                    Console.WriteLine("Enter Rating 1-5");
                    double.TryParse(Console.ReadLine(), out double rating);

                    var book = new Book {
                        BookTitle = NamedBookTitle,
                        AuthorId = selectedAuthor,
                        ISBN = isbn,
                        PublicationYear = publicationYear,
                        Rating = rating
                    };

                    context.Books.Add(book);
                    context.SaveChanges();
                    break;
                }

                Console.WriteLine("Invalid author, please select by typing their ID");
            }

        }
        #endregion

        public void CreateBorrower()
        {
            Console.WriteLine("Enter the borrowers firstname");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter the borrowers lastname");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter the borrowers library card number");
            int.TryParse(Console.ReadLine(), out int libraryCardNumber);

            var borrower = new Borrower { FirstName = firstName, LastName = lastName, LibraryCardNumber = libraryCardNumber };

            context.Borrowers.Add(borrower);

            context.SaveChanges();

            Console.WriteLine($"Saved borrower {borrower.BorrowerId} successfully!");
        }

        #region Borrow a book
        public void BorrowBook()
        {
            List<Book> books = context.Books.ToList().FindAll(book => book.BorrowerId == null);
            Console.WriteLine("Select a Book");


            books.ForEach(book =>
            {
                Console.WriteLine($"{book.BookId}: {book.BookTitle}");
            });

            int.TryParse(Console.ReadLine(), out int selectedBookId);

            List<Borrower> borrowers = context.Borrowers.ToList();
            Console.WriteLine("Select a Borrower");

            borrowers.ForEach(borrower =>
            {
                Console.WriteLine($"{borrower.BorrowerId}: {borrower.FirstName} {borrower.LastName}");
            });

            int.TryParse(Console.ReadLine(), out int selectedBorrowerId);

            Book book = context.Books.First(book => book.BookId == selectedBookId);
            Borrower borrower = context.Borrowers.First(book => book.BorrowerId== selectedBorrowerId);

            borrower.BorrowedBooks.Add(book);
            book.BorrowDate = DateTime.Now;
            book.BorrowerId = borrower.BorrowerId;

            context.SaveChanges();



            /*if (bookToBorrow != null && !bookToBorrow.Borrowed) //Kollar så att boken finns i tabbel och att den inte är uthyrd
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
        }*/
        }
        #endregion

        #region Return a book
        public void ReturnBook()
        {
            List<Book> books = context.Books.ToList().FindAll(book => book.BorrowerId != null);

            if(books.Count == 0)
            {
                return;
            }

            Console.WriteLine("Select a Book");


            books.ForEach(book =>
            {
                Console.WriteLine($"{book.BookId}: {book.BookTitle}");
            });

            int.TryParse(Console.ReadLine(), out int selectedBookId);

            Book book = context.Books.First(book => book.BookId == selectedBookId);
            Borrower borrower = context.Borrowers.First(borrower => borrower.BorrowerId == book.BorrowerId);

            borrower.BorrowedBooks.Remove(book);
            book.ReturnDate = DateTime.Now;
            book.BorrowerId = null;

            context.SaveChanges();
        }
        #endregion

        #region Delete a book
        public void DeleteBook(int bookId)
        {
            var bookToDelete = context.Books.FirstOrDefault(b => b.BookId == bookId);

            if (bookToDelete != null)
            {
                context.Books.Remove(bookToDelete);
                context.SaveChanges();
            }
        }
        #endregion


    }
}

