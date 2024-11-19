using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Bibliography;
using unidad_4_webapi.Servicios;
using unidad_4_webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BibliotecaController : ControllerBase
    {
        private readonly BibliotecaService _bibliotecaService;

        public BibliotecaController(BibliotecaService bibliotecaService)
        {
            _bibliotecaService = bibliotecaService;
        }

        [HttpGet("libros")]
        public ActionResult<IEnumerable<Libro>> GetLibros()
        {
            return Ok(_bibliotecaService.ObtenerTodosLibros());
        }

        [HttpGet("libros/disponibles")]
        public ActionResult<IEnumerable<Libro>> GetLibrosDisponibles()
        {
            return Ok(_bibliotecaService.ObtenerLibrosDisponibles());
        }

        [HttpGet("usuarios")]
        public ActionResult<IEnumerable<Usuario>> GetUsuarios()
        {
            return Ok(_bibliotecaService.ObtenerTodosUsuarios());
        }

        [HttpPost("libros/prestar/{isbn}/{usuarioId}")]
        public ActionResult<string> PrestarLibro(string isbn, int usuarioId)
        {
            return Ok(_bibliotecaService.PrestarLibro(isbn, usuarioId));
        }

        [HttpPost("libros/devolver/{isbn}/{usuarioId}")]
        public ActionResult<string> DevolverLibro(string isbn, int usuarioId)
        {
            return Ok(_bibliotecaService.DevolverLibro(isbn, usuarioId));
        }

        [HttpPost("libros")]
        public ActionResult<string> AgregarLibro([FromBody] Libro libro)
        {
            return Ok(_bibliotecaService.AgregarLibro(libro));
        }

        [HttpPost("usuarios")]
        public ActionResult<string> AgregarUsuario([FromBody] Usuario usuario)
        {
            return Ok(_bibliotecaService.AgregarUsuario(usuario));
        }
    }
}
