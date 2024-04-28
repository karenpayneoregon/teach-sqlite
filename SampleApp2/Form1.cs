using System.ComponentModel;
using FluentValidation.Results;
using SampleApp1.Validators;
using SampleApp2.Classes;
using SampleApp2.Models;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SampleApp2;

/// <summary>
///  Notes
///  * If validation fails, the data is not saved to the database without alerting the user
///  * On save, if the data is the same as the database, no update is performed
///  * <see cref="ContactMinimal"/> implements <see cref="IEquatable{T}"/> to validate <see cref="Contacts"/>
///    againsts the database and local data.
/// </summary>
public partial class Form1 : Form
{
    private BindingList<ContactContainer> _contactsBindingList;
    private BindingSource _contactsBindingSource = new();

    private BindingList<ContactType> _contactTypesBindingList;
    public Form1()
    {
        InitializeComponent();

        Shown += Form1_Shown;
    }

    private async void Form1_Shown(object? sender, EventArgs e)
    {

        await ReadDataFromDatabase();

        ContactNamesListBox.DataSource = _contactsBindingSource;
        ContactNamesListBox.SelectedIndexChanged += ContactNamesListBox_SelectedIndexChanged;
        ContactTitleComboBox.DataSource = _contactTypesBindingList;

        SelectionChanged();
        SetupDataBindings();

        _contactsBindingList.ListChanged += _contactsBindingList_ListChanged;
        ContactTitleComboBox.SelectedIndexChanged += ContactTitleComboBox_SelectedIndexChanged;

    }

    private async Task ReadDataFromDatabase()
    {
        _contactsBindingList = new BindingList<ContactContainer>(await EntityOperations.AllContact());
        _contactsBindingSource.DataSource = _contactsBindingList;
        _contactTypesBindingList = new BindingList<ContactType>(await EntityOperations.ContactTypes());
    }
    private void SetupDataBindings()
    {
        ContactIdTextBox.DataBindings.Add(
            "Text", 
            _contactsBindingSource, 
            "ContactId");

        FirstNameTextBox.DataBindings.Add(
            "Text", 
            _contactsBindingSource, 
            "FirstName", 
            false, 
            DataSourceUpdateMode.OnPropertyChanged);

        LastNameTextBox.DataBindings.Add(
            "Text", 
            _contactsBindingSource, 
            "LastName", 
            false, 
            DataSourceUpdateMode.OnPropertyChanged);
    }

    private void ContactTitleComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {

        ContactContainer contactContainer = _contactsBindingList[_contactsBindingSource.Position];

        ContactType contactType = (ContactType)ContactTitleComboBox.SelectedItem!;
        contactContainer.ContactTypeIdentifier = contactType.ContactTypeIdentifier;

        ContactContainerValidator validator = new();
        ValidationResult? result = validator.Validate(contactContainer);

        if (result.IsValid)
        {
            EntityOperations.UpdateContact(contactContainer);
        }

    }

    private void _contactsBindingList_ListChanged(object? sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            ContactContainer contact = _contactsBindingList[e.NewIndex];

            ContactContainerValidator validator = new();
            ValidationResult? result = validator.Validate(contact);
            if (result.IsValid)
            {
                EntityOperations.UpdateContact(contact);
            }
        }
    }

    private void ContactNamesListBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        SelectionChanged();
    }

    private void SelectionChanged()
    {
        ContactContainer contactContainer = _contactsBindingList[_contactsBindingSource.Position];

        if (contactContainer is not null)
        {
            var contactType = _contactTypesBindingList.FirstOrDefault(
                x => x.ContactTypeIdentifier == contactContainer.ContactTypeIdentifier);

            ContactTitleComboBox.SelectedItem = contactType;
        }
    }
}