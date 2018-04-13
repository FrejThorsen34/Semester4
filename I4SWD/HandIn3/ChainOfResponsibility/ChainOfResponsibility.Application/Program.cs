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
			Request testRequest6 = new Request(RequestType.Other, "OtherRequest");
			
			var client = new Client();
			client.HandleRequest(testRequest1);
			client.HandleRequest(testRequest2);
			client.HandleRequest(testRequest3);
			client.HandleRequest(testRequest4);
			client.HandleRequest(testRequest5);
			client.HandleRequest(testRequest6);

			Console.ReadKey();

		}
	}
}
