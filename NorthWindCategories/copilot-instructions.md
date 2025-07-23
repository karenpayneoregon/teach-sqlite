# Copilot Instructions for NorthWindCategories

## Project Overview
- This is a WinForms/.NET 8.0 (C#) application for reading and inserting images in the `Categories` table of a SQLite database (`NorthWind2024.db`).
- The main UI logic is in `MainForm.cs`.
- Data access logic is in `Classes/DataOperations.cs` using Dapper and `System.Data.SQLite`.
- Configuration and service setup are in `Classes/Configuration/`.

## Key Patterns & Conventions
- **Data Access:**
  - Use static methods in `DataOperations` for database operations.
  - Dapper is used for executing SQL and mapping results.
  - Images are stored as BLOBs in the `Picture` column.
- **Error Handling:**
  - Data operations return tuples with success flags and exceptions (see `InsertRecord`).
  - For real applications, replace inline exception handling with SeriLog or similar.
- **File/Resource Management:**
  - Image files are read as byte arrays before insertion.
  - Use `Path.GetFileName` for category names/descriptions when inserting images.
- **Configuration:**
  - Connection strings and settings are managed in `Classes/Configuration/` and `appsettings.json`.

## Developer Workflows
- **Build:**
  - Standard .NET build: `dotnet build` from the project root.
- **Run:**
  - Run with `dotnet run` or launch via Visual Studio.
- **Debug:**
  - Use Visual Studio's debugger for WinForms.
- **Database:**
  - The SQLite database file is `NorthWind2024.db` (copied to `bin/Debug/net8.0-windows/` on build).
  - Schema: focus on the `Categories` table with columns: `CategoryId`, `CategoryName`, `Description`, `Picture`.

## External Dependencies
- Dapper
- System.Data.SQLite
- Microsoft.Extensions.Configuration (for config management)

## Examples
- To read all categories: call `DataOperations.Read()` (returns a `DataTable`).
- To insert an image: call `DataOperations.InsertRecord(fileName)` with the image path.

## File/Directory Guide
- `MainForm.cs`: UI logic
- `Classes/DataOperations.cs`: Data access
- `Classes/Configuration/`: App configuration/services
- `Models/Configuration/`: Strongly-typed config models
- `appsettings.json`: App settings

## Notes
- No tests or test projects are present.
- Extend data operations by following the static method pattern in `DataOperations`.
- For new features, keep data access logic in `Classes/DataOperations.cs` and configuration in `Classes/Configuration/`.
