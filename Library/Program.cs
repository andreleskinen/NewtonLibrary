using Library.Data;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        //dataAccess.Seed();            //method to add already existing data to the database

        //dataAccess.BorrowBook("To Kill a Mockingbird", "André", "Leskinen", 930503);     //parametarar som skickas till metoden i dataAcess

        dataAccess.ReturnBook("To Kill a Mockingbird", 930503);


    }
}

