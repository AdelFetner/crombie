using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using unidad_4_webapi.Servicios;
using unidad_4_webapi.Models;
using unidad_4_webapi.Data;

namespace unidad_4_webapi.Servicios
{
    public class UsuarioService
    {
        UsuarioData _data = new UsuarioData();

        public List<Usuario> Usuarios = new List<Usuario>();

        //why doesn't this lambda fn work?
        //public List<Usuario> GetUsers = () => _data.GetAllUsers();

        public List<Usuario> TraerUsuarios()
        {
            return Usuarios;
        }
        //why does the code above works but the one below doesn't?
        //List<Usuario> _usuarios = _data.GetAllUsers();

        public string CrearUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío");

            if (Usuarios.Any(u => u.UserID == usuario.UserID))
                throw new ArgumentException("Ya existe un usuario con ese ID");

            Usuarios.Add(usuario);
            if (Usuarios.Contains(usuario))
            {
                return $"Usuario creado exitosamente, el usuario es ${usuario}, los usuarios son ${Usuarios}";
            }
            return "23123123";
        }

        public Usuario? BuscarUsuarioPorId(int id)
        {
            return Usuarios.Find(u => u.UserID == id);
        }

        public IEnumerable<Usuario> ObtenerTodosUsuarios()
        {
            return TraerUsuarios();
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

            Usuarios.Remove(usuario);
            return "Usuario eliminado exitosamente";
        }
    }
}