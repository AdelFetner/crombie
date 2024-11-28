namespace unidad_4_webapi.Models
{
    public class Libro
    {
        public string IdLibro { get; set; }  // El ID del libro
        public string Titulo { get; set; }   // El título del libro
        public string Autor { get; set; }    // El autor del libro
        public string Disponibilidad { get; set; }  // Disponibilidad del libro (por ejemplo, "Disponible" o "Prestado")
        public int Cantidad { get; set; }    // Cantidad de libros disponibles

        // Constructor con parámetros para inicializar un libro
        public Libro(string idLibro, string titulo, string autor, string disponibilidad, int cantidad)
        {
            IdLibro = idLibro;
            Titulo = titulo;
            Autor = autor;
            Disponibilidad = disponibilidad;
            Cantidad = cantidad;
        }

        // Constructor por defecto
        public Libro()
        {
            IdLibro = "Desconocido";
            Titulo = "Título por defecto";
            Autor = "Autor por defecto";
            Disponibilidad = "Disponible";
            Cantidad = 0;
        }

    }
}
