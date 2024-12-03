using Dapper;
using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;
using unidad_4_webapi.Models;

namespace unidad_4_webapi.Repository
{
    public class UserRepository
    {
        readonly string connectionString = "Server=localhost;    Database=biblioteca;   Integrated Security=true; TrustServerCertificate=True;";

        public List<Usuario> GetUsers()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var sql = "SELECT * FROM Usuarios ORDER BY CAST(IdUsuario AS INT) ASC;";


                var idUsuarios = connection.Query<Usuario>(sql).ToList();

                return idUsuarios;
            }
        }

        public Usuario CreateUser(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"
                    INSERT INTO Usuarios 
                    (Nombre, TipoUsuario, LibrosPrestados) 
                    VALUES 
                    (@Nombre, @TipoUsuario, @LibrosPrestados);
                    SELECT CAST(SCOPE_IDENTITY() AS INT)";

                int nuevoId = connection.ExecuteScalar<int>(sql, usuario);

                usuario.IDUsuario = nuevoId.ToString();

                return usuario;
            }
        }

        public Usuario? SearchByID(string id)
        {
            return GetUsers().FirstOrDefault(u => u.IDUsuario == id);
        }

        public int ActualizarUsuario(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"
                UPDATE Usuarios 
                SET Nombre = @Nombre, Correo = @Correo, FechaRegistro = @FechaRegistro
                WHERE IdUsuario = @IdUsuario";

                return connection.ExecuteScalar<int>(sql, usuario);
            }
        }

        public int EliminarUsuario(string id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"
                DELETE FROM Usuarios 
                WHERE IdUsuario = @IdUsuario";

                return connection.ExecuteScalar<int>(sql, new { IdUsuario = id });
            }
        }
    }
}
