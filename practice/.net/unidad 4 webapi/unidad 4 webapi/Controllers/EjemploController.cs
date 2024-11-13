using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EjemploController : ControllerBase
    {
        // GET: api/<EjemploController>
        [HttpGet]
        public IEnumerable<string> GetByID(int id)
        {
            return new string[] { $"the id is {id}" };
        }

        // GET api/<EjemploController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "all ids";
        }

        // POST api/<EjemploController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EjemploController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<EjemploController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
