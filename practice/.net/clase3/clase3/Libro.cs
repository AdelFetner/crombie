using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroComponent
{
    public class Libro
    {
        private string _autor;
        public string Autor {
            get
            {
                return this._autor;
            }
            set
            {
                if (value.Length < 5)
                {
                    Console.WriteLine($"Nombre Invalido");
                };
                this._autor = value;
            }
        }

        public string Titulo { get; set; }
        public string ISBN { get; set; }

        public bool EstaDisponible { get; set; }
        public Libro(string Autor, string Titulo, string ISBN, bool EstaDisponible)
        {
            this._autor = Autor;
            this.Autor = Autor;
            this.Titulo = Titulo;
            this.ISBN = ISBN;
            this.EstaDisponible = EstaDisponible;

        }

        public Libro()
        {
            this._autor = Autor;
            this.Autor = "Autor por defecto";
            this.Titulo = "Titulo por defecto";
            this.ISBN = "ISBN por defecto";
            this.EstaDisponible = false;
        }

        public Libro(string Autor)
        {
            this._autor = Autor;
            this.Titulo = "Titulo sin especificar";
            this.ISBN = "ISBN sin especificar";
            this.EstaDisponible = false;
        }
    }
}