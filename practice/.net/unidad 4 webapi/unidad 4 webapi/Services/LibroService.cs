using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using unidad_4_webapi.Models;

namespace unidad_4_webapi.Services
{
    public class LibroService
    {
        readonly string filePath = "BibliotecaBaseDatos.xlsx";
        string connectionString = "Server=localhost;    Database=biblioteca;   Integrated Security=true; TrustServerCertificate=True;";

        private List<Libro> _libros = new List<Libro>();
        public LibroService()
        {
            _libros = GetBooks();
        }

        public List<Libro> GetBooks()
        {
            var connection = new SqlConnection(connectionString);

            //para traermelos en orden ascendente, al ser varchar se ordenan lógicamente en orden alfabético, haciendo que se haga (1, 10 ,11, 2, 3, 30, etc)
            var sql = "SELECT * FROM Libros ORDER BY CAST(IdLibro AS INT) ASC;";

            var libros = connection.Query<Libro>(sql).ToList();

            return libros;
        }
        public Libro InsertarLibro(Libro nuevoLibro)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(3);  // Asegúrate de que es la hoja correcta
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                lastRowUsed++;  // Avanza a la siguiente fila disponible

                // Inserta los valores del nuevo libro
                worksheet.Cell(lastRowUsed, 1).Value = Int32.Parse(nuevoLibro.IdLibro);
                worksheet.Cell(lastRowUsed, 2).Value = nuevoLibro.Titulo;
                worksheet.Cell(lastRowUsed, 3).Value = nuevoLibro.Autor;
                worksheet.Cell(lastRowUsed, 4).Value = nuevoLibro.Disponibilidad;
                worksheet.Cell(lastRowUsed, 5).Value = nuevoLibro.Cantidad;

                workbook.Save();
            }

            return nuevoLibro;
        }

        public Libro? BuscarLibroPorId(string id)
        {
            return _libros.FirstOrDefault(u => u.IdLibro == id);
        }

        public Libro ActualizarLibro(Libro libroActualizado)
        {
            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(3);  // Asegúrate de que es la hoja correcta
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();
                bool encontrado = false;

                // Buscar la fila donde el IdLibro coincide y actualizar los datos
                for (int row = 3; row <= lastRowUsed; row++)
                {
                    string idActual = worksheet.Cell(row, 1).GetValue<string>(); // Columna A (IdLibro)

                    if (idActual == libroActualizado.IdLibro)
                    {
                        worksheet.Cell(row, 2).Value = libroActualizado.Titulo;
                        worksheet.Cell(row, 3).Value = libroActualizado.Autor;
                        worksheet.Cell(row, 4).Value = libroActualizado.Disponibilidad;
                        worksheet.Cell(row, 5).Value = libroActualizado.Cantidad;
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                {
                    workbook.Save();
                    return libroActualizado;
                }
                throw new InvalidOperationException("No se encontró un registro con el ID especificado.");
            }
        }

        public Libro EliminarLibro(string idLibro)
        {
            var libro = BuscarLibroPorId(idLibro);
            if (libro == null)
                throw new ArgumentException("Libro no encontrado");

            // Agrega validaciones adicionales si es necesario, como si el libro está prestado.

            using (var workbook = new XLWorkbook(filePath))
            {
                var worksheet = workbook.Worksheet(3); // Asegúrate de la hoja correcta
                int lastRowUsed = worksheet.LastRowUsed().RowNumber();

                // Buscar y eliminar la fila correspondiente al ID
                for (int row = 3; row <= lastRowUsed; row++)
                {
                    string idActual = worksheet.Cell(row, 1).GetValue<string>();
                    if (idActual == idLibro)
                    {
                        worksheet.Row(row).Delete();
                        break;
                    }
                }

                workbook.Save();
            }

            return libro;
        }
    }
}