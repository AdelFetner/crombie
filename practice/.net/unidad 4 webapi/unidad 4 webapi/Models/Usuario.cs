using unidad_4_webapi.Servicios;

namespace unidad_4_webapi.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public int UserID { get; set; }
        public List<Libro> LibrosPrestados { get; set; }

        public Usuario(string Nombre, int UserID, List<Libro> LibrosPrestados)
        {
            this.Nombre = Nombre;
            this.UserID = UserID;
            this.LibrosPrestados = LibrosPrestados;
        }

        public Usuario() 
        {
            
        }
    }
}