using System.Data.SQLite;
using BackupDatabaseSampleApp.Classes;
using BackupDatabaseSampleApp.Models;
using Dapper;

namespace BackupDatabaseSampleApp;

internal partial class Program
{
    private static string _name = "NorthWindContacts.db";
    private static string ConnectionString() => $"Data Source={_name}";
    
    static void Main(string[] args)
    {

        var list = Contacts();

        var table = CreateTable();
        foreach (var contact in list)
        {
            table.AddRow(contact.Id.ToString(), contact.FirstName, contact.LastName);
        }
        
        AnsiConsole.Write(table);

        Console.WriteLine();
        
        var (success, exception) = BackupOperations.PerformBackup(Path.Combine("Backups", Path.GetFileName(GenerateFiles.NextFileName())!));
        if (success)
        {
            AnsiConsole.MarkupLine("[LightGreen]Backup completed successfully![/]");
        }
        else
        {
            AnsiConsole.WriteException(exception);
        }

        SpectreConsoleHelpers.ExitPrompt();
    }

    public static List<Contact> Contacts()
    {
        using var cn = new SQLiteConnection(BackupSettings.Instance.ConnectionString);
        return cn.Query<Contact>(SqlStatements.GetContactsWithOfficePhone).ToList();
    }

    public static Table CreateTable()
    {
        var table = new Table()
            .RoundedBorder()
            .AddColumn("[b]Id[/]")
            .AddColumn("[b]First[/]")
            .AddColumn("[b]Last[/]")
            .Alignment(Justify.Left)
            .BorderColor(Color.LightSlateGrey)
            .Title("[LightGreen]Contacts top 15[/]");
        return table;
    }

}