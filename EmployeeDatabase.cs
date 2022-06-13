using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SuncoastHumanResources
{
    class EmployeeDatabase
    {
        private List<Employee> Employees { get; set; } = new List<Employee>();

        public void LoadEmployees()
        {

        }

        public void SaveEmployees()
        {
            var fileWriter = new StreamWriter("employees.csv");
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(Employees);

            fileWriter.Close();
        }
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
            Employees.Remove(employeeToDelete);
        }
        // Update?

    }
}