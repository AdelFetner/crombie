using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using unidad_4_webapi.Services;
using unidad_4_webapi.Models;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.Data.SqlClient;
using Dapper;
using unidad_4_webapi.Data;
using System.Data;

namespace unidad_4_webapi.Services
{
    public class UsuarioService
    {
        string connectionString = "Server=localhost;    Database=biblioteca;   Integrated Security=true; TrustServerCertificate=True;";
        private readonly DapperContext _context;
        private readonly IDbConnection _connectionString;


        public UsuarioService(DapperContext context)
        {
            this._context = context;
            _connectionString = context.CreateConnection();
        }

        //public List<Usuario> GetUsers()
        //{

        //    var connection = new SqlConnection(_connectionString);

        //    //para traermelos en orden ascendente, al ser varchar se ordenan lógicamente en orden alfabético, haciendo que se haga (1, 10 ,11, 2, 3, 30, etc)
        //    var sql = "SELECT * FROM Usuarios ORDER BY CAST(IdUsuario AS INT) ASC;";

        //    var idUsuarios = connection.Query<Usuario>(sql).ToList();

        //    return idUsuarios;
        //}
        public List<object> GetUsers()
        {

            return _context.GetEntities("SELECT * FROM Usuarios ORDER BY CAST(IdUsuario AS INT) ASC;");
        }

        public Usuario CreateUser(Usuario usuario)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //inserta y después selecciona para verificar que existe correctamente en la tabla
                string sql = @"
                INSERT INTO Usuarios 
                (IdUsuario, Nombre, TipoUsuario, LibrosPrestados) 
                VALUES 
                (@IdUsuario, @Nombre, @TipoUsuario, @LibrosPrestados);
                SELECT * FROM Usuarios WHERE IdUsuario = @IdUsuario";

                return connection.QuerySingle<Usuario>(sql, usuario);
            }
        }

        public Usuario SearchUserByID(string id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Usuarios WHERE IdUsuario = @id";
                Usuario response = connection.QueryFirstOrDefault<Usuario>(sql, new { id }) ?? throw new ArgumentException("No se encontró un usuario con el ID especificado.");

                return response;
            }
        }

        public Usuario UpdateUser(Usuario datosActualizados)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"
                UPDATE Usuarios 
                SET Nombre = @Nombre, TipoUsuario = @TipoUsuario, LibrosPrestados = @LibrosPrestados
                WHERE IdUsuario = @IdUsuario";

                int rowsAffected = connection.Execute(sql, datosActualizados);

                if (rowsAffected > 0)
                {
                    return datosActualizados;
                }
                else
                {
                    throw new ArgumentException("No se encontró un registro con el ID especificado.");
                }
            }
        }

        public Usuario DeleteUser(string id)
        {
            var usuario = SearchUserByID(id);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");
            if (usuario.LibrosPrestados.Any())
                throw new ArgumentException("No se puede eliminar un usuario con libros prestados antes de devolverlos");

            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Usuarios WHERE IdUsuario = @id";
                int rowsAffected = connection.Execute(sql, new { id });

                if (rowsAffected > 0)
                    return usuario;
                else
                    throw new ArgumentException("No se pudo eliminar el usuario.");
            }
        }
    }
}