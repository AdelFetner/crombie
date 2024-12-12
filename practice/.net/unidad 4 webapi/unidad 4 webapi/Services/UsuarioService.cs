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
        private readonly DapperContext _context;
        private readonly IDbConnection _connectionString;


        public UsuarioService(DapperContext context)
        {
            this._context = context;
            _connectionString = context.CreateConnection();
        }

        public List<object> GetUsers()
        {

            return _context.GetEntities("SELECT * FROM Usuarios ORDER BY CAST(IdUsuario AS INT) ASC;");
        }

        public object CreateUser(Usuario usuario)
        {
            return _context.CreateEntity(@"
                INSERT INTO Usuarios 
                (IdUsuario, Nombre, TipoUsuario, LibrosPrestados) 
                VALUES 
                (@IdUsuario, @Nombre, @TipoUsuario, @LibrosPrestados);
                SELECT * FROM Usuarios WHERE IdUsuario = @IdUsuario", usuario);
        }

        public object SearchUserByID(string id)
        {
            return _context.SearchEntityByID("SELECT * FROM Usuarios WHERE IdUsuario = @id", id);
        }

        public object UpdateUser(object datosActualizados)
        {
            return _context.UpdateEntity(@"
                UPDATE Usuarios 
                SET Nombre = @Nombre, TipoUsuario = @TipoUsuario, LibrosPrestados = @LibrosPrestados
                WHERE IdUsuario = @IdUsuario", datosActualizados);
        }

        public object DeleteUser(string id)
        {
            return _context.DeleteEntity("DELETE FROM Usuarios WHERE IdUsuario = @id", id);
        }
    }
}