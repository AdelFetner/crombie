using unidad_4_webapi.Models;

namespace unidad_4_webapi.Servicios

{
    public class BibliotecaService
    {
        private readonly LibroService _libroService;
        private readonly UsuarioService _usuarioService;
        private Biblioteca _biblioteca;

        public BibliotecaService(LibroService libroService, UsuarioService usuarioService)
        {
            _libroService = libroService;
            _usuarioService = usuarioService;
            _biblioteca = new Biblioteca();
        }

        public IEnumerable<Libro> ObtenerTodosLibros()
        {
            return _biblioteca.Libros;
        }

        public IEnumerable<Libro> ObtenerLibrosDisponibles()
        {
            return _biblioteca.LibrosDisponibles;
        }

        public IEnumerable<Usuario> ObtenerTodosUsuarios()
        {
            return _biblioteca.Usuarios;
        }

        public string PrestarLibro(string isbn, int usuarioId)
        {
            var libro = _biblioteca.LibrosDisponibles.FirstOrDefault(l => l.ISBN == isbn);
            if (libro == null)
                throw new ArgumentException("Libro no disponible");

            var usuario = _biblioteca.Usuarios.FirstOrDefault(u => u.UserID == usuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");

            libro.EstaDisponible = false;
            libro.UsuarioIDPresta = usuarioId;
            usuario.LibrosPrestados.Add(libro);
            _biblioteca.LibrosDisponibles.Remove(libro);

            return "Libro prestado exitosamente";
        }

        public string DevolverLibro(string isbn, int usuarioId)
        {
            var usuario = _biblioteca.Usuarios.FirstOrDefault(u => u.UserID == usuarioId);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");

            var libro = usuario.LibrosPrestados.FirstOrDefault(l => l.ISBN == isbn);
            if (libro == null)
                throw new ArgumentException("Libro no encontrado en préstamos del usuario");

            libro.EstaDisponible = true;
            libro.UsuarioIDPresta = 0;
            usuario.LibrosPrestados.Remove(libro);
            _biblioteca.LibrosDisponibles.Add(libro);

            return "Libro devuelto exitosamente";
        }

        public string AgregarLibro(Libro libro)
        {
            _biblioteca.Libros.Add(libro);
            if (libro.EstaDisponible)
                _biblioteca.LibrosDisponibles.Add(libro);
            return "Libro agregado exitosamente";
        }

        public string AgregarUsuario(Usuario usuario)
        {
            _biblioteca.Usuarios.Add(usuario);
            return "Usuario agregado exitosamente";
        }
    }
}
