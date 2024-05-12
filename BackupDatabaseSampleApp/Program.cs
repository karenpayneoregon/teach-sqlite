using System.Data.SQLite;
using System.IO;
using System.Text.Json;
using BackupDatabaseSampleApp.Classes;
using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;

namespace BackupDatabaseSampleApp;

internal partial class Program
{
    private static string _name = "NorthWindContacts.db";
    private static string ConnectionString() => $"Data Source={_name}";

    


    static void Main(string[] args)
    {

        var _configuration = Configuration.JsonRoot();
        var appSettings = _configuration.GetRequiredSection("Settings").Get<AppSettings>();
        AnsiConsole.MarkupLine("[yellow]ServiceDetails[/]");
        Console.WriteLine($"   UseMemory: {appSettings.UseMemory}");
        Console.WriteLine($"Cors.Origins: {appSettings.Cors.Origins}");
        Console.WriteLine($"Cors.Headers: {appSettings.Cors.Headers}");
        Console.WriteLine($"Cors.Methods: {appSettings.Cors.Methods}");

        //BackupOperations.PerformBackup(
        //    Path.Combine("Backups", Path.GetFileName(GenerateFiles.NextFileName())!), 
        //    ConnectionString());

        Console.ReadLine();
    }

}

public class AppSettings
{
    public bool? UseMemory { get; set; }
    public CorsSettings? Cors { get; set; }
}

public class CorsSettings
{
    public required string Origins { get; set; }
    public required string Headers { get; set; }
    public required string Methods { get; set; }
}
public class Settings1
{
    public MailAddress[] MailAddress { get; set; }
}
public class MailAddress
{
    public string Address { get; set; }
    public string Display { get; set; }
}