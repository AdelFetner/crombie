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
        //UsuarioData _data;
        //List<Usuario> Usuarios;


        //public UsuarioService() 
        //{
        //    _data = new UsuarioData();
        //    Usuarios = _data.GetAllUsers();
        //}

        public List<Usuario> usuariosList = new UsuarioData().usuariosList;

        //why doesn't this lambda fn work?
        //public List<Usuario> GetUsers = () => _data.GetAllUsers();
        //why does the code above works but the one below doesn't?
        //List<Usuario> _usuarios = _data.GetAllUsers();

        public string CrearUsuario(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre no puede estar vacío");

            if (usuariosList.Any(u => u.UserID == usuario.UserID))
                throw new ArgumentException("Ya existe un usuario con ese ID");

            usuariosList.Add(usuario);
            if (usuariosList.Contains(usuario))
            {
                return $"Usuario creado exitosamente, el usuario es ${usuario}, los usuarios son ${usuariosList}";
            }
        }

        public Usuario? BuscarUsuarioPorId(int id)
        {
            return usuariosList.Find(u => u.UserID == id);
        }

        public IEnumerable<Usuario> ObtenerTodosUsuarios()
        {
            var resultado = usuariosList;
            return resultado;
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

            usuariosList.Remove(usuario);
            return "Usuario eliminado exitosamente";
        }
    }
}