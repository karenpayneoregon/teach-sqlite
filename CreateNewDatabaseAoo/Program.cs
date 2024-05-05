using CreateNewDatabaseApp.Classes;

namespace CreateNewDatabaseApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        //DapperOperations.CreateDatabaseAddDataShowData();
        EntityOperations.CreateDatabaseAddDataShowData();


        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}