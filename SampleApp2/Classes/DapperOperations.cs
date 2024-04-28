#nullable disable
using System.Data.SQLite;
using Dapper;
using SampleApp2.Models;

namespace SampleApp2.Classes;

public class DapperOperations
{
    private static string _name = "NorthWindContacts.db";
    private static string ConnectionString()
        => $"Data Source={_name}";

    public static ContactMinimal Contacts(int id)
    {
        using var cn = new SQLiteConnection(ConnectionString());
        return cn.Query<ContactMinimal>(SqlStatements.GetPartialContact, new { ContactId = id }).FirstOrDefault();
    }

}