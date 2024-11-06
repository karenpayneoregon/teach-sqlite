using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;

namespace BackupLibrary.Classes;

public sealed class BackupSettings
{
    private static readonly Lazy<BackupSettings> Lazy = new(() => new BackupSettings());
    public static BackupSettings Instance => Lazy.Value;
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
    private BackupSettings()
    {
        var configuration = Configuration.JsonRoot();
        var appSettings = configuration.GetRequiredSection(AppSettings.Location).Get<AppSettings>();
        BaseFileName = appSettings!.BaseFileName;
        BaseExtensions = appSettings.BaseExtensions;
        ConnectionString = appSettings.ConnectionString;

    }

    public override string ToString() => BaseFileName;

}