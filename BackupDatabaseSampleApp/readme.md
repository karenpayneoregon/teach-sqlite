# About

An example to show how to backup a SQLite database.

On first build a folder named Backups is creating from the following in this project file.

```xml
<Target Name="MakeTempFolder" AfterTargets="Build">
   <MakeDir Directories="$(OutDir)Backups" />
</Target>
```

Next top 15 contacts are presented followed by backing up the database.

- `AppSettings` is a container for values read from appsettings.json
    - BaseFileName for backups
    - BaseExtension of BaseFileName
    - ConnectionString, connection string for main datase
- `BackupOperations` is where the database backup is performed
- `BackupSettings` is a Singleton to provide access to `AppSettings` values
- `GenerateFiles` is responsible for generating file names for backup operations

## Generate file names

Its important to understand why the base file name and base extension are dynamic, read from appsettings.json is so the class can be used in other projects.

