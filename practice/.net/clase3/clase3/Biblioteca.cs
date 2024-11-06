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
        public ArrayList Libros
        {
            get
            {
                return this.Libros;
            }
            set
            {
                if (Libros.Count == 0)
                {
                    Console.WriteLine("Actualmente no hay libros en la biblioteca");
                };
            }
        }
        public ArrayList LibrosDisponibles
        {
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
            Libros.Add(libro);
            return "Libro agregado exitosamente";
        }

        public string NuevoUsuario(Usuario usuario)
        {
            Usuarios.Add(usuario);
            return "Usuario creado exitosamente";
        }

        public string PrestarLibro(Libro libro, Usuario usuario)
        {
            //cambia obj usuariopresta y como no disponible
            libro.EstaDisponible = false;
            libro.UsuarioIDPresta = usuario.ID;

            usuario.LibrosPrestados.Add(libro);

            return "Libro prestado exitosamente";
        }

        public string DevolverLibro(Libro libro, Usuario usuario)
        {
            libro.EstaDisponible = true;
            //libro.UsuarioIDPresta = 
        }
    }
}
