using System.Data.SQLite;
using Dapper;

namespace HashingPasswordsApp.Classes;
internal class DapperOperations
{
    private static string _name = "HashingPasswords.db";
    private static string ConnectionString() => $"Data Source={_name}";

    public static void Add()
    {

        Clients clients = new()
        {
            UserName = "JohnDoe",
            UserPassword = BC.HashPassword("MyPassword")
        };

        var addStatement =
            """
            INSERT INTO Clients (UserName, UserPassword)
            VALUES (@UserName, @UserPassword);
            SELECT last_insert_rowid();
            """;

        using var cn = new SQLiteConnection(ConnectionString());
        clients.Id = cn.ExecuteScalar(addStatement,clients).GetId();

        AnsiConsole.MarkupLine($"[bold yellow]Client {clients.UserName} added with Id {clients.Id}[/]");

        var selectStatement =
            """
            SELECT * FROM Clients WHERE UserName = 'JohnDoe';
            """;

        var client = cn.QueryFirstOrDefault<Clients>(selectStatement);

        var verified = BC.Verify("MyPassword", client.UserPassword);

        AnsiConsole.MarkupLine(verified ? "[bold green]Password verified[/]" : "[bold red]Password not verified[/]");
    }
}
