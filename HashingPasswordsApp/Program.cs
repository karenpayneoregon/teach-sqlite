using HashingPasswordsApp.Classes;

namespace HashingPasswordsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        DapperOperations.Add();
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}