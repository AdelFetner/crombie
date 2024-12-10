﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("libro/")]
        public ActionResult<List<Usuario>> GetBooks()
        {
            return Ok(_libroService.GetBooks());
        }

        [HttpGet("libro/{id}")]
        public ActionResult<Libro> BuscarLibro(string id)
        {
            var libro = _libroService.SearchByID(id);
            return libro != null ? Ok(libro) : NotFound();
        }

        [HttpPost("libro")]
        public ActionResult<string> CrearLibro(Libro libro)
        {
            return Ok(_libroService.AddBook(libro));
        }

        [HttpPut("update/{id}")]
        public ActionResult<string> UpdateBook(Libro libro)
        {
            return Ok(_libroService.UpdateBook(libro));
        }

        [HttpPut("delete/{id}")]
        public ActionResult<string> DeleteBook(string idLibro)
        {
            return Ok(_libroService.DeleteBook(idLibro));
        }
    }
}
