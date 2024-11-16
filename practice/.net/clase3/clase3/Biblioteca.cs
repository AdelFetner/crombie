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
            // titulo
            Console.WriteLine("Ingrese el título del libro:");
            string titulo = Console.ReadLine();
            if (string.IsNullOrEmpty(titulo))
            {
                throw new Exception("Debe haber un titulo");
            }
            libro.Titulo = titulo;
            //  autor
            Console.WriteLine("Ingrese el autor del libro:");
            string autor = Console.ReadLine();
            if (string.IsNullOrEmpty(autor))
            {
                throw new Exception("Debe haber un autor");
            }
            libro.Autor = autor;
            //isbn
            Console.WriteLine("Ingrese el isbn del libro:");
            string isbn = Console.ReadLine();
            if (string.IsNullOrEmpty(isbn))
            {
                throw new Exception("Debe haber un ISBN");
            }
            libro.ISBN = isbn;

            Libros.Add(libro);
            return "Libro agregado exitosamente";
        }

        public string NuevoUsuario(Usuario usuario)
        {
            Console.WriteLine("Ingrese el nombre del usuario:");
            string nombre = Console.ReadLine();
            if (string.IsNullOrEmpty(nombre))
            {
                throw new Exception("Debe haber un nombre");
            }
            usuario.Nombre = nombre;

            Console.WriteLine("Ingrese el ID del usuario:");
            int userID = Convert.ToInt32(Console.ReadLine());
            if (userID.GetType() == typeof(int))
            {
                throw new Exception("Debe haber un ID");
            }
            usuario.UserID = userID;

            Usuarios.Add(usuario);
            return "Usuario creado exitosamente";
        }

        public string PrestarLibro(Libro libro, Usuario usuario)
        {
            Console.WriteLine("Ingrese el ISBN del libro a prestar:");
            string isbn = Console.ReadLine();
            libro.ISBN = isbn;

            Console.WriteLine("Ingrese el ID del usuario a prestar:");
            string userID = Console.ReadLine();
            usuario.UserID = userID;

            //cambia obj usuariopresta y como no disponible
            libro.EstaDisponible = false;
            libro.UsuarioIDPresta = usuario.UserID;

            usuario.LibrosPrestados.Add(libro);

            return "Libro prestado exitosamente";
        }

        public string DevolverLibro(string ISBN, int IUserID)
        {
            Console.WriteLine("Ingrese el ISBN del libro a devolver:");
            string isbn = Console.ReadLine();

            string userID = Console.ReadLine();
            Console.WriteLine("Ingrese el ID del usuario que devuelve:");
            if(LibrosPrestados.find)
            {

            }

            libro.EstaDisponible = true;
            //libro.UsuarioIDPresta = 
        }
    }
}
