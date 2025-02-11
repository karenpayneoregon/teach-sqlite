using NorthWindOrdersWhereYear.Classes;

namespace NorthWindOrdersWhereYear;

internal partial class Program
{
    static void Main(string[] args)
    {

        var year = "2015";
        var orders = DapperOperations.OrdersByYear(year);
        AnsiConsole.MarkupLine($"[yellow]Orders for {year}[/] {orders.Count}");
        Console.ReadLine();
    }
}