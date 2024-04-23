namespace TriviaGame.Api.Data.Configuration;

#nullable disable
public class DatabaseConfiguration
{
    public string DatabaseName { get; set; }
    public string SeedFilePath { get; set; }
    public DatabaseType DatabaseType { get; set; }
    public string SqlLiteDbPath { get; set; }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(DatabaseName))
        {
            throw new ArgumentException("DatabaseName must not be null or empty in configuration", nameof(DatabaseName));
        }
        if (string.IsNullOrWhiteSpace(SeedFilePath))
        {
            throw new ArgumentException("SeedFilePath must not be null or empty in configuration", nameof(SeedFilePath));
        }
        if (DatabaseType == DatabaseType.SqlLiteDb && string.IsNullOrWhiteSpace(SqlLiteDbPath))
        {
            throw new ArgumentException("SqlLiteDbPath must not be null or empty in configuration", nameof(SqlLiteDbPath));
        }
    }
}

public enum DatabaseType
{
    InMemoryDb,
    SqlLiteDb
}