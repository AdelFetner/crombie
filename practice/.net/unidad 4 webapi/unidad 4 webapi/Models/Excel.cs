namespace unidad_4_webapi.Models
{
    public class Excel
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string Accion { get; set; }
        public string Libro { get; set; }

        // Constructor vacío para permitir crear instancias sin parámetros
        public Excel()
        {
        }

        // Constructor con parámetros para facilitar la creación de objetos
        public Excel(string id, string nombre, string accion, string libro)
        {
            ID = id;
            Nombre = nombre;
            Accion = accion;
            Libro = libro;
        }

        // Override de ToString para facilitar el debugging
        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Nombre}, Acción: {Accion}, Libro: {Libro}";
        }
    }
}
