﻿using Microsoft.AspNetCore.Mvc;
using unidad_4_webapi.Models;
using unidad_4_webapi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace unidad_4_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly ExcelService _excelService;
        // Especifica la ruta relativa del archivo Excel
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BibliotecaBaseDatos.xlsx");

        public ExcelController(ExcelService excelService)
        {
            _excelService = excelService;
        }

        //diferencias entre como está arriba y
        //public class ExcelController(ExcelService excelService) : ControllerBase
        //        {
        //            private readonly ExcelService _excelService = excelService;

            // GET: api/<ExcelController>
            [HttpGet]
        public ActionResult<IEnumerable<string>> GetEncabezados()
        {
            try
            {
                return Ok(_excelService.ObtenerEncabezados(filePath));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los encabezados: {ex.Message}");
            }
        }

        //datos route
        [HttpGet("datos")]
        public ActionResult<List<Excel>> GetDatos()
        {
            try
            {
                return Ok(_excelService.ObtenerDatosUsuarios(filePath));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los datos: {ex.Message}");
            }
        }

        // POST: api/Excel/insertar
        [HttpPost("insertar")]
        public ActionResult InsertarDatos([FromBody] List<Excel> nuevosDatos)
        {
            try
            {
                _excelService.InsertarDatos(filePath, nuevosDatos);
                return Ok("Datos insertados exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al insertar datos: {ex.Message}");
            }
        }

        // PUT: api/Excel/actualizar
        [HttpPut("actualizar")]
        public ActionResult ActualizarDatos([FromBody] Excel datosActualizados)
        {
            try
            {
                _excelService.ActualizarDatosPorId(filePath, datosActualizados);
                return Ok("Datos actualizados exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al actualizar datos: {ex.Message}");
            }
        }
    }
}
