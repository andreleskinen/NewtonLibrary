using Library.Data;

namespace Library;

class Program
{
    static void Main(string[] args)
    {
        DataAccess dataAccess = new DataAccess();
        dataAccess.Seed();
    }
}

