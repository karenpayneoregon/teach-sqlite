using System.Data.SQLite;
using BackupDatabaseSampleApp.Classes;

namespace BackupDatabaseSampleApp;

internal partial class Program
{
    private static string _name = "NorthWindContacts.db";
    private static string ConnectionString()
        => $"Data Source={_name}";

    private static string _backupDatabaseName => "BackupSample.db";


    static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("[cyan]Backing up database[/]");
        try
        {
            if (File.Exists(_backupDatabaseName))
            {
                File.Delete(_backupDatabaseName);
            }

            var backup = new SQLiteConnection($"Data Source={_backupDatabaseName}");
            using var cn = new SQLiteConnection(ConnectionString());
            cn.BackupDatabase(backup);
            AnsiConsole.MarkupLine("[green]Database backed up successfully[/]");
        }
        catch (Exception ex)
        {
            AnsiConsole.WriteException(ex);
        }

        Console.ReadLine();
    }
    
}