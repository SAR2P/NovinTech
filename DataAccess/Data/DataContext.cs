using MySql.Data.MySqlClient;
using System.Data;


namespace DataAccess.Data
{
    public class DataContext
    {
        private readonly string _connectionString;

        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection createConnection()
        {
            return new MySqlConnection(_connectionString);
        }
    }
}
