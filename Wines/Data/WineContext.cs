using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using WinesApp.Classes;
using WinesApp.Models;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

#pragma warning disable CS8618

namespace WinesApp.Data;

public class WineContext : DbContext
{
    public DbSet<Wine> Wines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlite("Data Source=Wines.db;Pooling=False;")
            .LogTo(message => 
                Debug.WriteLine(message), 
                LogLevel.Information);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Setup conversion to and from int/enum
        modelBuilder
            .Entity<Wine>()
            .Property(e => e.WineType)
            .HasConversion<int>();

        modelBuilder.Entity<WineTypes>().HasData(MockedData.WineTypes());
        modelBuilder.Entity<Wine>().HasData(MockedData.Wines());
    }
}