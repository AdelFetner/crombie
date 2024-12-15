using ClosedXML.Excel;
using Dapper;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.Data.SqlClient;
using System.Data;
using unidad_4_webapi.Data;
using unidad_4_webapi.Models;

namespace unidad_4_webapi.Services
{
    public class LibroService
    {
        private readonly DapperContext _context;
        private readonly IDbConnection _connectionString;


        public LibroService(DapperContext context)
        {
            this._context = context;
            _connectionString = context.CreateConnection();
        }

        public List<object> GetBooks()
        {
            return _context.GetEntities("SELECT * FROM Libros ORDER BY CAST(IdLibro AS INT) ASC;");
        }
        public object SearchByID(string id)
        {
            return _context.SearchEntityByID("SELECT * FROM Libros WHERE IdLibro = @id", id);
        }

        public object CreateBook(Libro nuevoLibro)
        {
            return _context.CreateEntity(@"
                INSERT INTO Libros 
                (IdLibro, Titulo, Autor, Disponibilidad, Cantidad) 
                VALUES 
                (@IdLibro, @Titulo, @Autor, @Disponibilidad, @Cantidad);
                SELECT * FROM Libros WHERE IdLibro = @IdLibro", nuevoLibro);
        }



        public object UpdateBook(Libro libroActualizado)
        {
            return _context.UpdateEntity(@"
                UPDATE Libros 
                SET Titulo = @Titulo, Autor = @Autor, 
                    Disponibilidad = @Disponibilidad, Cantidad = @Cantidad
                WHERE IdLibro = @IdLibro", libroActualizado);
        }

        public string DeleteBook(string idLibro)
        {
            return _context.DeleteEntity("DELETE FROM Libros WHERE IdLibro = @id", idLibro);
        }
    }
}