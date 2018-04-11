using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.Application
{
	class Program
	{
		static void Main(string[] args)
		{
			Request testRequest1 = new Request(-1, "Negative");
			Request testRequest2 = new Request(0, "Zero");
			Request testRequest3 = new Request(1, "Positive");

			Handler positiveHandler = new PositiveHandler();
			Handler zeroHandler = new ZeroHandler();
			Handler negativeHandler = new NegativeHandler();

			negativeHandler.SetNextHandler(zeroHandler);
			zeroHandler.SetNextHandler(positiveHandler);

			negativeHandler.HandleRequest(testRequest1);
			negativeHandler.HandleRequest(testRequest2);
			negativeHandler.HandleRequest(testRequest3);

			Console.ReadKey();

		}
	}
}
