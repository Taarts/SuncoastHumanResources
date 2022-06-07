using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        private List<Employee> Employees { get; set; } = new List<Employee>();

        // Create ADD employee
        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }
        // Read GET all the Employees
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }
        // Read FIND one employee
        public Employee FindOneEmployee(string nameToFind)
        {
            Employee foundEmployee = Employees.FirstOrDefault(Employee => Employee.Name.ToUpper().Contains(nameToFind.ToUpper()));

            return foundEmployee;
        }
        // Delete DELETE employee
        public void DeleteEmployee(Employee employeeToDelete)
        {
            Employee.Remove(employeeToDelete);
        }
        // Update?

    }
}