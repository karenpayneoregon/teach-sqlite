#nullable disable
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BackupDatabaseSampleApp.Models;

public class ContactType : INotifyPropertyChanged
{
    private string _contactTitle;
    private int _contactTypeIdentifier;

    public int ContactTypeIdentifier
    {
        get => _contactTypeIdentifier;
        set => SetField(ref _contactTypeIdentifier, value);
    }

    public string ContactTitle
    {
        get => _contactTitle;
        set => SetField(ref _contactTitle, value);
    }

    public override string ToString() => ContactTitle;
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