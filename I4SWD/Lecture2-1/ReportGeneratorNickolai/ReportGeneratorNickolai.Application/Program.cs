using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneratorNickolai.Application
{
    public class Program
    {
        private static void Main()
        {
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000));
            db.AddEmployee(new Employee("Berit", 2000));
            db.AddEmployee(new Employee("Christel", 1000));

            var reportGenerator = new ReportGenerator(db, ReportOutputFormatType.NameFirst);

            // Create a default (name-first) report
            reportGenerator.CompileReport();

            Console.WriteLine("");
            Console.WriteLine("");

            // Create a salary-first report
            OutputFormat.SetOutputFormat(ReportOutputFormatType.SalaryFirst);
            reportGenerator.CompileReport();
        }
    }
}
