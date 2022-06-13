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

        private string FileName = "employees.csv";

        // Method to load employees (returns nothing, just populates the list)
        public void LoadEmployees()
        {
            if (File.Exists(FileName))
            {
                var fileReader = new StreamReader(FileName);
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                // replaces BLANK list of employees with the ones that are in the csv file
                Employees = csvReader.GetRecords<Employee>().ToList();

                fileReader.Close();
            }
        }
        // write to file
        public void SaveEmployees()
        {
            var fileWriter = new StreamWriter(FileName);
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(Employees);

            fileWriter.Close();
        }
        // Create ADD employee
        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
            SaveEmployees();
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