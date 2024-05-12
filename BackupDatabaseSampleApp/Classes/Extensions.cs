using System.Data.SQLite;

namespace BackupDatabaseSampleApp.Classes;

internal static class Extensions
{
    public static void BackupDatabase(this SQLiteConnection source, SQLiteConnection destination)
    {
        source.Open();
        destination.Open();
        source.BackupDatabase(destination, "main", "main", -1, null, 0);
    }
}