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
            return Ok(_libroService.InsertarLibro(libro));
        }

        [HttpGet("libro/{id}")]
        public ActionResult<Libro> BuscarLibro(string id)
        {
            var libro = _libroService.BuscarLibroPorId(id);
            return libro != null ? Ok(libro) : NotFound();
        }

        [HttpPut("update/{id}")]
        public ActionResult<string> ActualizarLibro(Libro libro)
        {
            return Ok(_libroService.ActualizarLibro(libro));
        }

        [HttpPut("devolver/{isbn}")]
        public ActionResult<string> EliminarLibro(string idLibro)
        {
            return Ok(_libroService.EliminarLibro(idLibro));
        }
    }

}
