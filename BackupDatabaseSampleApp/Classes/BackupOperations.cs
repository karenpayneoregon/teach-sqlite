using System.Data.SQLite;
using Serilog;

namespace BackupDatabaseSampleApp.Classes;
public static class BackupOperations
{
    public static (bool success, Exception exception) PerformBackup(string _backupDatabaseName)
    {

        try
        {
            if (File.Exists(_backupDatabaseName))
            {
                File.Delete(_backupDatabaseName);
            }

            var backup = new SQLiteConnection($"Data Source={_backupDatabaseName}");
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
