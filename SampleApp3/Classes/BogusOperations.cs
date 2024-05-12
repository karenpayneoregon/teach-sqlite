using SampleApp3.Models;

namespace SampleApp3.Classes;
internal class BogusOperations
{
    /// <summary>
    /// Create a new Contact object with random data
    /// </summary>
    public static Contact GetContactDetailsForAddingNewRecord()
    {
        var faker = new Bogus.Faker<Contact>()
            .RuleFor(c => c.ContactTitle, f => f.Name.JobTitle())
            .RuleFor(c => c.ContactTypeIdentifier, f => f.Random.Number(1, 13))
            // PhoneNumberFormat formats a phone number according to the locale
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumberFormat())
            .RuleFor(c => c.FirstName, f => f.Name.FirstName())
            .RuleFor(c => c.LastName, f => f.Name.LastName());

        return faker.Generate();
    }
}
