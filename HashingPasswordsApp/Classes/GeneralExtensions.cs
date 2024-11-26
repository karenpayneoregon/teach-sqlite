namespace HashingPasswordsApp.Classes;
public static class GeneralExtensions
{
    /// <summary>
    /// Used to get a new primary key after adding a new record.
    /// </summary>
    /// <param name="sender"></param>
    public static int GetId(this object sender) 
        => (int)(long)sender;
}

