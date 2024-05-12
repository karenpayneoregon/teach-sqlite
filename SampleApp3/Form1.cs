using BindingListViewCore;
using SampleApp3.Classes;
using SampleApp3.Models;
using Serilog;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace SampleApp3;

public partial class Form1 : Form
{
    // custom binding list in class project BindingListViewCore
    private AggregateBindingListView<Contact> _contactsBindingList;

    private BindingSource _contactsBindingSource = new();
    private BindingSource _contactTypeComboBoxBindingSource = new();

    public Form1()
    {
        InitializeComponent();

        Shown += Form1_Shown;

        contactsDataGridView.AutoGenerateColumns = false;
        contactsDataGridView.DataError += ContactsDataGridView_DataError;
    }

    private void ContactsDataGridView_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        Log.Information("{P1} {P2}", contactsDataGridView, e.Exception!.Message);
    }

    private void Form1_Shown(object? sender, EventArgs e)
    {

        _contactsBindingList = new AggregateBindingListView<Contact>();
        _contactsBindingList.SourceLists.Add(DapperOperations.Contacts());
        _contactsBindingSource.DataSource = _contactsBindingList;

        _contactTypeComboBoxBindingSource.DataSource = DapperOperations.ContactTypes();

        ContactTypeComboBoxColumn.DisplayMember = "ContactTitle";
        ContactTypeComboBoxColumn.ValueMember = "ContactTypeIdentifier";
        ContactTypeComboBoxColumn.DataPropertyName = "ContactTypeIdentifier";
        ContactTypeComboBoxColumn.DataSource = _contactTypeComboBoxBindingSource;
        ContactTypeComboBoxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;


        contactsDataGridView.DataSource = _contactsBindingSource;

        contactsDataGridView.ExpandColumns();

        firstNameTextBox.TextChanged += FirstNameTextBox_TextChanged;
    }

    /// <summary>
    /// Perform case-insensitive search on first name
    /// </summary>
    private void FirstNameTextBox_TextChanged(object? sender, EventArgs e)
    {
        _contactsBindingList.ApplyFilter(contact => contact.FirstName.ToLower().StartsWith(
                firstNameTextBox.ToLower()));
    }

    private void CurrentContactButton_Click(object sender, EventArgs e)
    {
        if (_contactsBindingSource.Current is null) return;
        
        var current = _contactsBindingList[_contactsBindingSource.Position].Object;

        Dialogs.Information(this, "Current contact", current.ToString());

    }
}
