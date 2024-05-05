using System.Data.SQLite;
using CreateNewDatabaseApp.DapperModels;
using CreateNewDatabaseApp.Handlers;
using CreateNewDatabaseApp.LanguageExtensions;
using CreateNewDatabaseApp.Validators;
using Dapper;
using FluentValidation.Results;

namespace CreateNewDatabaseApp.Classes;

/// <summary>
/// Code creates a new database on each run.
/// Adds and displays records
/// </summary>
public class DapperOperations
{
    private static string _name = "ExampleDapper1.db";
    private static string ConnectionString()
        => $"Data Source={_name}";

    public static void CreateDatabaseAddDataShowData()
    {

        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        

        /*
         * Allows the database to be recreated each time the application is run
         * which allows a developer to experiment with the database structure
         */
        if (File.Exists(_name))
        {
            File.Delete(_name);
        }

        using SQLiteConnection cn = new(ConnectionString());
        
        /*
         * 1. Once Dapper opens the connection the database is created
         * 2. The Person table is created with the following columns: Id, FirstName, LastName, FullName, Pin
         *    The FullName column is a virtual column that concatenates the FirstName and LastName columns
         * 4. Indexes are created for the FirstName, LastName, and Pin columns
         */

        cn.Execute(
            """
            CREATE TABLE Person (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT NOT NULL,
                LastName TEXT NOT NULL,
                FullName STRING AS (coalesce(trim(FirstName), '') || ' ' || coalesce(trim(LastName), '')) VIRTUAL,
                Pin INTEGER,
                BirthDate [date] NOT NULL
            );
            CREATE INDEX first_name_person1_idx ON Person (FirstName);
            CREATE INDEX last_name_person1_idx ON Person (LastName);
            CREATE INDEX pin_person1_idx ON Person (PIN);
            """
        );

        AnsiConsole.MarkupLine("[green]Database and Table created successfully[/]");
        AddRecords();

        Person person = new()
        {
            FirstName = "Karen",
            LastName = "Payne",
            Pin = 5555,
            BirthDate = new DateOnly(1956, 9, 24)
        };

        var (success, errorList) = AddRecordGetPrimaryKey(person);

        AnsiConsole.MarkupLine("[green]Records added successfully[/]");
        ViewRecords();
        ViewWhereCaseInsensitiveWithDapper();
        cn.Close();
    }

    private static void AddRecords()
    {
        using SQLiteConnection cn = new(ConnectionString());

        cn.Execute(
        """
         INSERT INTO Person (FirstName,LastName,Pin, BirthDate) VALUES ('John','Doe',4444, '1900-11-14');
         INSERT INTO Person (FirstName,LastName,Pin, BirthDate) VALUES ('Jane','Doe',5678, '1988-01-01');
         INSERT INTO Person (FirstName,LastName,Pin, BirthDate) VALUES ('John','Smith',9876, '1911-11-14');
         INSERT INTO Person (FirstName,LastName,Pin, BirthDate) VALUES ('Jane','Smith',5432, '1912-11-14');
         """);
    }

    /// <summary>
    /// First validate the person object, if valid, add record
    /// </summary>
    /// <param name="person">Valid person</param>
    /// <remarks>
    /// Validation should actually be done by the caller of this method
    /// </remarks>
    private static (bool success, List<ValidationFailure> errorList) AddRecordGetPrimaryKey(Person person)
    {
        PersonValidator validator = new();
        var validate = validator.Validate(person);
        
        if (!validate.IsValid)
        {
            return (false, validate.Errors);
        }

        using SQLiteConnection cn = new(ConnectionString());

        person.Id = cn.ExecuteScalar(
            """
            INSERT INTO Person (FirstName,LastName,Pin, BirthDate) 
            VALUES (@FirstName,@LastName,@Pin, @BirthDate);
            SELECT last_insert_rowid();
            """, new
            {
                person.FirstName,
                person.LastName,
                person.Pin,
                person.BirthDate
            }).GetId();
        
        return (true, null);

    }

    public static void ViewRecords()
    {
        ViewWithDapper();
        //ViewThePainfulWay();
    }

    private static void ViewWithDapper()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        using SQLiteConnection cn = new(ConnectionString());

        List<Person> data = cn.Query<Person>(
                """
                SELECT Id,
                     FirstName,
                     LastName,
                     FullName,
                     Pin,
                     BirthDate
                FROM Person;
                """)
            .AsList();



        var dump = ObjectDumper.Dump(data);
        Console.WriteLine(dump);
    }
    /// <summary>
    /// This version was used because the DateOnly mapper was not being
    /// called when using a newer version of Dapper and reported it as a bug.
    /// </summary>
    private static void ViewWithDapperWorkAround()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        using var cn = new SQLiteConnection(ConnectionString());
        
        List<dynamic> data = cn.Query(
                """
                SELECT Id,
                     FirstName,
                     LastName,
                     FullName,
                     Pin,
                     BirthDate
                FROM Person;
                """)
            .AsList();

        List<Person> peopleList = [];

        for (int index = 0; index < data.Count; index++)
        {
            var person = new Person()
            {
                Id = (int)data[index].Id,
                FirstName = data[index].FirstName,
                LastName = data[index].LastName,
                FullName = data[index].FullName,
                Pin = (int)data[index].Pin,
                BirthDate = DateOnly.FromDateTime(data[index].BirthDate)
            };

            peopleList.Add(person);

        }

        var dump = ObjectDumper.Dump(peopleList);
        Console.WriteLine(dump);
    }

    private static void ViewWhereCaseInsensitiveWithDapper(string firstName = "john")
    {
        using SQLiteConnection cn = new(ConnectionString());

        List<Person> peopleList = cn.Query<Person>(
                """
                SELECT Id,
                     FirstName,
                     LastName,
                     FullName,
                     Pin,
                     BirthDate
                FROM Person
                WHERE FirstName = @FirstName COLLATE NOCASE;
                """, new { FirstName = firstName}
               )
            .AsList();


        if (peopleList.Count > 0)
        {
            AnsiConsole.MarkupLine("[green]John search case insensitive[/]");
            var dump = ObjectDumper.Dump(peopleList);
            Console.WriteLine(dump);
        }

    }
    private static void ViewThePainfulWay()
    {
        using SQLiteConnection cn = new(ConnectionString());
        using SQLiteCommand cmd = new()
        {
            Connection = cn,
            CommandText =
                """
                SELECT Id,
                     FirstName,
                     LastName,
                     FullName,
                     Pin,
                     BirthDate
                FROM Person;
                """
        };

        cn.Open();

        List<Person> people = [];
        var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            people.Add(new Person()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                FullName = reader.GetString(3),
                Pin = reader.GetInt32(4),
                BirthDate = DateOnly.Parse(reader.GetString(5))
            });
        }

        Console.WriteLine(ObjectDumper.Dump(people));
    }
}