namespace BackupLibrary.Classes;

/// <summary>
/// SQL Statements for this application
/// </summary>
internal class SqlStatements
{
    /// <summary>
    /// Get top 15 contacts with office phone numbers, ordered by last name.
    /// </summary>
    public static string GetContactsWithOfficePhone =>
        """
        SELECT  c.ContactId,
               ct.ContactTitle,
               c.FirstName,
               c.LastName,
               c.ContactTypeIdentifier,
               pt.PhoneTypeDescription,
               cd.PhoneNumber,
               pt.PhoneTypeIdenitfier,
               cd.id
        FROM Contacts AS c
            INNER JOIN ContactDevices AS cd
                ON c.ContactId = cd.ContactId
            INNER JOIN ContactType AS ct
                ON c.ContactTypeIdentifier = ct.ContactTypeIdentifier
            INNER JOIN PhoneType AS pt
                ON cd.PhoneTypeIdentifier = pt.PhoneTypeIdenitfier
            WHERE pt.PhoneTypeIdenitfier = 3
            ORDER BY c.LastName
            LIMIT 15
        """;
}
