using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGeneratorNickolai
{
    
    public class ReportGenerator
    {
        private readonly EmployeeDB _employeeDB;
        private ReportOutputFormatType _format;

        public ReportGenerator(EmployeeDB e, ReportOutputFormatType format)
        {
            if (e == null) throw new ArgumentNullException("employeeDb");
            OutputFormat.SetOutputFormat(format);
            _employeeDB = e;
        }

        public void CompileReport()
        {
            List<Employee> report = _employeeDB.GetEmployees();
            _format = OutputFormat.GetOutputFormatType();
            switch(_format)
            {
                case ReportOutputFormatType.NameFirst:
                    Console.WriteLine("Name first report");
                    foreach (var e in report)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("------------------");
                    }
                    break;
                case ReportOutputFormatType.SalaryFirst:
                    Console.WriteLine("Salary first report");
                    foreach (var e in report)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("------------------");
                    }
                    break;
                default:
                    break;
            }
        }
    }    
}
