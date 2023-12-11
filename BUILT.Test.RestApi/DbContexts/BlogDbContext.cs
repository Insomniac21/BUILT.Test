using System.Data;
using System.Data.SqlClient;

namespace BUILT.Test.RestApi.DbContexts
{
    public class BlogDbContext
    {
        private readonly string _connectionString;

        public BlogDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
