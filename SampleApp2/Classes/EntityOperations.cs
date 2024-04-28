using Microsoft.EntityFrameworkCore;
using SampleApp2.Data;
using SampleApp2.Models;

namespace SampleApp2.Classes;
internal class EntityOperations
{
    public static async Task<List<ContactContainer>> AllContact()
    {
        await using var context = new Context();
        var contactNames = await context.Contacts
            .Include(c => c.ContactTypeIdentifierNavigation)
            .Select(c => new ContactContainer(
                c.ContactId,
                c.FirstName,
                c.LastName,
                c.ContactTypeIdentifierNavigation.ContactTitle,
                c.ContactTypeIdentifier))
            .ToListAsync();

        return contactNames;
    }

    public static Contacts? SingleContact(int contactId)
    {
        using var context = new Context();
        return context.Contacts.FirstOrDefault(x => x.ContactId == contactId);
    }

    public static async Task<List<ContactType>> ContactTypes()
    {
        await using var context = new Context();
        return await context.ContactType.ToListAsync();
    }

    public static void UpdateContact(ContactContainer contact)
    {
        using var context = new Context();
        var contacts = context.Contacts.Find(contact.ContactId);

        if (contacts is null) return;

        contacts.FirstName = contact.FirstName;
        contacts.LastName = contact.LastName;
        contacts.ContactTypeIdentifier = contact.ContactTypeIdentifier;

        ContactMinimal? dapper = DapperOperations.Contacts(contact.ContactId);
        var current = new ContactMinimal()
        {
            ContactId = contact.ContactId, 
            FirstName = contact.FirstName, 
            LastName = contact.LastName, 
            ContactTypeIdentifier = contact.ContactTypeIdentifier
        };

        if (dapper.Equals(current) == false)
        {
            context.Contacts.Add(contacts).State = EntityState.Modified;
            context.SaveChanges();            
        }

    }

}
