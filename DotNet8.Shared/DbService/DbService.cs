using System.Data.SqlClient;

namespace DotNet8.Shared.DbService;

public class DbService
{
    public string GetConnection()
    {
        var connection = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "DotNetExercise",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        return connection.ConnectionString;
    }
}