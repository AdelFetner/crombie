using Microsoft.AspNetCore.Mvc;
using unidad_4_webapi.Models;
using unidad_4_webapi.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroService _libroService;

        public LibroController(LibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost("libro")]
        public ActionResult<string> CrearLibro(Libro libro)
        {
            return Ok(_libroService.NuevoLibro(libro));
        }

        [HttpGet("libro/{isbn}")]
        public ActionResult<Libro> BuscarLibro(string isbn)
        {
            var libro = _libroService.BuscarLibroPorISBN(isbn);
            return libro != null ? Ok(libro) : NotFound();
        }

        [HttpPut("prestar/{isbn}/{usuarioId}")]
        public ActionResult<string> PrestarLibro(string isbn, int usuarioId)
        {
            return Ok(_libroService.PrestarLibro(isbn, usuarioId));
        }

        [HttpPut("devolver/{isbn}")]
        public ActionResult<string> DevolverLibro(string isbn)
        {
            return Ok(_libroService.DevolverLibro(isbn));
        }
    }

}
