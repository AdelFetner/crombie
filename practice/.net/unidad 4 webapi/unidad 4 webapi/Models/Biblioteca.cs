namespace unidad_4_webapi.Servicios
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using unidad_4_webapi;

    namespace unidad_4_webapi.Servicios

    {
        public class Biblioteca
        {
            public List<Libro> Libros
            {
                get
                {
                    return Libros;
                }
                set
                {
                    if (Libros.Count == 0)
                    {
                        Console.WriteLine("Actualmente no hay libros en la biblioteca");
                    };
                }
            }
            public List<object> LibrosDisponibles
            {
                get
                {
                    return LibrosDisponibles;
                }
                set
                {
                    if (LibrosDisponibles.Count == 0)
                    {
                        Console.WriteLine("Actualmente no hay libros disponibles");
                    };
                }
            }

            public List<object> Usuarios
            {
                get
                {
                    return Usuarios;
                }
                set
                {
                    Usuarios = value;
                }
            }
        }
    }

}
