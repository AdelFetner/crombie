using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using unidad_4_webapi.Models;

namespace unidad_4_webapi.Data
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

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public List<object> GetEntities(string query)
        {
            using var connection = CreateConnection();
            {
                var sql = query;

                var response = connection.Query<object>(sql).ToList();

                return response;
            }
        }

        public object SearchEntityByID(string query, string id)
        {
            using var connection = CreateConnection();
            {
                string sql = query;

                object response = connection.QueryFirstOrDefault<object>(sql, new { id })
                    ?? throw new ArgumentException("No se encontró información para el ID especificado.");
                
                return response;
            }
        }

        public object CreateEntity(string query, object entity)
        {
            using (var connection = CreateConnection())
            {
                string sql = query;

                return connection.QuerySingle<object>(sql, entity);
            }
        }

        public string UpdateEntity(string query, object updatedEntity)
        {
            using (var connection = CreateConnection())
            {
                string sql = query;

                int rowsAffected = connection.Execute(sql, updatedEntity);

                if (rowsAffected > 0)
                    return $"{updatedEntity} ha sido modificado correctamente.";
                else
                    throw new ArgumentException("No se encontró un registro con el ID especificado.");
            }
        }

        public string DeleteEntity(string query, string id)
        {
            using var connection = CreateConnection();
            {
                string sql = query;
                int rowsAffected = connection.Execute(sql, new { id });

                if (rowsAffected > 0)
                    return $"ID: {id} fue eliminado correctamente";
                else
                    throw new ArgumentException("No se pudo eliminar correctamente.");
            }
        }
    }
}
