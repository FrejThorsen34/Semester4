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
		    Request testRequest1 = new Request(RequestType.Regular, "RegularRequest");
            Request testRequest2 = new Request(RequestType.Formal, "FormalRequest");
			Request testRequest3 = new Request(RequestType.Urgent, "UrgentRequest");
		    Request testRequest4 = new Request(RequestType.Critical, "CriticalRequest");

            Handler regularHandler = new RegularHandler();
			Handler formalHandler = new FormalHandler();
			Handler urgentHandler = new UrgentHandler();
		    Handler criticalHandler = new CriticalHandler();

            regularHandler.SetNextHandler(formalHandler);
			formalHandler.SetNextHandler(urgentHandler);
            urgentHandler.SetNextHandler(criticalHandler);

			regularHandler.HandleRequest(testRequest1);
		    regularHandler.HandleRequest(testRequest2);
		    regularHandler.HandleRequest(testRequest3);
		    regularHandler.HandleRequest(testRequest4);

            Console.ReadKey();

		}
	}
}
