namespace SampleApp3.Classes;
public static class GeneralExtensions
{
    /// <summary>
    /// Used to get a new primary key after adding a new record.
    /// </summary>
    /// <param name="sender"></param>
    public static int GetId(this object sender) 
        => (int)(long)sender;

    /// <summary>
    /// Lower case Text property of TextBox
    /// </summary>
    /// <param name="sender">TextBox</param>
    /// <returns>Lower cased text</returns>
    public static string ToLower(this TextBox sender) => sender.Text.ToLower();
}

