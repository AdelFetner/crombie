using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Crombievents.Data
{
    public class ReportContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ReportContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public List<T> GetEntities<T>(string query)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(query).ToList();
            }
        }

        public T SearchEntityByID<T>(string query, int id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(query, new { id }) ?? throw new ArgumentException("Data about the specific ID could not be found.");
            }
        }

        public T SearchEntityByID<T>(string query, string id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(query, new { id }) ?? throw new ArgumentException("Data about the specific ID could not be found.");
            }
        }

        public T SearchEntityWithParams<T>(string query, object parameters)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(query, parameters) ?? throw new ArgumentException("Data with the specified parameters could not be found.");
            }
        }

        public List<T> SearchEntitiesWithParams<T>(string query, object parameters)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(query, parameters).ToList();
            }
        }
    }
}
