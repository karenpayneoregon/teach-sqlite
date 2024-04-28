namespace CreateNewDatabaseAoo.LanguageExtensions;
public static class GeneralExtensions
{
    public static int GetId(this object sender) 
        => (int)(long)sender;
}

