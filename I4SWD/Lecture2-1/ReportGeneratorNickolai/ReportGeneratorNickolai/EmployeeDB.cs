using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGeneratorNickolai
{
    public class EmployeeDB
    {
        public List<Employee> _employees;

        public EmployeeDB()
        {
            ResetDB();
        }

        public void ResetDB()
        {
            //_employees.Clear();
        }

        public void AddEmployee(Employee e)
        {
            _employees.Add(e);
        }

        public void RemoveEmployee(Employee e)
        {
            int index = _employees.BinarySearch(e);
            try
            {
                _employees.RemoveAt(index);
            }
            catch
            {
                Console.WriteLine("Employee not found!");
            }
        }

        public List<Employee> GetEmployees()
        {
            return _employees;
        }
    }
}
