using System.Data;
using System.Data.SQLite;

namespace NorthWindCategories.Classes;
internal class DataOperations
{
    private static string _name = "NorthWind2024.db";
    private static string ConnectionString() => $"Data Source={_name}";

    public static DataTable Read()
    {
        var dt = new DataTable();
        using var cn = new SQLiteConnection(ConnectionString());
        cn.Open();
        using var cmd = cn.CreateCommand();
        cmd.CommandText = "SELECT CategoryID,CategoryName,Description,Picture FROM Categories";
        dt.Load(cmd.ExecuteReader());
        return dt;
    }
    public static (bool success, Exception exception) Insert(string fileName)
    {
        try
        {
            var text = Path.GetFileName(fileName);
            var bytes = File.ReadAllBytes(fileName);
            using var cn = new SQLiteConnection(ConnectionString());
            cn.Open();
            using var cmd = cn.CreateCommand();
            cmd.CommandText =
                $"""
                INSERT INTO Categories (CategoryName,Description,Picture) 
                VALUES ('{text}','{text}',@Picture)
                """;
            cmd.Parameters.Add("@Picture", DbType.Binary, 20).Value = bytes;
            cmd.ExecuteNonQuery();
            return (true, null)!;
        }
        catch (Exception ex)
        {
            return (false,ex);
        }
    }
}
