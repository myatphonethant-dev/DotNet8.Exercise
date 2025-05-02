namespace DotNet8.Shared.DbService;

public class DbService
{
    public string GetConnectionString()
    {
        var builder = new SqlConnectionStringBuilder
        {
            DataSource = ".",
            InitialCatalog = "DotNetExercise",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        return builder.ConnectionString;
    }
}