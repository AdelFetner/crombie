using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using unidad_4_webapi.Models;

namespace unidad_4_webapi.Services
{
    public class LibroService
    {
        string connectionString = "Server=localhost;    Database=biblioteca;   Integrated Security=true; TrustServerCertificate=True;";

        public List<Libro> GetBooks()
        {
            var connection = new SqlConnection(connectionString);

            //para traermelos en orden ascendente, al ser varchar se ordenan lógicamente en orden alfabético, haciendo que se haga (1, 10 ,11, 2, 3, 30, etc)
            var sql = "SELECT * FROM Libros ORDER BY CAST(IdLibro AS INT) ASC;";

            var libros = connection.Query<Libro>(sql).ToList();

            return libros;
        }
        public Libro SearchByID(string id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Libros WHERE IdLibro = @id";
                Libro response = connection.QueryFirstOrDefault<Libro>(sql, new { id })
                    ?? throw new ArgumentException("No se encontró un libro con el ID especificado.");
                return response;
            }
        }

        public Libro AddBook(Libro nuevoLibro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                //inserta y después selecciona para verificar que existe correctamente en la tabla
                string sql = @"
                INSERT INTO Libros 
                (IdLibro, Titulo, Autor, Disponibilidad, Cantidad) 
                VALUES 
                (@IdLibro, @Titulo, @Autor, @Disponibilidad, @Cantidad);
                SELECT * FROM Libros WHERE IdLibro = @IdLibro";
                return connection.QuerySingle<Libro>(sql, nuevoLibro);
            }
        }



        public Libro UpdateBook(Libro libroActualizado)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"
                UPDATE Libros 
                SET Titulo = @Titulo, Autor = @Autor, 
                    Disponibilidad = @Disponibilidad, Cantidad = @Cantidad
                WHERE IdLibro = @IdLibro";

                int rowsAffected = connection.Execute(sql, libroActualizado);

                if (rowsAffected > 0)
                {
                    return libroActualizado;
                }
                else
                {
                    throw new ArgumentException("No se encontró un registro con el ID especificado.");
                }
            }
        }

        public string DeleteBook(string idLibro)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "DELETE FROM Libros WHERE IdLibro = @id";
                int rowsAffected = connection.Execute(sql, new { id = idLibro });

                if (rowsAffected > 0)
                    return $"el id {idLibro} fue eliminado correctamente";
                else
                    throw new ArgumentException("No se pudo eliminar el libro.");
            }
        }
    }
}