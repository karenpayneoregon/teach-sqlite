using CreateNewDatabaseAoo.Interfaces;

namespace CreateNewDatabaseAoo.DapperModels;

/// <summary>
/// For Dapper work
/// </summary>
public class Person : IPerson
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public DateOnly BirthDate { get; set; }
    public int Pin { get; set; }
}