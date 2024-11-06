using System.Data;
using System.Data.SQLite;

namespace CreateNewDatabaseApp.LanguageExtensions;
public static class SQLiteExtensions
{
    /// <summary>
    /// Provides a way to remove the database file
    /// </summary>
    /// <param name="cn"></param>
    public static void EnsureDeleted(this SQLiteConnection cn)
    {
        if (cn.State == ConnectionState.Open)
        {
            cn.Close();
        }

        SQLiteConnectionStringBuilder builder = new(cn.ConnectionString);
        if (File.Exists(builder.DataSource))
        {
            File.Delete(builder.DataSource);
        }

    }
}
