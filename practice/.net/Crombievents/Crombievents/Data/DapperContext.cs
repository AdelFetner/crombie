using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Crombievents.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public DapperContext(IConfiguration configuration)
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

        public T SearchEntityByID<T>(string query, string id)
        {
            using (var connection = CreateConnection())
            {
                return connection.QueryFirstOrDefault<T>(query, new { id }) ?? throw new ArgumentException("Data about the specific ID could not be found.");
            }
        }

        public T CreateEntity<T>(string query, object entity)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<T>(query, entity);
            }
        }

        public string UpdateEntity(string query, object updatedEntity)
        {
            using (var connection = CreateConnection())
            {
                int response = connection.Execute(query, updatedEntity);
                if (response > 0)
                {
                    return "Update Succesful!";
                } 
                throw new Exception("Update failed");
            }
        }

        public string DeleteEntity(string query, string id)
        {
            using (var connection = CreateConnection())
            {
                int response = connection.Execute(query, new { id });
                if (response > 0)
                {
                    return "Delete Succesful!";
                }
                throw new Exception("Delete failed");
            }
        }
    }
}
