using System.Data;
using System.Data.SQLite;
using Dapper;

namespace NorthWindCategories.Classes;
internal class DataOperations
{
    private static string _name = "NorthWind2024.db";
    private static string ConnectionString() => $"Data Source={_name}";

    /// <summary>
    /// Reads data from the "Categories" table in the database and returns it as a <see cref="DataTable"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="DataTable"/> containing the data from the "Categories" table, 
    /// including the columns "CategoryId", "CategoryName", "Description", and "Picture".
    /// </returns>
    /// <remarks>
    /// This method establishes a connection to the SQLite database, executes a query to retrieve data from the "Categories" table, 
    /// and loads the result into a <see cref="DataTable"/>.
    /// </remarks>
    /// <exception cref="SQLiteException">Thrown if there is an issue with the database operation.</exception>
    public static DataTable Read()
    {
        using var cn = new SQLiteConnection(ConnectionString());
        cn.Open();

        using var reader = cn.ExecuteReader(
            """
            SELECT CategoryId, CategoryName, Description, Picture 
            FROM Categories
            """);

        var dt = new DataTable();
        dt.Load(reader);

        return dt;
    }

    /// <summary>
    /// Inserts a new record into the "Categories" table in the database using the specified image file.
    /// </summary>
    /// <param name="fileName">The full path to the image file to be inserted into the database.</param>
    /// <returns>
    /// A tuple containing:
    /// <list type="bullet">
    /// <item>
    /// <term>success</term>
    /// <description>A <see cref="bool"/> indicating whether the operation was successful.</description>
    /// </item>
    /// <item>
    /// <term>exception</term>
    /// <description>An <see cref="Exception"/> object if an error occurred, or <see langword="null"/> if the operation was successful.</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <remarks>
    /// The method reads the specified image file, extracts its name and content, and inserts it into the "Categories" table
    /// with the file name used as both the category name and description.
    /// </remarks>
    /// <exception cref="FileNotFoundException">Thrown if the specified file does not exist.</exception>
    /// <exception cref="SQLiteException">Thrown if there is an issue with the database operation.</exception>
    public static (bool success, Exception exception) InsertRecord(string fileName)
    {
        try
        {
            var text = Path.GetFileName(fileName);
            var bytes = File.ReadAllBytes(fileName);

            using var cn = new SQLiteConnection(ConnectionString());
            cn.Open();

            var sql = """
                      INSERT INTO Categories (CategoryName, Description, Picture)
                      VALUES (@CategoryName, @Description, @Picture)
                      """;

            var parameters = new
            {
                CategoryName = text,
                Description = text,
                Picture = bytes
            };

            cn.Execute(sql, parameters);

            return (true, null)!;

        }
        catch (Exception ex)
        {
            // for a real application use SeriLog.
            return (false, ex);
        }
    }

}
