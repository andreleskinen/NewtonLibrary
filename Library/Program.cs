using Library.Data;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        //dataAccess.Seed();            //method to add already existing data to the database

        dataAccess.BorrowBook("The Great Gatsby", "André", "Leskinen", 930503);     //parametarar som skickas till metoden i dataAcess

        //dataAccess.ReturnBook("The Great Gatsby", 930503);


    }
}

