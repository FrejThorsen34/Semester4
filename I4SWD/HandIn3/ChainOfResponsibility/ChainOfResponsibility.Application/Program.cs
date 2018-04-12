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
            Request testRequest2 = new Request(RequestType.Urgent, "UrgentRequest");
		    Request testRequest3 = new Request(RequestType.Haste, "HasteRequest");
            Request testRequest4 = new Request(RequestType.Critical, "CriticalRequest");
		    Request testRequest5 = new Request(RequestType.Overdue, "OverdueRequest");

            Handler regularHandler = new RegularHandler();
			Handler urgentHandler = new UrgentHandler();
		    Handler hasteHandler = new HasteHandler();
            Handler criticalHandler = new CriticalHandler();
		    Handler overdueHandler = new OverdueHandler();

            regularHandler.SetNextHandler(urgentHandler);
			urgentHandler.SetNextHandler(hasteHandler);
		    hasteHandler.SetNextHandler(criticalHandler);
            criticalHandler.SetNextHandler(overdueHandler);
			
            regularHandler.HandleRequest(testRequest1);
		    regularHandler.HandleRequest(testRequest2);
		    regularHandler.HandleRequest(testRequest3);
		    regularHandler.HandleRequest(testRequest4);
		    regularHandler.HandleRequest(testRequest5);
			
			var testRequest6 = new Request(RequestType.Other, "OtherRequest");
			var client = new Client();
			client.HandleRequest(testRequest6);

			Console.ReadKey();

		}
	}
}
