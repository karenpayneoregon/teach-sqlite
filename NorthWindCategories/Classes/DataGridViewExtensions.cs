namespace NorthWindCategories.Classes;

public static class DataGridViewExtensions
{
    /// <summary>
    /// Expands the columns of the specified <see cref="DataGridView"/> to fit their content.
    /// </summary>
    /// <param name="source">The <see cref="DataGridView"/> instance whose columns are to be expanded.</param>
    /// <param name="sizable">
    /// A boolean value indicating whether the columns should remain resizable after expansion. 
    /// If <c>true</c>, the columns will be resizable; otherwise, they will have a fixed size.
    /// </param>
    public static void ExpandColumns(this DataGridView source, bool sizable = false)
    {

        source.FixHeaders();

        foreach (DataGridViewColumn col in source.Columns)
        {
            if (col.ValueType.Name != "ICollection`1")
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        if (!sizable) return;

        for (int index = 0; index <= source.Columns.Count - 1; index++)
        {
            int columnWidth = source.Columns[index].Width;

            source.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            source.Columns[index].Width = columnWidth;
        }
    }

    /// <summary>
    /// Fixes the headers of the <see cref="DataGridView"/> columns by splitting property names into separate words.
    /// </summary>
    /// <param name="source">The <see cref="DataGridView"/> instance whose column headers are to be fixed.</param>
    public static void FixHeaders(this DataGridView source)
    {
        for (var index = 0; index < source.Columns.Count; index++)
        {
            source.Columns[index].HeaderText = source.Columns[index].HeaderText.SplitCase();
        }
    }
}
