using Crombievents.Interfaces;
using Crombievents.Models;

namespace Crombievents.Services
{
    public class EmployeeService
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetAllEmployees()
        {
            string query = "SELECT * FROM Employees";
            return _employeeRepository.GetEntities(query);
        }

        public Employee GetEmployeeById(string id)
        {
            string query = "SELECT * FROM Employees WHERE EmployeeID = @id";
            return _employeeRepository.SearchEntityByID(query, id);
        }

        public Employee CreateEmployee(Employee newEmployee)
        {
            string query = @"
                INSERT INTO Employees (EmployeeID, Name, Email, Phone, HireDate) 
                VALUES (@EmployeeID, @Name, @Email, @Phone, @HireDate);
                SELECT * FROM Employees where EmployeeId = @EmployeeID";
            return _employeeRepository.CreateEntity(query, newEmployee);
        }

        public string UpdateEmployee(Employee updatedEmployee)
        {
            string query = @"
                UPDATE Employees 
                SET Name = @Name, Email = @Email, Phone = @Phone
                WHERE EmployeeID = @EmployeeID";
            return _employeeRepository.UpdateEntity(query, updatedEmployee);
        }

        public string DeleteEmployee(string id)
        {
            string query = "DELETE FROM Employees WHERE EmployeeID = @id";
            return _employeeRepository.DeleteEntity(query, id);
        }
    }
}
