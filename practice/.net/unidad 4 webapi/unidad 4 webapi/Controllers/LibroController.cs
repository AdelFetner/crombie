using Microsoft.AspNetCore.Mvc;
using unidad_4_webapi.Models;
using unidad_4_webapi.Services;

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

        [HttpGet]
        public ActionResult<List<Usuario>> GetBooks()
        {
            return Ok(_libroService.GetBooks());
        }

        [HttpGet("{id}")]
        public ActionResult<Libro> SearchBook(string id)
        {
            var libro = _libroService.SearchByID(id);
            return libro != null ? Ok(libro) : NotFound();
        }

        [HttpPost]
        public ActionResult<string> CreateBook(Libro libro)
        {
            return Ok(_libroService.CreateBook(libro));
        }

        [HttpPut("{id}")]
        public ActionResult<string> UpdateBook(Libro libro)
        {
            return Ok(_libroService.UpdateBook(libro));
        }

        [HttpDelete("{id}")]
        public ActionResult<string> DeleteBook(string id)
        {
            return Ok(_libroService.DeleteBook(id));
        }
    }
}
