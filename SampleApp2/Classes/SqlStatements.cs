namespace SampleApp2.Classes;
public class SqlStatements
{
    public static string GetPartialContact =>
        """
        SELECT ContactId,
               FirstName,
               LastName,
               ContactTypeIdentifier
        FROM Contacts
        WHERE ContactId = @ContactId
        """;
}
