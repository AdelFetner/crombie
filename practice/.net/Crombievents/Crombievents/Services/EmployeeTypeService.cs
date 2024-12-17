using Crombievents.Interfaces;
using Crombievents.Models;
using System.Collections.Generic;

namespace Crombievents.Services
{
    public class EmployeeTypeService
    {
        private readonly IRepository<EmployeeType> _employeeTypeRepository;

        public EmployeeTypeService(IRepository<EmployeeType> employeeTypeRepository)
        {
            _employeeTypeRepository = employeeTypeRepository;
        }

        public List<EmployeeType> GetAllEmployeeTypes()
        {
            string query = "SELECT * FROM EmployeeTypes";
            return _employeeTypeRepository.GetEntities(query);
        }

        public EmployeeType GetEmployeeTypeById(int id)
        {
            string query = "SELECT * FROM EmployeeTypes WHERE EmployeeTypeID = @id";
            return _employeeTypeRepository.SearchEntityByID(query, id.ToString());
        }

        public EmployeeType CreateEmployeeType(EmployeeType newEmployeeType)
        {
            string query = @"
                INSERT INTO EmployeeTypes (EmployeeTypeID, TypeName) 
                VALUES (@EmployeeTypeID, @TypeName);
                SELECT * FROM EmployeeTypes WHERE EmployeeTypeID = @EmployeeTypeID";
            return _employeeTypeRepository.CreateEntity(query, newEmployeeType);
        }

        public string DeleteEmployeeType(int id)
        {
            string query = "DELETE FROM EmployeeTypes WHERE EmployeeTypeID = @id";
            return _employeeTypeRepository.DeleteEntity(query, id.ToString());
        }
    }
}