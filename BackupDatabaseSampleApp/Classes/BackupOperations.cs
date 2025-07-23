using System.Data.SQLite;
using Serilog;

namespace BackupDatabaseSampleApp.Classes;
public static class BackupOperations
{
    /// <summary>
    /// Performs a backup operation for the specified database.
    /// </summary>
    /// <param name="backupDatabaseName">
    /// The name of the backup database file to be created. If the file already exists, it will be deleted before the backup.
    /// </param>
    /// <returns>
    /// A tuple containing a boolean indicating success or failure, and an <see cref="Exception"/> object if an error occurs.
    /// </returns>
    /// <remarks>
    /// This method connects to the source database using the connection string from <see cref="BackupSettings.Instance"/> 
    /// and performs a backup to the specified destination database file.
    /// </remarks>
    /// <exception cref="Exception">
    /// Thrown if an error occurs during the backup process. The exception is logged and returned in the result tuple.
    /// </exception>
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

    /// <summary>
    /// Backs up the contents of the source SQLite database to the destination SQLite database.
    /// </summary>
    /// <param name="source">
    /// The source <see cref="SQLiteConnection"/> representing the database to be backed up.
    /// </param>
    /// <param name="destination">
    /// The destination <see cref="SQLiteConnection"/> representing the database where the backup will be stored.
    /// </param>
    /// <remarks>
    /// This method opens both the source and destination connections and performs the backup operation.
    /// The backup process is executed for the "main" database schema.
    /// </remarks>
    /// <exception cref="SQLiteException">
    /// Thrown if an error occurs while opening the connections or during the backup process.
    /// </exception>
    public static void BackupDatabase(this SQLiteConnection source, SQLiteConnection destination)
    {
        source.Open();
        destination.Open();
        source.BackupDatabase(destination, "main", "main", -1, null, 0);
    }
}
