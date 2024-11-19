using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using unidad_4_webapi.Servicios;
using unidad_4_webapi.Models;

namespace unidad_4_webapi.Servicios
{
    public class UsuarioService
    {
        public List<Usuario> usuarios = new List<Usuario>();

        public string CrearUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío");

            if (usuarios.Any(u => u.UserID == usuario.UserID))
                throw new ArgumentException("Ya existe un usuario con ese ID");

            usuarios.Add(usuario);
            if (usuarios.Contains(usuario))
            {
                return "Usuario creado exitosamente";
            }
            else
            {
                throw new ArgumentException("Ocurrió un error agregando el usuario");
            }

        }

        public Usuario BuscarUsuarioPorId(int id)
        {
            return usuarios.FirstOrDefault(u => u.UserID == id);
        }

        public IEnumerable<Usuario> ObtenerTodosUsuarios()
        {
            return usuarios;
        }

        public string ActualizarUsuario(int id, Usuario usuario)
        {
            var usuarioExistente = BuscarUsuarioPorId(id);
            if (usuarioExistente == null)
                throw new ArgumentException("Usuario no encontrado");

            usuarioExistente.Nombre = usuario.Nombre;
            return "Usuario actualizado exitosamente";
        }

        public string EliminarUsuario(int id)
        {
            var usuario = BuscarUsuarioPorId(id);
            if (usuario == null)
                throw new ArgumentException("Usuario no encontrado");

            if (usuario.LibrosPrestados.Any())
                throw new InvalidOperationException("No se puede eliminar un usuario con libros prestados");

            usuarios.Remove(usuario);
            return "Usuario eliminado exitosamente";
        }
    }
}