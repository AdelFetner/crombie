using unidad_4_webapi.Services;

namespace unidad_4_webapi.Models
{
    public class Usuario
    {
        public string IDUsuario { get; set; }

        public string Nombre { get; set; }

        public string TipoUsuario { get; set; }

        public string LibrosPrestados { get; set; }

        public Usuario(string idUsuario, string nombre, string tipoUsuario, string librosPrestados)
        {
            this.IDUsuario = idUsuario;
            this.Nombre = nombre;
            this.TipoUsuario = tipoUsuario;
            this.LibrosPrestados = librosPrestados;
        }

        public Usuario() {
            this.IDUsuario = "Desconocido";
            this.Nombre = "Nombre por defecto";
            this.TipoUsuario = "Tipo por defecto";
            this.LibrosPrestados = "Libros prestados por defecto";
        }
    }
}