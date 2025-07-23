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
        set => SetField(ref _firstName, value);
    }

    public string LastName
    {
        get => _lastName;
        set => SetField(ref _lastName, value);
    }

    public int ContactTypeIdentifier { get; set; }
    public string PhoneTypeDescription { get; set; }

    public string PhoneNumber
    {
        get => _phoneNumber;
        set => SetField(ref _phoneNumber, value);
    }

    public int PhoneTypeIdenitfier { get; set; }

    /// <summary>
    /// Device id
    /// </summary>
    public int Id { get; set; }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    /// <summary>
    /// Sets the field to the specified value and raises the <see cref="PropertyChanged"/> event if the value has changed.
    /// </summary>
    /// <typeparam name="T">The type of the field.</typeparam>
    /// <param name="field">The field to set.</param>
    /// <param name="value">The value to set the field to.</param>
    /// <param name="propertyName">The name of the property. This is optional and will be automatically provided by the compiler.</param>
    /// <returns><c>true</c> if the field was changed; otherwise, <c>false</c>.</returns>
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

}