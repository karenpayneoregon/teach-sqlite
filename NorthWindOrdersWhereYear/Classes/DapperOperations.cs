using System.Data.SQLite;
using Dapper;
using NorthWindOrdersWhereYear.Models;

namespace NorthWindOrdersWhereYear.Classes;
internal class DapperOperations
{
    private static string _name = "NorthWind2024.db";
    private static string ConnectionString() => $"Data Source={_name}";

    public static List<Orders> OrdersByYear(string year)
    {
        using var cn = new SQLiteConnection(ConnectionString());
        return cn.Query<Orders>(SqlStatements.OrdersByYear, new { Year = year }).ToList();
    }
}
