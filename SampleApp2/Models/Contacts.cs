﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleApp2.Models;

public partial class Contacts : INotifyPropertyChanged
{
    private string _firstName;
    private string _lastName;
    public int ContactId { get; set; }

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

    public override string ToString() => $"{FirstName} {LastName}";


    public int ContactTypeIdentifier { get; set; }

    public virtual ICollection<ContactDevices> ContactDevices { get; set; } = new List<ContactDevices>();

    public virtual ContactType ContactTypeIdentifierNavigation { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}