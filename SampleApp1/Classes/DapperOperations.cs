using System.Data.SQLite;
using Dapper;
using SampleApp1.Models;

namespace SampleApp1.Classes;
internal class DapperOperations
{
    private static string _name = "NorthWindContacts.db";
    private static string ConnectionString()
        => $"Data Source={_name}";

    public static List<Contact> Contacts()
    {
        using var cn = new SQLiteConnection(ConnectionString());
        return cn.Query<Contact>(SqlStatements.GetContactsWithOfficePhone).ToList();
    }

    public static List<ContactType> ContactTypes()
    {
        using var cn = new SQLiteConnection(ConnectionString());
        return cn.Query<ContactType>(SqlStatements.ContactTypes).ToList();
    }

    /// <summary>
    /// Update a contact if exists in the database
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public static bool UpdateContact(Contact contact)
    {
        using var cn = new SQLiteConnection(ConnectionString());

        var result1 = cn.Execute(SqlStatements.UpdateContact, contact) > 0;
        var result2 = cn.Execute(SqlStatements.UpdateDevice, 
            new
            {
                PhoneTypeIdentifier = contact.PhoneTypeIdenitfier,
                PhoneNumber = contact.PhoneNumber,
                ContactId = contact.ContactId,
                Id = contact.Id,
                ContactTypeIdentifier = contact.ContactTypeIdentifier

            }) > 0;

        return result1 && result2;
    }

    /// <summary>
    /// Remove a contact if it exists
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    public static bool RemoveContact(Contact contact)
    {
        using var cn = new SQLiteConnection(ConnectionString());
        return cn.Execute(SqlStatements.RemoveContact, 
            new
            {
                ContactId = contact.ContactId,
            }) > 0;
    }

    /// <summary>
    /// Add a new contact
    /// </summary>
    /// <param name="contact"></param>
    /// <param name="devices"></param>
    public static void AddContact(Contact contact, ContactDevices devices)
    {
        using SQLiteConnection cn = new(ConnectionString());

        contact.ContactId = cn.ExecuteScalar(SqlStatements.AddContact, contact)!.GetId();
        devices.ContactId = contact.ContactId;
        devices.id = cn.ExecuteScalar(SqlStatements.AddDevice, devices)!.GetId();
        contact.PhoneNumber = devices.PhoneNumber;
        contact.PhoneTypeIdenitfier = devices.PhoneTypeIdentifier;
        
    }

    public static async Task AddContactAsync(Contact contact, ContactDevices devices)
    {
        await using SQLiteConnection cn = new(ConnectionString());

        contact.ContactId = (await cn.ExecuteScalarAsync(SqlStatements.AddContact, contact))!.GetId();
        devices.ContactId = contact.ContactId;
        devices.id = (await cn.ExecuteScalarAsync(SqlStatements.AddDevice, devices))!.GetId();
        contact.PhoneNumber = devices.PhoneNumber;
        contact.PhoneTypeIdenitfier = devices.PhoneTypeIdentifier;

    }

    public static Contact GetContactByLastName(string lastName)
    {
        using var cn = new SQLiteConnection(ConnectionString());
        return cn.QueryFirstOrDefault<Contact>(SqlStatements.ContactByLastName(false), new { LastName = lastName })!;
    }
}
