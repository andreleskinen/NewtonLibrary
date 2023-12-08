using Library.Data;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        //dataAccess.Seed();            //method to add seed data to the database

        //.BorrowBook("To Kill a Mockingbird", "André", "Leskinen", 930503);     //parametarar som skickas till metoden i dataAcess, Låna en bok
        
        //dataAccess.ReturnBook("Can´t Hurt Me", 143050);     //Parmeterar som skickas till metoden i dataAccess, Lämna tillbaka en bok                      


        //dataAccess.DeleteBook("The Hobbit"); // används för att radera en bok/column från tabellen
    }
}

