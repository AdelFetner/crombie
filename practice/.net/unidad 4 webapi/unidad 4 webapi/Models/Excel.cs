namespace unidad_4_webapi.Models
{
    public class Excel
    {
        // ID como string para permitir identificadores alfanuméricos
        public string ID { get; set; }

        // Nombre del registro
        public string Nombre { get; set; }

        // Edad como entero
        public int Edad { get; set; }

        // Constructor vacío para permitir crear instancias sin parámetros
        public Excel()
        {
        }

        // Constructor con parámetros para facilitar la creación de objetos
        public Excel(string id, string nombre, int edad)
        {
            ID = id;
            Nombre = nombre;
            Edad = edad;
        }

        // Override de ToString para facilitar el debugging
        public override string ToString()
        {
            return $"ID: {ID}, Nombre: {Nombre}, Edad: {Edad}";
        }
    }
}
