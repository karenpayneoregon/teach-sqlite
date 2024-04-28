#nullable disable
namespace SampleApp2.Models;

public class ContactMinimal : IEquatable<ContactMinimal>
{
    public int ContactId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int ContactTypeIdentifier { get; set; }

    public bool Equals(ContactMinimal other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return FirstName == other.FirstName && LastName == other.LastName && ContactTypeIdentifier == other.ContactTypeIdentifier;
    }

    public override bool Equals(object obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((ContactMinimal)obj);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (FirstName != null ? FirstName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ (LastName != null ? LastName.GetHashCode() : 0);
            hashCode = (hashCode * 397) ^ ContactTypeIdentifier;
            return hashCode;
        }
    }
}