#nullable disable
namespace SampleApp3.Models;

public class ContactDevices
{
    public int id { get; set; }
    public int? ContactId { get; set; }
    public int PhoneTypeIdentifier { get; set; }
    public string PhoneNumber { get; set; }
}