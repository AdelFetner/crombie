namespace unidad_4_webapi.Models
{
    public class Biblioteca
    {
        public List<Libro> Libros { get; set; }
        public List<Libro> LibrosDisponibles { get; set; }
        public List<Usuario> Usuarios { get; set; }

        public Biblioteca()
        {
            Libros = new List<Libro>();
            LibrosDisponibles = new List<Libro>();
            Usuarios = new List<Usuario>();
        }
    }
}