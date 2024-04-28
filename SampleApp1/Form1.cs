using SampleApp1.Classes;
using SampleApp1.Models;
using SqlServerTableRulesApp.Extensions;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using SampleApp1.Validators;
using static SampleApp1.Classes.Dialogs;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SampleApp1;

public partial class Form1 : Form
{
    private SortableBindingList<Contact> _contactsBindingList;

    private BindingSource _contactsBindingSource = new();
    private BindingSource _contactTypeComboBoxBindingSource = new();

    public Form1()
    {
        InitializeComponent();

        contactsDataGridView.AutoGenerateColumns = false;

        Shown += Form1_Shown;

    }

    private void Form1_Shown(object? sender, EventArgs e)
    {
        CurrentContactButton.Enabled = false;

        try
        {
            // main data for the DataGridView
            _contactsBindingList = new SortableBindingList<Contact>(DapperOperations.Contacts());
            _contactsBindingSource.DataSource = _contactsBindingList;

            // data for the ContactTypeComboBoxColumn which is ContactType
            _contactTypeComboBoxBindingSource.DataSource = DapperOperations.ContactTypes();

            // Set up binding for Contact types to go with main data of contacts
            ContactTypeComboBoxColumn.DisplayMember = "ContactTitle";
            ContactTypeComboBoxColumn.ValueMember = "ContactTypeIdentifier";
            ContactTypeComboBoxColumn.DataPropertyName = "ContactTypeIdentifier";
            ContactTypeComboBoxColumn.DataSource = _contactTypeComboBoxBindingSource;
            ContactTypeComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            contactsDataGridView.DataSource = _contactsBindingSource;
            contactsDataGridView.ExpandColumns();

            CurrentContactButton.Enabled = true;

            // Hand errors with a message box
            contactsDataGridView.DataError += ContactsDataGridView_DataError;

            // Handle edits and saves back to database
            _contactsBindingSource.ListChanged += ContactsBindingSource_ListChanged;
            // Handle combobox changes and save to database
            contactsDataGridView.CellValueChanged += ContactsDataGridView_CellValueChanged;

            // commit change of DataGridView ComboBox
            contactsDataGridView.CurrentCellDirtyStateChanged += ContactsDataGridView_CurrentCellDirtyStateChanged;

            contactsDataGridView.KeyDown += ContactsDataGridView_KeyDown;

            BindingNavigator1.BindingSource = _contactsBindingSource;
            BindingNavigator1.AboutItemButton.Click += AboutItemButton_Click;
            BindingNavigator1.AddItemButton.Visible = false;
            BindingNavigator1.DeleteItemButton.Visible = false;

        }
        catch (Exception localException)
        {
            ExceptionMessageBox(localException);
        }
    }

    private void AboutItemButton_Click(object? sender, EventArgs e)
    {
        Information(this,"About","SQLite code sample");
    }

    /// <summary>
    /// Code to remove current contact
    /// </summary>
    private void ContactsDataGridView_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode != Keys.Delete) return;

        Contact current = _contactsBindingList[_contactsBindingSource.Position];

        if (Question(this, $"Remove {current.FirstName} {current.LastName}"))
        {
            if (DapperOperations.RemoveContact(current))
            {
                _contactsBindingSource.RemoveCurrent();
            }
            else
            {
                Information(this, "Removal failed", $"for {current.ContactId}");
                // log the error
            }
        }

    }

    private void ContactsDataGridView_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
    {
        // immediately commit the change in the dataGridView
        contactsDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
    }

    private void ContactsDataGridView_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
    {
        if (e is { ColumnIndex: 0, RowIndex: > -1 })
        {
            int comboboxSelectedValue = 0;

            if (contactsDataGridView.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewComboBoxColumn))
            {
                comboboxSelectedValue = (int)contactsDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            }

            Contact current = _contactsBindingList[e.RowIndex];
            current.ContactTypeIdentifier = comboboxSelectedValue;

            var success = DapperOperations.UpdateContact(current);
            if (success == false)
            {
                // TODO update failed which may mean the record was removed outside of this app.
            }
        }
    }

    /// <summary>
    /// Validate the current contact record, if valid update else inform user of validation errors
    /// </summary>
    private void ContactsBindingSource_ListChanged(object? sender, ListChangedEventArgs e)
    {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
            Contact current = _contactsBindingList[e.NewIndex];
            ContactValidator validator = new ContactValidator();
            var results = validator.Validate(current);

            if (results.IsValid == false)
            {
                StringBuilder builder = new();
                foreach (var failure in results.Errors)
                {
                    builder.AppendLine(failure.ErrorMessage);
                }

                Information(this, "Failed to validate", builder.ToString());

            }
            else
            {
                var success = DapperOperations.UpdateContact(current);
            }

        }
        else if (e.ListChangedType == ListChangedType.ItemDeleted)
        {
            // TODO
        }
        else if (e.ListChangedType == ListChangedType.ItemAdded)
        {
            // TODO
        }
    }

    private void ContactsDataGridView_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        Information(this, "Error", e.Exception?.Message!);
    }

    private void CurrentContactButton_Click(object sender, EventArgs e)
    {

        Contact current = _contactsBindingList[_contactsBindingSource.Position];

        Information(this,
            $"Primary key {current.ContactId}",
            $"ContactTypeIdentifier {current.ContactTypeIdentifier}" +
            $"\nPhoneTypeIdenitfier {current.PhoneTypeIdenitfier}");
    }

    /// <summary>
    /// Add a new contact using Bogus to generate first and last name
    /// and contact type.
    /// </summary>
    private void MockAddContactButton_Click(object sender, EventArgs e)
    {

        var fake = BogusOperations.GetContactDetailsForAddingNewRecord();

        Contact contact = new()
        {
            
            ContactTypeIdentifier = fake.ContactTypeIdentifier,
            FirstName = fake.FirstName,
            LastName = fake.LastName,
            PhoneTypeIdenitfier = 3
        };

        ContactDevices device = new()
        {
            PhoneTypeIdentifier = contact.PhoneTypeIdenitfier,
            PhoneNumber = fake.PhoneNumber
        };

        DapperOperations.AddContact(contact, device);

        _contactsBindingList.Add(contact);

        // force sort else new contact will be at the end of the DataGridView
        _contactsBindingSource.Sort = "LastName";
        var index = _contactsBindingSource.List.IndexOf(contact);
        _contactsBindingSource.Position = index;
    }
}
