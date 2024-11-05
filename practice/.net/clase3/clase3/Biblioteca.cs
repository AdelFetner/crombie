using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibroComponent;
using UsuarioComponent;

namespace BibliotecaComponent

{
    public class Biblioteca
    {
        public ArrayList LibrosTotales
        {
            get
            {
                return this.LibrosTotales;
            }
            set
            {
                if (LibrosTotales.Count == 0)
                {
                    Console.WriteLine("Actualmente no hay libros en la biblioteca");
                };
            }
        }
        public ArrayList LibrosDisponibles { 
            get
            {
                return this.LibrosDisponibles;
            }
            set
            {
                if (LibrosDisponibles.Count == 0)
                {
                    Console.WriteLine("Actualmente no hay libros disponibles");
                };
            } 
        }

        public ArrayList Usuarios
        {
            get
            {
                return this.Usuarios;
            }
            set
            { 
                this.Usuarios = value; 
            }
        }

        public string NuevoLibro(Libro libro)
        {
            LibrosTotales.Add(libro);
            return "Libro agregado exitosamente";
        }

        public string NuevoUsuario(Usuario usuario)
        {

        }

        public string PrestarLibro(Libro libro, Usuario usuario)
        {
            libro.EstaDisponible = false;
            usuario.LibrosPrestados.Add(libro);

            return "Libro prestado exitosamente";
        }


    }
}
