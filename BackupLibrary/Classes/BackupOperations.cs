using System.Data.SQLite;
using Serilog;

namespace BackupDatabaseSampleApp.Classes;
public static class BackupOperations
{
    /// <summary>
    /// Entry point for backup operation
    /// </summary>
    /// <param name="backupDatabaseName">Name of database provided from <see cref="GenerateFiles"/> </param>
    /// <returns></returns>
    public static (bool success, Exception exception) PerformBackup(string backupDatabaseName)
    {

        try
        {
            if (File.Exists(backupDatabaseName))
            {
                File.Delete(backupDatabaseName);
            }

            // setup connection string for backup database
            var backup = new SQLiteConnection($"Data Source={backupDatabaseName}");
            using var cn = new SQLiteConnection(BackupSettings.Instance.ConnectionString);
            
            cn.BackupDatabase(backup);

            Log.Information("Backup successful");
            return (true, null);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Backup failed");
            return (false, ex);
        }
    }

    public static void BackupDatabase(this SQLiteConnection source, SQLiteConnection destination)
    {
        source.Open();
        destination.Open();
        source.BackupDatabase(destination, "main", "main", -1, null, 0);
    }
}
