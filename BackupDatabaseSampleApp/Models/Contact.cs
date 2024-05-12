#nullable disable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BackupDatabaseSampleApp.Models;

public class Contact : INotifyPropertyChanged
{
    private string _firstName;
    private string _lastName;
    private string _phoneNumber;
    public int ContactId { get; set; }
    public string ContactTitle { get; set; }

    public string FirstName
    {
        get => _firstName;
        set
        {
            if (value == _firstName) return;
            _firstName = value;
            OnPropertyChanged();
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
        }
    }

    public int ContactTypeIdentifier { get; set; }
    public string PhoneTypeDescription { get; set; }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (value == _phoneNumber) return;
            _phoneNumber = value;
            OnPropertyChanged();
        }
    }

    public int PhoneTypeIdenitfier { get; set; }

    /// <summary>
    /// Device id
    /// </summary>
    public int Id { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

}