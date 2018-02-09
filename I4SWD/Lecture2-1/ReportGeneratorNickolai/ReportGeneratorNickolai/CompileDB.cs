using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGeneratorNickolai
{
    public class CompileDB
    {
        private readonly EmployeeDB _employeeDb;

        public CompileDB(EmployeeDB employeeDb)
        {
            _employeeDb = employeeDb;
        }

        public List<Employee> CompileDatabase()
        {
            var employees = new List<Employee>();
            Employee employee;

            _employeeDb.Reset();

            // Get all employees
            while ((employee = _employeeDb.GetNextEmployee()) != null)
            {
                employees.Add(employee);
            }

            return employees;
        }
    }
}
