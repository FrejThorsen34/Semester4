using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGeneratorNickolai
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst,
        AgeFirst
    }
    public class ReportGenerator
    {
        private readonly CompileDB _compileDb;
        private ReportOutputFormatType _currentOutputFormat;


        public ReportGenerator(CompileDB compileDb)
        {
            if (compileDb == null) throw new ArgumentNullException("compileDb");
            _currentOutputFormat = ReportOutputFormatType.NameFirst;
            _compileDb = compileDb;
        }


        public void GenerateReport()
        {
            var employee = _compileDb.CompileDatabase();
            // All employees collected - let's output them
            switch (_currentOutputFormat)
            {
                case ReportOutputFormatType.NameFirst:
                    Console.WriteLine("Name-first report");
                    foreach (var e in employee)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Age: {0}", e.Age);
                        Console.WriteLine("------------------");
                    }
                    break;

                case ReportOutputFormatType.SalaryFirst:
                    Console.WriteLine("Salary-first report");
                    foreach (var e in employee)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("Age: {0}", e.Age);
                        Console.WriteLine("------------------");
                    }
                    break;
                case ReportOutputFormatType.AgeFirst:
                    Console.WriteLine("Age-first report");
                    foreach (var e in employee)
                    {
                        Console.WriteLine("------------------");
                        Console.WriteLine("Age: {0}", e.Age);
                        Console.WriteLine("Salary: {0}", e.Salary);
                        Console.WriteLine("Name: {0}", e.Name);
                        Console.WriteLine("------------------");
                    }
                    break;
            }
        }

        public void SetOutputFormat(ReportOutputFormatType format)
        {
            _currentOutputFormat = format;
        }
    }
}
