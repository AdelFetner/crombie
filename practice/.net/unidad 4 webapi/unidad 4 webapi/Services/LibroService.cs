using unidad_4_webapi.Models;

public class LibroService
{
    private List<Libro> _libros = new List<Libro>();

    public string NuevoLibro(Libro libro)
    {
        if (string.IsNullOrWhiteSpace(libro.Titulo))
            throw new ArgumentException("El título no puede estar vacío");

        if (string.IsNullOrWhiteSpace(libro.Autor))
            throw new ArgumentException("El autor no puede estar vacío");

        if (string.IsNullOrWhiteSpace(libro.ISBN))
            throw new ArgumentException("El ISBN no puede estar vacío");

        _libros.Add(libro);
        return "Libro agregado exitosamente";
    }

    public Libro BuscarLibroPorISBN(string isbn)
    {
        return _libros.FirstOrDefault(libro => libro.ISBN == isbn);
    }

    public string PrestarLibro(string isbn, int usuarioId)
    {
        var libro = BuscarLibroPorISBN(isbn);

        if (libro == null)
            throw new ArgumentException("Libro no encontrado");

        if (!libro.EstaDisponible)
            throw new InvalidOperationException("Libro no disponible");

        libro.EstaDisponible = false;
        libro.UsuarioIDPresta = usuarioId;

        return "Libro prestado exitosamente";
    }

    public string DevolverLibro(string isbn)
    {
        var libro = BuscarLibroPorISBN(isbn);

        if (libro == null)
            throw new ArgumentException("Libro no encontrado");

        libro.EstaDisponible = true;
        libro.UsuarioIDPresta = 0;

        return "Libro devuelto exitosamente";
    }
}