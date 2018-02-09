using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGeneratorNickolai.Application
{
    internal class ReportGeneratorClient
    {
        private static void Main()
        {
            // Db setup
            var db = new EmployeeDB();

            // Add some employees
            db.AddEmployee(new Employee("Anne", 3000, 51));
            db.AddEmployee(new Employee("Berit", 4000, 25));
            db.AddEmployee(new Employee("Christel", 1000, 37));

            // Setup compile
            var compiledDb = new CompileDB(db);
            var reportGenerator = new ReportGenerator(compiledDb);

            //Default (name-first) report
            reportGenerator.GenerateReport();

            Console.WriteLine("");
            Console.WriteLine("");

            // Create a salary-first report
            reportGenerator.SetOutputFormat(ReportOutputFormatType.SalaryFirst);
            reportGenerator.GenerateReport();

            Console.WriteLine("");
            Console.WriteLine("");

            // Create an age-first report
            reportGenerator.SetOutputFormat(ReportOutputFormatType.AgeFirst);
            reportGenerator.GenerateReport();
            Console.ReadLine();
        }
    }
}
