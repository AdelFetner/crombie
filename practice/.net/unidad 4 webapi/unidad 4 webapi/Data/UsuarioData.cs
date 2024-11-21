using unidad_4_webapi.Models;

namespace unidad_4_webapi.Data
{
//think data like a piece of reusable code for many parts of the program
    public class UsuarioData
    {
        public List<Usuario> usuariosList = new List<Usuario>();

        //public UsuarioData()
        //{
        //    usuariosList.Add(new Usuario());

        //}
        public List<Usuario> GetAllUsers()
        {
            return usuariosList;
        }

        public List<Usuario> GetAllUsuarioDB()
        {
            return usuariosList;
        }

        public List<Usuario> GetAllUsuarioExcel()
        {
            return usuariosList;
        }
    }
}
