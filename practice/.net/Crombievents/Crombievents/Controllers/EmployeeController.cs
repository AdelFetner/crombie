using Crombievents.Models;
using Crombievents.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Crombievents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetEmployees()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeByID(string id)
        {
            var response = _employeeService.GetEmployeeById(id);
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee newEmployee)
        {
            var createdEmployee = _employeeService.CreateEmployee(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeByID), new { id = createdEmployee.EmployeeID }, createdEmployee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            var result = _employeeService.UpdateEmployee(updatedEmployee);
            if (result == "Update failed")
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(string id)
        {
            var result = _employeeService.DeleteEmployee(id);
            if (result == "Delete failed")
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}