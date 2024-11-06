
using System.Data;
using NorthWindCategories.Classes;

namespace NorthWindCategories;

public partial class MainForm : Form
{
    private readonly BindingSource _bindingSource = new();
    public MainForm()
    {
        InitializeComponent();

        _bindingSource.DataSource = DataOperations.Read();
        dataGridView1.DataSource = _bindingSource;
    }

    /// <summary>
    /// Inserts a new row into the data source with the specified image file if added to database,
    /// otherwise show error.
    ///
    /// In this case the image file is "blub.png" is in the same folder as the executable but
    /// could be from an OpenFileDialog or any other source.
    /// </summary>
    private void InsertImageButton_Click(object sender, EventArgs e)
    {
        var text = Path.GetFileNameWithoutExtension("blub.png");
        var (success, exception) = DataOperations.Insert("blub.png");
        if (success)
        {
            var dt = (DataTable)_bindingSource.DataSource;
            var row = dt.NewRow();
            row["CategoryName"] = text;
            row["Description"] = text;
            row["Picture"] = File.ReadAllBytes("blub.png");
            dt.Rows.Add(row);
        }
        else
        {
            MessageBox.Show($"Failed\n{exception.Message}");
        }
    }
}
