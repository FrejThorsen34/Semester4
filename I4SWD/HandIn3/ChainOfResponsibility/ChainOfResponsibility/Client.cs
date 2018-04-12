using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
	public class Client
	{
		protected Handler RequestChain;

		public Client()
		{
			RequestChain = new RegularHandler();
			var urgent = new UrgentHandler();
			var haste = new HasteHandler();
			var critical = new CriticalHandler();
			var overdue = new OverdueHandler();
			var endofchain = new EndOfChainHandler();
			RequestChain.SetNextHandler(urgent);
			urgent.SetNextHandler(haste);
			haste.SetNextHandler(critical);
			critical.SetNextHandler(overdue);
			overdue.SetNextHandler(endofchain);
		}

		public void HandleRequest(Request request)
		{
			RequestChain.HandleRequest(request);
		}
	}
}
