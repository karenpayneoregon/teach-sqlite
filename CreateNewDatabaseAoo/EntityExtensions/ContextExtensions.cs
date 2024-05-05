using Microsoft.EntityFrameworkCore;

namespace CreateNewDatabaseApp.EntityExtensions;

    public static class ContextExtensions
    {
        /// <summary>
        /// Set case-insensitive searches for SQLite
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetCaseInsensitiveSearchesForSQLite(this ModelBuilder modelBuilder)
        {
            if (modelBuilder == null) throw new ArgumentNullException(nameof(modelBuilder));
            
            modelBuilder.UseCollation("NOCASE");

            var items = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string));

            foreach (var property in items)
            {
                property.SetCollation("NOCASE");
            }
        }

    }