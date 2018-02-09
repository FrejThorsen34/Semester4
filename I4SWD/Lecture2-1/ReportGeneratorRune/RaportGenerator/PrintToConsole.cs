using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReportGenerator;

namespace RaportGenerator
{
	class PrintToConsole
	{
		private ReportOutputFormatType _format;
		public PrintToConsole(ReportOutputFormatType format)
		{
			_format = format;
		}

		public void Print(Employee e)
		{
			Console.WriteLine("------------------");

			switch (_format)
			{
				case ReportOutputFormatType.NameFirst:
					Console.WriteLine("Name: {0}", e.Name);
					Console.WriteLine("Salary: {0}", e.Salary);
					break;
				case ReportOutputFormatType.SalaryFirst:
					Console.WriteLine("Salary: {0}", e.Salary);
					Console.WriteLine("Name: {0}", e.Name);
					break;
				default:
					break;
			}

			Console.WriteLine("------------------");
		}
	}
}
