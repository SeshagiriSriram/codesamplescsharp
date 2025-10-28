using System.Configuration;
namespace csharp.training.congruent.apps
{
    public static class ConfigValidation
    {
        public static string ValidateAndGetConnectionString()
        {
            var core = (CoreAppSettings)ConfigurationManager.GetSection("CoreAppSettings") ?? throw new ConfigurationErrorsException("CoreAppSettings is required.");
            switch (core.DbType?.Trim().ToUpperInvariant())
            {
                case "SQLITE":
                    var sqlite = (SQLiteSettings)ConfigurationManager.GetSection("SQLiteSettings") ?? throw new ConfigurationErrorsException("SQLiteSettings is required when DbType is 'SQLite'.");
                    return $"Data Source={sqlite.Folder}{Path.PathSeparator}{sqlite.Db};";

                case "SQLSERVER":
                    var sqlserver = (SQLServerSettings)ConfigurationManager.GetSection("SQLServerSettings") ?? throw new ConfigurationErrorsException("SQLServerSettings is required when DbType is 'SqlServer'.");
                    return sqlserver.GetConnectionString();

                default:
                    throw new ConfigurationErrorsException($"Unknown DbType '{core.DbType}' in CoreAppSettings. Expected 'SQLite' or 'SqlServer'.");
            }
        }
    }
}
