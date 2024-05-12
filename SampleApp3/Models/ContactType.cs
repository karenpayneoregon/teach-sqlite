#nullable disable
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp3.Models;

public class ContactType : INotifyPropertyChanged
{
    private string _contactTitle;
    private int _contactTypeIdentifier;

    public int ContactTypeIdentifier
    {
        get => _contactTypeIdentifier;
        set
        {
            if (value == _contactTypeIdentifier) return;
            _contactTypeIdentifier = value;
            OnPropertyChanged();
        }
    }

    public string ContactTitle
    {
        get => _contactTitle;
        set
        {
            if (value == _contactTitle) return;
            _contactTitle = value;
            OnPropertyChanged();
        }
    }

    public override string ToString() => ContactTitle;
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}