using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreateNewDatabaseAoo.Data;
using Microsoft.EntityFrameworkCore;

namespace CreateNewDatabaseAoo.Classes;
internal class EntityOperations
{
    public static void CreateDatabaseAddDataShowData()
    {
        using var context = new Context();
        
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        AnsiConsole.MarkupLine("[yellow]EF Core[/] [green]Database and Table created successfully[/]");

        var people = new List<Models.Person>
        {
            new() { FirstName = "John", LastName = "Doe", Pin = 1234, BirthDate = new DateOnly(2021,1,1)},
            new() { FirstName = "Jane", LastName = "Doe", Pin = 5678, BirthDate = new DateOnly(2022,1,1) },
            new() { FirstName = "John", LastName = "Smith", Pin = 9876, BirthDate = new DateOnly(2023,1,1) },
            new() { FirstName = "Jane", LastName = "Smith", Pin = 5432, BirthDate = new DateOnly(2024,1,1) }
        };

        context.AddRange(people);
        context.SaveChanges();

        AnsiConsole.MarkupLine("[yellow]EF Core[/] [green]data added and shown[/]");

        Console.WriteLine(ObjectDumper.Dump(context.Person.ToList()));

        // works when using code in the dbContext under ConfigureConventions
        var caseInsensitive = context.Person
            .Where(p => p.FirstName == "john")
            .ToList();

        // independent of code in dbContext ConfigureConventions
        var firstName = "john";
        var casingLike = context.Person
            .Where(p => EF.Functions.Like(p.FirstName, firstName))
            .ToList();

        // independent of code in dbContext ConfigureConventions
        var caseInsensitiveRaw =
            context.Person.FromSql(
                $"""
                 SELECT * 
                 FROM Person 
                 WHERE FirstName = {firstName} 
                 COLLATE NOCASE
                 """)
                .ToList();

        AnsiConsole.MarkupLine($"[yellow]EF Core[/] [green]case-insensitive count should be 2 => {caseInsensitive.Count} [/]");
    }

}
