using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGenerator;

namespace RaportGenerator
{
	//not needed

	public class EmployeeListGenerator
	{
		public List<Employee> GenerateEmployeeList(EmployeeDB employeeDb)
		{
			var employees = new List<Employee>();
			Employee employee;

			employeeDb.Reset();

			// Get all employees
			while ((employee = employeeDb.GetNextEmployee()) != null)
			{
				employees.Add(employee);
			}

			return employees;
		}
		
}
}
