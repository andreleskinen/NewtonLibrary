using Library.Data;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        //dataAccess.Seed();            //method to add already existing data to the database

        dataAccess.BorrowBook("The Great Gatsby", "André", "Leskinen", 930503);     //method to borrow a book

        //dataAccess.ReturnBook("The Great Gatsby", 930503);


    }
}

