using System.Data;
using MySqlConnector;

namespace Back_end.Models;

public class DbConnection
{
       private readonly string _connectionString;

       public DbConnection(IConfiguration configuration)
       {
              _connectionString = configuration.GetConnectionString("DefaultConnection");
       }

       public IDbConnection CreateConnection()
       {
              return new MySqlConnection(_connectionString);
       }
}