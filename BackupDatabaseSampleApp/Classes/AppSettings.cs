namespace BackupDatabaseSampleApp.Classes;

/// <summary>
/// Settings for generating files read from appsettings.json
/// </summary>
public class AppSettings
{
    public string BaseFileName { get; set; }
    public string BaseExtensions { get; set; }
    public string ConnectionString { get; set; }
}