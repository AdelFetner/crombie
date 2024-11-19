namespace unidad_4_webapi.Models
{
    public class Libro
    {
        private string _autor;
        public string Autor
        {
            get
            {
                return _autor;
            }
            set
            {
                if (value.Length < 5)
                {
                    Console.WriteLine($"Nombre Invalido");
                };
                _autor = value;
            }
        }

        public string Titulo { get; set; }
        public string ISBN { get; set; }
        public bool EstaDisponible { get; set; }
        public int UsuarioIDPresta { get; set; }

        public Libro(string Autor, string Titulo, string ISBN, bool EstaDisponible)
        {
            _autor = Autor;
            this.Autor = Autor;
            this.Titulo = Titulo;
            this.ISBN = ISBN;
            this.EstaDisponible = EstaDisponible;
        }

        public Libro()
        {
            _autor = Autor;
            Autor = "Autor por defecto";
            Titulo = "Titulo por defecto";
            ISBN = "ISBN por defecto";
            EstaDisponible = false;
        }
    }
}
