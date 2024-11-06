namespace BackupDatabaseSampleApp.Classes;

/// <summary>
/// Settings for generating files read from appsettings.json see <see cref="BackupSettings"/> for retrieval of settings.
/// </summary>
public class AppSettings
{
    /// <summary>
    /// Location in appsettings.json
    /// </summary>
    public const string Location = "Settings";
    /// <summary>
    /// Base file name for SQLite database
    /// </summary>
    public string BaseFileName { get; set; }
    /// <summary>
    /// Extension for SQLite database e.g. .db
    /// </summary>
    public string BaseExtensions { get; set; }
    /// <summary>
    /// Connection string for SQLite database in this case NorthWindContacts.db
    /// </summary>
    public string ConnectionString { get; set; }
}