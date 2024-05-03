namespace SampleApp1.Classes;

/// <summary>
/// SQL Statements for this application
/// </summary>
internal class SqlStatements
{
    public static string GetContactsWithOfficePhone =>
        """
        SELECT c.ContactId,
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
        """;

    public static string ContactTypes =>
        """
        SELECT ContactTypeIdentifier,
               ContactTitle
        FROM ContactType;
        """;

    public static string GetContactById =>
        """
        SELECT c.ContactId,
               ct.ContactTitle,
               c.FirstName,
               c.LastName,
               c.ContactTypeIdentifier,
               pt.PhoneTypeDescription,
               cd.PhoneNumber,
               pt.PhoneTypeIdenitfier
        FROM dbo.Contacts AS c
            INNER JOIN dbo.ContactDevices AS cd
                ON c.ContactId = cd.ContactId
            INNER JOIN dbo.ContactType AS ct
                ON c.ContactTypeIdentifier = ct.ContactTypeIdentifier
            INNER JOIN dbo.PhoneType AS pt
                ON cd.PhoneTypeIdentifier = pt.PhoneTypeIdenitfier
        WHERE c.ContactId = @ContactId
        """;

    public static string ContactNames =>
        """
        SELECT ContactId,
               FirstName + ' ' + LastName AS FullName,
               ContactTypeIdentifier
        FROM dbo.Contacts;
        """;

    /// <summary>
    /// Find contact by last name
    /// </summary>
    /// <param name="casing">true for case-insensitive</param>
    /// <returns></returns>
    /// <remarks>
    /// Useful only when a column is not set to case-insensitive
    /// </remarks>
    public static string ContactByLastName(bool casing) =>
        $"""
          SELECT ContactId,
                 ContactTypeIdentifier
          FROM Contacts
          WHERE LastName = @LastName {(casing ? "COLLATE NOCASE" : "")};
          """;


    public static string UpdateContact =>
        """
        UPDATE Contacts
        SET FirstName = @FirstName,
        LastName = @LastName,
        ContactTypeIdentifier = @ContactTypeIdentifier
        WHERE ContactId = @ContactId
        """;

    public static string UpdateDevice =>
        """
        UPDATE ContactDevices
          SET ContactId = @ContactId
             ,PhoneTypeIdentifier = @PhoneTypeIdentifier
             ,PhoneNumber = @PhoneNumber
        WHERE Id = @Id
        """;

    /// <summary>
    /// Removes a contact from Contact and ContactDevices tables
    /// </summary>
    public static string RemoveContact =>
        """
        DELETE FROM Contacts
          WHERE ContactId = @ContactId;
        DELETE FROM ContactDevices 
          WHERE ContactId = @ContactId;
        """;

    public static string AddContact =>
        """
        INSERT INTO Contacts (FirstName, LastName, ContactTypeIdentifier)
        VALUES (@FirstName, @LastName, @ContactTypeIdentifier);
        SELECT last_insert_rowid();
        """;

    public static string AddDevice =>
        """
        INSERT INTO ContactDevices
        (
            ContactId,
            PhoneTypeIdentifier,
            PhoneNumber
        )
        VALUES
        (@ContactId, @PhoneTypeIdentifier, @PhoneNumber);
        SELECT last_insert_rowid();
        """;


}
