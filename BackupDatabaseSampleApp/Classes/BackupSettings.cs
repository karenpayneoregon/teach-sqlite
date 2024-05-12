using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;

namespace BackupDatabaseSampleApp.Classes;

public sealed class BackupSettings
{
    private static readonly Lazy<BackupSettings> Lazy = new(() => new BackupSettings());
    public static BackupSettings Instance => Lazy.Value;
    public string BaseFileName { get; set; }
    public string BaseExtensions { get; set; }
    public string ConnectionString { get; set; }
    private BackupSettings()
    {
        var _configuration = Configuration.JsonRoot();
        var appSettings = _configuration.GetRequiredSection("Settings").Get<AppSettings>();
        BaseFileName = appSettings.BaseFileName;
        BaseExtensions = appSettings.BaseExtensions;
        ConnectionString = appSettings.ConnectionString;
    }
}