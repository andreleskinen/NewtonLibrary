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
            var author1 = new Author { FirstName = "David", LastName = "Goggings" };
            var author2 = new Author { FirstName = "Harper", LastName = "Lee" };
            var author3 = new Author { FirstName = "F.Scott", LastName = "Fitzgerald" };
            var author4 = new Author { FirstName = "J.K", LastName = "Rowling" };
            var author5 = new Author { FirstName = "J.R.R", LastName = "Tolkien" };

            var book1 = new Book { BookTitle = "Can´t Hurt Me", AuthorId = author1.AuthorId, ISBN = "978-1-4321-0987-6", PublicationYear = 2018, Rating = 4.9, Borrowed = false };
            var book2 = new Book { BookTitle = "To Kill a Mockingbird", AuthorId = author2.AuthorId, ISBN = "978-0-06-112008-4", PublicationYear = 1960, Rating = 4.3, Borrowed = false };
            var book3 = new Book { BookTitle = "The Great Gatsby", AuthorId = author3.AuthorId, ISBN = "978-0-7432-7356-5", PublicationYear = 1925, Rating = 4.2, Borrowed = false };
            var book4 = new Book { BookTitle = "Harry Potter and the Sorcerer's Stone", AuthorId = author4.AuthorId, ISBN = "978-0-7679-2766-6", PublicationYear = 1997, Rating = 4.75, Borrowed = false };
            var book5 = new Book { BookTitle = "The Hobbit", AuthorId = author5.AuthorId, ISBN = "978-0-261-10295-3", PublicationYear = 1937, Rating = 4.3, Borrowed = false };
            var book6 = new Book { BookTitle = "Harry Potter and the Prisoner of Azkaban", AuthorId = author4.AuthorId, ISBN = "13: 978-1-234567-89-0", PublicationYear = 1999, Rating = 2.5, Borrowed = false };

            author1.Books.Add(book1);
            author2.Books.Add(book2);
            author3.Books.Add(book3);
            author4.Books.Add(book4);
            author4.Books.Add(book6); 
            author5.Books.Add(book5);

            context.Authors.AddRange(author1, author2, author3, author4, author5);
            context.Books.AddRange(book1, book2, book3, book4, book5, book6);

            context.SaveChanges();

            Console.WriteLine("Seed Data added to to database!");
            Thread.Sleep(2000);

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

        #region Create a book
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

        #region Create a Borrower
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

            Thread.Sleep(2000);
        }
        #endregion

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

            Console.WriteLine($"Book with ID {selectedBorrowerId} {book.BookTitle} has been borrwed");
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

            Console.WriteLine("Select a Book ID");


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
        public void DeleteBook()
        {
            List<Book> books = context.Books.ToList();

            Console.WriteLine("Select a Book ID to delete");

            if (books.Count == 0)
            {
                Console.WriteLine("No books to delete");
                return;
            }

            books.ForEach(book =>
            {
                Console.WriteLine($"{book.BookId}: {book.BookTitle}");
            });

            int.TryParse(Console.ReadLine(), out int selectedBookId);

            Book bookToDelete = context.Books.FirstOrDefault(book => book.BookId == selectedBookId);

            if (bookToDelete == null)
            {
                Console.WriteLine("Invalid Book ID. No book deleted.");
                return;
            }

            Console.WriteLine($"Book with ID {selectedBookId} has been deleted.");

            context.Books.Remove(bookToDelete);
            context.SaveChanges();

            Thread.Sleep(2000);


        }
        #endregion

        #region Delete an author
        public void DeleteAuthor()
        {
            List<Author> authors = context.Authors.ToList();

            Console.WriteLine("Select an Author ID to delete");
            

            if (authors.Count == 0)
            {
                Console.WriteLine("No authors to delete");
                return;
            }

            authors.ForEach(author =>
            {
                Console.WriteLine($"{author.AuthorId} {author.FirstName} {author.LastName}");
            });

            int.TryParse(Console.ReadLine(), out int selectedAuthorId);

            Author authorToDelete = context.Authors.FirstOrDefault(author => author.AuthorId == selectedAuthorId);

            if (authorToDelete == null)
            {
                Console.WriteLine("Invalid Author ID. No author deleted.");
                return;
            }

            Console.WriteLine($"Author with ID {selectedAuthorId} has been deleted.");

            context.Authors.Remove(authorToDelete);
            context.SaveChanges();

            Thread.Sleep(2000); 

        }
        #endregion

        #region Delete a borrower
        public void DeleteBorrower()
        {
            List<Borrower> borrowers = context.Borrowers.ToList();

            Console.WriteLine("Select a borrower ID to delete");

            if (borrowers.Count == 0)
            {
                Console.WriteLine("No borrowers to delete");
                return;
            }

            borrowers.ForEach(borrower =>
            {
                Console.WriteLine($"{borrower.BorrowerId} {borrower.FirstName} {borrower.LastName}");
            });

            int.TryParse(Console.ReadLine(), out int selectedBorrwerId);

            Borrower borrowerToDelete = context.Borrowers.FirstOrDefault(borrower => borrower.BorrowerId == selectedBorrwerId);

            if (borrowerToDelete == null)
            {
                Console.WriteLine("Invalid Borrwer ID. No Borrwer deleted.");
                return;
            }

            Console.WriteLine($"Borrwer with ID {selectedBorrwerId} has been deleted.");

            context.Borrowers.Remove(borrowerToDelete);
            context.SaveChanges();

            Thread.Sleep(2000);
        }
        #endregion
    }
}

