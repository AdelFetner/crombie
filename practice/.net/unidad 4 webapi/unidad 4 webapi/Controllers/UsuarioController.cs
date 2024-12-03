using Microsoft.AspNetCore.Mvc;
using unidad_4_webapi.Models;
using unidad_4_webapi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _usuarioService;

        public UsuarioController(UsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_usuarioService.GetUsers());
        }

        [HttpGet("{id}")]
        public ActionResult<Usuario> GetUsuario(string id)
        {
            var usuario = _usuarioService.BuscarUsuarioPorId(id);
            return usuario != null ? Ok(usuario) : NotFound();
        }

        [HttpPost]
        public ActionResult<string> CrearUsuario([FromBody] Usuario nuevoUsuario)
        {
            return Ok(_usuarioService.CreateUser(nuevoUsuario));
        }

        [HttpPut("{id}")]
        public ActionResult<string> ActualizarUsuario([FromBody] Usuario usuario)
        {
            return Ok(_usuarioService.ActualizarUsuario(usuario));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> EliminarUsuario(string id)
        {
            return Ok(_usuarioService.EliminarUsuario(id));
        }
    }
}
