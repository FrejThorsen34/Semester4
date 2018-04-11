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
			else if(_nextHandler != null)
			{
                Console.WriteLine($"{request.Name} is redirected by RegularHandler");
				_nextHandler.HandleRequest(request);
			}
		}
	}

	public class FormalHandler : Handler
	{
		public override void HandleRequest(Request request)
		{
		    if (request.RequestType == RequestType.Formal)
		    {
		        Console.WriteLine($"{request.Name} handled by FormalHandler - Type: {request.RequestType}");
		    }
		    else if (_nextHandler != null)
		    {
		        Console.WriteLine($"{request.Name} is redirected by FormalHandler");
		        _nextHandler.HandleRequest(request);
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
		    else if (_nextHandler != null)
		    {
		        Console.WriteLine($"{request.Name} is redirected by UrgentHandler");
		        _nextHandler.HandleRequest(request);
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
            else if (_nextHandler != null)
            {
                Console.WriteLine($"{request.Name} is redirected by CriticalHandler");
                _nextHandler.HandleRequest(request);
            }
        }
    }
}
