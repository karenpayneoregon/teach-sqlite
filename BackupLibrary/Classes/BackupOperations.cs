using System.Data.SQLite;
using Serilog;

namespace BackupLibrary.Classes;
public static class BackupOperations
{
    /// <summary>
    /// Performs a backup operation by creating a backup of the database specified by the provided name.
    /// </summary>
    /// <param name="backupDatabaseName">
    /// The name of the backup database file to be created. If the file already exists, it will be deleted before the backup operation.
    /// </param>
    /// <returns>
    /// A tuple containing a boolean indicating the success of the operation and an <see cref="Exception"/> object if an error occurs.
    /// If the operation is successful, the exception will be <c>null</c>.
    /// </returns>
    /// <remarks>
    /// This method uses the connection string from <see cref="BackupSettings.Instance.ConnectionString"/> to connect to the source database.
    /// It logs the success or failure of the operation using Serilog.
    /// </remarks>
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
            return (true, null)!;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Backup failed");
            return (false, ex);
        }
    }
    
    /// <summary>
    /// Backs up the contents of the source SQLite database connection to the destination SQLite database connection.
    /// </summary>
    /// <param name="source">
    /// The source <see cref="SQLiteConnection"/> representing the database to be backed up.
    /// </param>
    /// <param name="destination">
    /// The destination <see cref="SQLiteConnection"/> representing the database where the backup will be stored.
    /// </param>
    /// <remarks>
    /// This method opens both the source and destination connections, performs the backup operation, and maps the "main" database schema.
    /// Ensure that both connections are properly configured before invoking this method.
    /// </remarks>
    public static void BackupDatabase(this SQLiteConnection source, SQLiteConnection destination)
    {
        source.Open();
        destination.Open();
        source.BackupDatabase(destination, "main", "main", -1, null, 0);
    }
}
