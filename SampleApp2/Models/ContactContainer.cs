using System.ComponentModel;
using System.Runtime.CompilerServices;
#pragma warning disable CS8612 // Nullability of reference types in type doesn't match implicitly implemented member.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SampleApp2.Models;

/// <summary>
/// Model for displaying contacts
/// </summary>
public class ContactContainer : INotifyPropertyChanged
{
    private string _firstName;
    private string _lastName;
    public int ContactId { get; }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string LastName
    {
        get => _lastName;
        set
        {
            if (value == _lastName) return;
            _lastName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(FullName));
        }
    }

    public string ContactTitle { get; set; }
    public int ContactTypeIdentifier { get; set; }
    public string FullName => $"{FirstName} {LastName}";

    public ContactContainer(int id, string firstName, string lastName, string title, int contactTypeIdentifier)
    {
        ContactId = id;
        FirstName = firstName;
        LastName = lastName;
        ContactTitle = title;
        ContactTypeIdentifier = contactTypeIdentifier;
    }

    public override string ToString() => FullName;
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}