using System.Data;
using System.Data.SQLite;
using System.Text;
using System.Text.RegularExpressions;
using DbPeekQueryLibrary.LanguageExtensions;
using Serilog;

namespace SampleApp2.Classes;
internal partial class PeekOperation
{
    private const string _name = "NorthWindContacts.db";
    private static string ConnectionString() => $"Data Source={_name}";

    /// <summary>
    /// Peek at a SQlLite parameter 
    /// </summary>
    /// <param name="id">contact type</param>
    /// <remarks>
    /// Here a default value is set in a real app there would not be a default value
    /// </remarks>
    public static void RevealCommandText(int id = 12)
    {
        string sql = """
                     SELECT ContactId,FirstName,LastName FROM Contacts
                     WHERE ContactTypeIdentifier = @ContactTypeIdentifier;
                     """;
        
        using var cn = new SQLiteConnection(ConnectionString());
        using SQLiteCommand cmd = new() { Connection = cn, CommandText = sql };
        cmd.Parameters.Add("@ContactTypeIdentifier", DbType.Int32).Value = id;
        cn.Open();

        using var reader = cmd.ExecuteReader();
        
        if (reader.HasRows)
        {
            // builder to hold the results for testing only
            StringBuilder builder = new();
            while (reader.Read())
            {
                builder.AppendLine($"{reader.GetInt32(0),-4}{reader.GetString(1)} {reader.GetString(2)}");
            }
        }
        else
        {
            var statement = cmd.ActualCommandText();
            var resultString = GetNumber().Match(statement).Value;
            if (int.TryParse(resultString, out var value))
            {
                Log.Information("Failed to find results in {P1} ContactTypeIdentifier = {P2}", nameof(RevealCommandText), value );
            }
        }

    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex GetNumber();
}
