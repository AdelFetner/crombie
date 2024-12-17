using Crombievents.Models;
using Crombievents.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Crombievents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTypeController : ControllerBase
    {
        private readonly EmployeeTypeService _employeeTypeService;

        public EmployeeTypeController(EmployeeTypeService employeeTypeService)
        {
            _employeeTypeService = employeeTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<EmployeeType>> GetEmployeeTypes()
        {
            return Ok(_employeeTypeService.GetAllEmployeeTypes());
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeType> GetEmployeeTypeByID(int id)
        {
            var response = _employeeTypeService.GetEmployeeTypeById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<EmployeeType> CreateEmployeeType([FromBody] EmployeeType newEmployeeType)
        {
            var createdEmployeeType = _employeeTypeService.CreateEmployeeType(newEmployeeType);
            return CreatedAtAction(nameof(GetEmployeeTypeByID), new { id = createdEmployeeType.EmployeeTypeID }, createdEmployeeType);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployeeType(int id)
        {
            var result = _employeeTypeService.DeleteEmployeeType(id);
            if (result == "Delete failed")
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}