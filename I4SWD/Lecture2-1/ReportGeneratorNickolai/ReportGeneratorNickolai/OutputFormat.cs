using System;
using System.Collections.Generic;
using System.Text;

namespace ReportGeneratorNickolai
{
    public enum ReportOutputFormatType
    {
        NameFirst,
        SalaryFirst
    }
    public class OutputFormat
    {
        private static ReportOutputFormatType _currentOutputFormat;

        public OutputFormat(ReportOutputFormatType format)
        {
            if (format != ReportOutputFormatType.NameFirst && format != ReportOutputFormatType.SalaryFirst)
                Console.WriteLine("Format must be NameFirst or SalaryFirst!");
            else
                _currentOutputFormat = format;
        }

        public static void SetOutputFormat(ReportOutputFormatType format)
        {
            if (format != ReportOutputFormatType.NameFirst && format != ReportOutputFormatType.SalaryFirst)
                Console.WriteLine("Format must be NameFirst or SalaryFirst!");
            else
                _currentOutputFormat = format;
        }

        public static ReportOutputFormatType GetOutputFormatType()
        {
            return _currentOutputFormat;
        }
    }
}
