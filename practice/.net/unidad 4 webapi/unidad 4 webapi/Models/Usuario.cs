namespace unidad_4_webapi.Models
{
    public class Usuario
    {
        public string Nombre { get; set; }
        public int UserID { get; set; }

        public List<object> LibrosPrestados { get; set; }

        public Usuario(string Nombre, int UserID)
        {
            this.Nombre = Nombre;
            this.UserID = UserID;
            List<Libro> LibrosPrestados = new List<Libro>();
        }
    }
}
