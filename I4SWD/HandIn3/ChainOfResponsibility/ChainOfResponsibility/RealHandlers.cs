using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
	public class RegularHandler : Handler
	{
		public override void HandleRequest(Request request)
		{
			if (request.RequestType == RequestType.Regular)
			{
				Console.WriteLine($"{request.Name} handled by RegularHandler - Type: {request.RequestType}");
			}
			else if(NextHandler != null)
			{
                Console.WriteLine($"{request.Name} is redirected by RegularHandler");
				NextHandler.HandleRequest(request);
			}
		}
	}

	public class UrgentHandler : Handler
	{
		public override void HandleRequest(Request request)
		{
		    if (request.RequestType == RequestType.Urgent)
		    {
		        Console.WriteLine($"{request.Name} handled by UrgentHandler - Type: {request.RequestType}");
		    }
		    else if (NextHandler != null)
		    {
		        Console.WriteLine($"{request.Name} is redirected by UrgentHandler");
			    NextHandler.HandleRequest(request);
		    }
        }
	}

    public class HasteHandler : Handler
    {
        public override void HandleRequest(Request request)
        {
            if (request.RequestType == RequestType.Haste)
            {
                Console.WriteLine($"{request.Name} handled by HasteHandler - Type: {request.RequestType}");
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"{request.Name} is redirected by HasteHandler");
	            NextHandler.HandleRequest(request);
            }
        }
    }

    public class CriticalHandler : Handler
    {
        public override void HandleRequest(Request request)
        {
            if (request.RequestType == RequestType.Critical)
            {
                Console.WriteLine($"{request.Name} handled by CriticalHandler - Type: {request.RequestType}");
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"{request.Name} is redirected by CriticalHandler");
	            NextHandler.HandleRequest(request);
            }
        }
    }

    public class OverdueHandler : Handler
    {
        public override void HandleRequest(Request request)
        {
            if (request.RequestType == RequestType.Overdue)
            {
                Console.WriteLine($"{request.Name} handled by OverdueHandler - Type: {request.RequestType}");
            }
            else if (NextHandler != null)
            {
                Console.WriteLine($"{request.Name} is redirected by OverdueHandler");
	            NextHandler.HandleRequest(request);
            }
        }
    }

	public class EndOfChainHandler : Handler
	{
		public override void HandleRequest(Request request)
		{

			Console.WriteLine($"{request.Name} reached end of chain without getting handled - add handler for the type '{request.RequestType}' to the chain.");
			
		}
	}
}
