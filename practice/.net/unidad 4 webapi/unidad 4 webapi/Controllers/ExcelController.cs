using Microsoft.AspNetCore.Mvc;
using unidad_4_webapi.Data;
using unidad_4_webapi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly ExcelService _excelService;

        public ExcelController(ExcelService excelService)
        {
            _excelService = excelService;
        }
        // GET: api/<ExcelController>
        [HttpGet]
        public IEnumerable<string> GetEncabezados()
        {
            try
            {
                _excelService.ObtenerEncabezados();
            }
            catch
            {

            }
        }

        // GET api/<ExcelController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExcelController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ExcelController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ExcelController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
