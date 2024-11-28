using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using unidad_4_webapi.Services;
using unidad_4_webapi.Models;
using unidad_4_webapi.Data;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.Data.SqlClient;
using Dapper;

namespace unidad_4_webapi.Services
{
    public class UsuarioService
    {

        private List<Usuario> _usuarios;
        // Especifica la ruta relativa del archivo Excel
        readonly string filePath = "BibliotecaBaseDatos.xlsx";

        public UsuarioService()
        {
            _usuarios = ObtenerUsuarios();
        }
        public List<Usuario> ObtenerUsuarios()
        {
            var dataList = new List<Usuario>();

            using (var workbook = new XLWorkbook(filePath))
            {

                // Selecciona la primera hoja del archivo.
                var worksheet = workbook.Worksheet(1);

                // Encuentra la última fila utilizada en la hoja.
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                // Recorre cada fila de datos, comenzando desde la segunda fila (omitiendo los encabezados).
                for (int row = 3; row <= lastRowUsed; row++)
                {
                    // Crea una instancia de Excel y asigna valores a sus propiedades desde las celdas de la fila actual.
                    var dataItem = new Usuario
                    {
                        IDUsuario = worksheet.Cell(row, 1).GetValue<string>(),
                        Nombre = worksheet.Cell(row, 2).GetValue<string>(),
                        TipoUsuario = worksheet.Cell(row, 3).GetValue<string>(),
                        LibrosPrestados = worksheet.Cell(row, 4).GetValue<string>()
                    };
                    dataList.Add(dataItem);
                }
                return dataList;
            }
        }

        public List<Usuario> InsertarUsuarios(List<Usuario> NuevosUsuarios)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                foreach (var usuario in NuevosUsuarios)
                {
                    if (_usuarios.Any(u => u.IDUsuario == usuario.IDUsuario)){
                        throw new InvalidOperationException("El usuario con el ID especificado ya existe.");
                    }

                    lastRowUsed++; // Mueve a la siguiente fila disponible

                    // Inserta los valores en las columnas correspondientes de la nueva fila
                    worksheet.Cell(lastRowUsed, 1).Value = Int32.Parse(usuario.IDUsuario);
                    worksheet.Cell(lastRowUsed, 2).Value = usuario.Nombre;
                    worksheet.Cell(lastRowUsed, 3).Value = usuario.TipoUsuario;
                    worksheet.Cell(lastRowUsed, 4).Value = usuario.LibrosPrestados;
                }

                workbook.Save();
            }
            return NuevosUsuarios;
        }

        public Usuario? BuscarUsuarioPorId(string id)
        {
            return _usuarios.FirstOrDefault(u => u.IDUsuario == id);
        }


        public Usuario ActualizarUsuario(Usuario datosActualizados)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();
                bool encontrado = false;

                // Buscar la fila donde el ID coincide y actualizar los datos
                for (int row = 3; row <= lastRowUsed; row++)
                {
                    string idActual = worksheet.Cell(row, 1).GetValue<string>();

                    if (idActual == datosActualizados.IDUsuario)
                    {
                        worksheet.Cell(row, 2).Value = datosActualizados.Nombre;
                        worksheet.Cell(row, 3).Value = datosActualizados.TipoUsuario;
                        worksheet.Cell(row, 4).Value = datosActualizados.LibrosPrestados;
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                {
                    workbook.Save();
                    return datosActualizados;
                }
                throw new InvalidOperationException("No se encontró un registro con el ID especificado.");
            }
        }

        public Usuario EliminarUsuario(string id)
        {
            var usuario = BuscarUsuarioPorId(id);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");

            if (usuario.LibrosPrestados.Any())
                throw new InvalidOperationException("No se puede eliminar un usuario con libros prestados antes de devolverlos");

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(1);
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                // Buscar y eliminar la fila correspondiente al ID
                for (int row = 2; row <= lastRowUsed; row++)
                {
                    string idActual = worksheet.Cell(row, 1).GetValue<string>();
                    if (idActual == id)
                    {
                        worksheet.Row(row).Delete();
                        break;
                    }
                }

                workbook.Save();
            }

            return usuario;
        }

        public List<Usuario> GetIDsFromUsers()
        {
            var connectionString = "Server=localhost;    Database=biblioteca;   Integrated Security=true; TrustServerCertificate=True;";

            var connection = new SqlConnection(connectionString);

            var sql = "SELECT * FROM Usuarios";

            var idUsuarios = connection.Query<Usuario>(sql).ToList();

            return idUsuarios;
        }
    }
}