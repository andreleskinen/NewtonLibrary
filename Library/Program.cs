using Library.Data;
using Helpers;
using System;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please select what you'd like to do:");

            Console.WriteLine("0. Seed DB");
            Console.WriteLine("1. Create Author");
            Console.WriteLine("2. Create Book");
            Console.WriteLine("3. Create Borrower");
            Console.WriteLine("4. Borrow Book");
            Console.WriteLine("5. Return Book");
            Console.WriteLine("6. Delete Book");
            Console.WriteLine("7. Delete Borrower");
            Console.WriteLine("8. Delete Author");

            if (int.TryParse(Console.ReadLine(), out int selectedAction))
            {
                switch (selectedAction)
                {
                    case 0:
                        dataAccess.Seed();
                        break;
                    case 1:
                        dataAccess.CreateAuthor();
                        break;
                    case 2:
                        dataAccess.CreateBook();
                        break;
                    case 3:
                        dataAccess.CreateBorrower();
                        break;
                    case 4:
                        dataAccess.BorrowBook();
                        break;
                    case 5:
                        dataAccess.ReturnBook();
                        break;
                    case 6:
                        dataAccess.DeleteBook();
                        break;
                    case 7:
                        dataAccess.DeleteBorrower();
                        break;
                    case 8:
                        dataAccess.DeleteAuthor();
                        break;
                }
            }
        }
    }
}

