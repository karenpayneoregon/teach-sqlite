using System.Data;

namespace NorthWindCategories.Classes;

public static class BindingSourceExtensions
{
    /// <summary>
    /// Retrieves the <see cref="DataTable"/> that serves as the data source for the specified <see cref="BindingSource"/>.
    /// </summary>
    /// <param name="bindingSource">The <see cref="BindingSource"/> whose data source is to be retrieved.</param>
    /// <returns>The <see cref="DataTable"/> serving as the data source of the provided <see cref="BindingSource"/>.</returns>
    /// <exception cref="InvalidCastException">Thrown if the data source of the <see cref="BindingSource"/> is not a <see cref="DataTable"/>.</exception>
    public static DataTable DataTable(this BindingSource bindingSource) 
        => (DataTable)bindingSource.DataSource;

    /// <summary>
    /// Retrieves the current <see cref="DataRow"/> from the specified <see cref="BindingSource"/>.
    /// </summary>
    /// <param name="bindingSource">The <see cref="BindingSource"/> from which to retrieve the current <see cref="DataRow"/>.</param>
    /// <returns>The current <see cref="DataRow"/> associated with the provided <see cref="BindingSource"/>.</returns>
    /// <exception cref="InvalidCastException">Thrown if the current item of the <see cref="BindingSource"/> is not a <see cref="DataRowView"/>.</exception>
    public static DataRow CurrentRow(this BindingSource bindingSource) 
        => ((DataRowView)bindingSource.Current).Row;
}