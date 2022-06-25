using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace DragonArchiver.Core.DB;

public class DragonArchiverDbContext : DbContext
{
    #region Public Properties

    #endregion

    #region Constructor
    public DragonArchiverDbContext()
    {
        _ = Database.EnsureCreated();
    }

    #endregion

    #region Overrides

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connection = new SqliteConnection("Data Source=DragonArchiverDb.db");
        connection.Open();

        var command = connection.CreateCommand();

        //Create the database if it doesn't already exist
        command.CommandText = "PRAGMA foreign_keys = ON;";
        _ = command.ExecuteNonQuery();
        _ = optionsBuilder.UseSqlite(connection);

        base.OnConfiguring(optionsBuilder);
    }

    #endregion
}