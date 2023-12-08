using Library.Data;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        //dataAccess.Seed();                                                            //method to add seed data to the database

        dataAccess.BorrowBook("To Kill a Mockingbird", "André", "Leskinen", 930503);    //Låna en bok


        //dataAccess.ReturnBook("To Kill a Mockingbird", 930503);                       //Lämna tillbaka en bok                      


        //dataAccess.DeleteBook("The Hobbit");                                          //radera en bok/column från tabellen
    }
}

