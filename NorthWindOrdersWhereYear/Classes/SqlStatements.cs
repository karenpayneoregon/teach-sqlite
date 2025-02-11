namespace NorthWindOrdersWhereYear.Classes;
internal class SqlStatements
{
    public static string OrdersByYear => 
        """
        SELECT OrderID,
               CustomerIdentifier,
               EmployeeID,
               OrderDate,
               RequiredDate,
               ShippedDate,
               DeliveredDate,
               ShipVia,
               Freight,
               ShipAddress,
               ShipCity,
               ShipPostalCode,
               ShipCountry
        FROM Orders
        WHERE strftime('%Y', OrderDate) = @Year;
        """;
}
