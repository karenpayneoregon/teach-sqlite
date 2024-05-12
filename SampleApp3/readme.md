# About

An example of BindingListViewCore.AggregateBindingListView&lt;T>, in this case Contacts in a DataGridView with a DataGridViewComboBox column with Contact types.

- In Form Shown event
    - AggregateBindingListView&lt;Contact> is loaded from a Dapper operation
    - A BindingSource uses the above as it's DataSource which in turn is used as the DataSource of a DataGridView.
    - Next a DataGridViewComboBox is setup with a Dapper Operation and properties set to present in the DataGridView.
    - `firstNameTextBox` is setup to provide incremental starts with filtering

## Important

The DataGridViewComboBox can not be sorted. SortMode is set to NotSortable.

## Accessing rows

To get at the current item, use Position property of the BindingSource then to get to the object, in this case Contact access .Object property as shown below/

```csharp
var current = _contactsBindingList[_contactsBindingSource.Position].Object;
```

## Filtering

It is fairly intutitive, for instance as per below we want to perform a starts with on the string property FirstName. Keeping it simple, compare lower-cased values for FirstName to the lower-cased value in the TextBox. If the TextBox.Text is empty, the filter is removed.

```csharp
private void FirstNameTextBox_TextChanged(object? sender, EventArgs e)
{
    _contactsBindingList.ApplyFilter(contact => contact.FirstName.ToLower().StartsWith(
            firstNameTextBox.ToLower()));
}
```

## Why use this component?

Because like others out there, this one makes it easy to perform filtering.