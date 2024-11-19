﻿using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Bibliography;
using unidad_4_webapi.Servicios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        // GET: api/<LibraryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<LibraryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // POST api/<LibraryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/<LibraryController>/books
        [HttpGet("{books}")]
        public string GetBook(string isbn)
        {

            List<object> libros = List<object> Libros;
            object LibroEncontrado = libros.Find(libro.Contains(isbn));
            return LibroEncontrado;
        }

    }
}